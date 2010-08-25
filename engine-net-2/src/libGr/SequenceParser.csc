options {
	STATIC = false;
	IGNORE_CASE = false;
}

PARSER_BEGIN(SequenceParser)
	namespace de.unika.ipd.grGen.libGr.sequenceParser;
	using System;
	using System.IO;
	using System.Collections;
	using System.Collections.Generic;
	using de.unika.ipd.grGen.libGr;
	
	/// <summary>
	/// A parser class for xgrs strings.
	/// </summary>
	public class SequenceParser
	{
		/// <summary>
		/// The rules used in the specification, set if parsing an xgrs to be interpreted
		/// </summary>
		BaseActions actions;

		/// <summary>
		/// The names of the rules used in the specification, set if parsing an xgrs to be compiled
		/// </summary>
		String[] ruleNames;
		
		/// <summary>
		/// The model used in the specification
		/// </summary>
		IGraphModel model;
		
		/// <summary>
		/// Symbol table of the sequence variables, maps from name to the prefixed(by block nesting) name and the type;
		/// a graph-global variable maps to type "", a sequence-local to its type
		/// </summary>
		SymbolTable varDecls;
		
        /// <summary>
        /// Parses a given string in xgrs syntax and builds a Sequence object. Used for the interpreted xgrs.
        /// </summary>
        /// <param name="sequenceStr">The string representing a xgrs (e.g. "test[7] &amp;&amp; (chicken+ || egg)*")</param>
        /// <param name="actions">The BaseActions object containing the rules used in the string.</param>
        /// <returns>The sequence object according to sequenceStr.</returns>
        /// <exception cref="ParseException">Thrown when a syntax error was found in the string.</exception>
        /// <exception cref="SequenceParserException">Thrown when a rule is used with the wrong number of arguments
        /// or return parameters.</exception>
		public static Sequence ParseSequence(String sequenceStr, BaseActions actions)
		{
			SequenceParser parser = new SequenceParser(new StringReader(sequenceStr));
			parser.actions = actions;
			parser.ruleNames = null;
			parser.model = actions.Graph.Model;
			parser.varDecls = new SymbolTable();
			parser.varDecls.PushFirstScope(null);
			Sequence seq = parser.XGRS();
			SequenceChecker seqChecker = new SequenceChecker(actions);
			seqChecker.Check(seq);
			return seq;
		}		

        /// <summary>
        /// Parses a given string in xgrs syntax and builds a Sequence object. Used for the compiled xgrs.
        /// </summary>
        /// <param name="sequenceStr">The string representing a xgrs (e.g. "test[7] &amp;&amp; (chicken+ || egg)*")</param>
        /// <param name="ruleNames">An array containing the names of the rules used in the specification.</param>
        /// <param name="predefinedVariables">A map from variables to types giving the parameters to the sequence, i.e. predefined variables.</param>
        /// <param name="model">The model used in the specification.</param>
        /// <returns>The sequence object according to sequenceStr.</returns>
        /// <exception cref="ParseException">Thrown when a syntax error was found in the string.</exception>
        /// <exception cref="SequenceParserException">Thrown when a rule is used with the wrong number of arguments
        /// or return parameters.</exception>
		public static Sequence ParseSequence(String sequenceStr, String[] ruleNames,
		        Dictionary<String, String> predefinedVariables, IGraphModel model)
		{
			SequenceParser parser = new SequenceParser(new StringReader(sequenceStr));
			parser.actions = null;
			parser.ruleNames = ruleNames;
			parser.model = model;
			parser.varDecls = new SymbolTable();
			parser.varDecls.PushFirstScope(predefinedVariables);
			Sequence seq = parser.XGRS();
			// check will be done by LGSPSequenceChecker from lgsp code afterwards outside of this libGr code
			return seq;
		}				
	}
PARSER_END(SequenceParser)

// characters to be skipped
SKIP: {
	" " |
	"\t" |
	"\n" |
	"\r"
}

TOKEN: {
    < EQUAL: "=" >
|	< COMMA: "," >
|	< DOLLAR: "$" >
|   < DOUBLEAMPERSAND: "&&" >
|	< AMPERSAND: "&" >
|   < DOUBLEPIPE: "||" >
|	< PIPE: "|" >
|   < CIRCUMFLEX: "^" >
|	< STAR: "*" >
|	< PLUS: "+" >
|	< EXCLAMATIONMARK: "!" >
|	< LPARENTHESIS: "(" >
|	< RPARENTHESIS: ")" >
|	< LBOXBRACKET: "[" >
|	< RBOXBRACKET: "]" >
|   < LANGLE: "<" >
|   < RANGLE: ">" >
|   < LBRACE: "{" >
|   < RBRACE: "}" >
|	< COLON: ":" >
|	< DOUBLECOLON: "::" >
|   < PERCENT: "%" >
|   < QUESTIONMARK: "?" >
|	< AT : "@" >
|   < DEF: "def" >
|   < TRUE: "true" >
|   < FALSE: "false" >
|   < SET: "set" >
|   < MAP: "map" >
|   < ARROW: "->" >
|   < FOR: "for" >
|   < IF: "if" >
|   < IN: "in" >
|   < DOT: "." >
|   < THENLEFT: "<;" >
|   < THENRIGHT: ";>" >
|   < SEMI: ";" >
|   < DOUBLESEMI: ";;" >
|   < VALLOC: "valloc" >
|   < VFREE: "vfree" >
|   < VISITED: "visited" >
|   < VRESET: "vreset" >
|   < EMIT: "emit" >
|   < NULL: "null" >
|   < YIELD: "yield" >
}

TOKEN: {
	< NUMFLOAT:
			("-")? (["0"-"9"])+ ("." (["0"-"9"])+)? (<EXPONENT>)? ["f", "F"]
		|	("-")? "." (["0"-"9"])+ (<EXPONENT>)? ["f", "F"]
	>
|
	< NUMDOUBLE:
			("-")? (["0"-"9"])+ "." (["0"-"9"])+ (<EXPONENT>)? (["d", "D"])?
		|	("-")? "." (["0"-"9"])+ (<EXPONENT>)? (["d", "D"])?
		|	("-")? (["0"-"9"])+ <EXPONENT> (["d", "D"])?
		|	("-")? (["0"-"9"])+ ["d", "D"]
	>
|
	< #EXPONENT: ["e", "E"] (["+", "-"])? (["0"-"9"])+ >
|
	< NUMBER: ("-")? (["0"-"9"])+ >
|
	< HEXNUMBER: "0x" (["0"-"9", "a"-"f", "A"-"F"])+ >
|	
	< DOUBLEQUOTEDTEXT : "\"" (~["\"", "\n", "\r"])* "\"" >
		{ matchedToken.image = matchedToken.image.Substring(1, matchedToken.image.Length-2); }
|	
	< SINGLEQUOTEDTEXT : "\'" (~["\'", "\n", "\r"])* "\'" >
		{ matchedToken.image = matchedToken.image.Substring(1, matchedToken.image.Length-2); }
|	
< WORD : ["A"-"Z", "a"-"z", "_"] (["A"-"Z", "a"-"z", "_", "0"-"9"])* >
}

String Word():
{
	Token tok;
}
{
	tok=<WORD>
	{
		return tok.image;		
	}
}

String TextString():
{
	Token tok;
}
{
	tok=<DOUBLEQUOTEDTEXT>
	{
		return tok.image;
	}
}

String Text():
{
	Token tok;
}
{
	(tok=<DOUBLEQUOTEDTEXT> | tok=<SINGLEQUOTEDTEXT> | tok=<WORD>)
	{
		return tok.image;		
	}
}

int Number():
{
	Token t;
	int val;
}
{
	(
		t=<NUMBER>
		{
			if(!Int32.TryParse(t.image, out val))
				throw new ParseException("Integer expected but found: \"" + t + "\" (" + t.kind + ")");
			return val;
		}
	|
		t=<HEXNUMBER>
		{
			return Int32.Parse(t.image.Substring("0x".Length), System.Globalization.NumberStyles.HexNumber);
		}
	)
}

float FloatNumber():
{
	Token t;
	float val;
}
{
	t=<NUMFLOAT>
	{
		// Remove 'F' from the end of the image to parse it
		if(!float.TryParse(t.image.Substring(0, t.image.Length - 1), System.Globalization.NumberStyles.Float,
				System.Globalization.CultureInfo.InvariantCulture, out val))
			throw new ParseException("float expected but found: \"" + t + "\" (" + t.kind + ")");
		return val;
	}
}

double DoubleNumber():
{
	Token t;
	String img;
	double val;
}
{
	t=<NUMDOUBLE>
	{
		// Remove optional 'D' from the end of the image to parse it if necessary
		if(t.image[t.image.Length - 1] == 'd' || t.image[t.image.Length - 1] == 'D')
			img = t.image.Substring(0, t.image.Length - 1);
		else
			img = t.image;
		if(!double.TryParse(img, System.Globalization.NumberStyles.Float,
				System.Globalization.CultureInfo.InvariantCulture, out val))
			throw new ParseException("double expected but found: \"" + t + "\" (" + t.kind + ")");
		return val;
	}
}

void Parameters(List<SequenceVariable> parameters):
{
	SequenceVariable var;
}
{
	var=VariableUse() { parameters.Add(var); } ("," var=VariableUse() { parameters.Add(var); })*
}

void RuleParameter(List<SequenceVariable> paramVars, List<Object> paramConsts):
{
	SequenceVariable var;
	object constant;
}
{
	LOOKAHEAD(2) constant=Constant()
	{
		paramVars.Add(null);
		paramConsts.Add(constant);
	}
|
	var=VariableUse()
	{
		paramVars.Add(var);
		paramConsts.Add(null);
	}
}

object SimpleConstant():
{
	object constant = null;
	int number;
	string type, value;
}
{
	(
		number=Number() { constant = (int) number; }
	|
		constant=FloatNumber()
	|
		constant=DoubleNumber()
	|
		constant=TextString()
	|
		<TRUE> { constant = true; }
	|
		<FALSE> { constant = false; }
	|
		<NULL> { constant = null; }
	| 
		type=Word() "::" value=Word() 
		{ 
			foreach(EnumAttributeType attrType in model.EnumAttributeTypes)
			{
				if(attrType.Name == type)
				{
					Type enumType = attrType.EnumType;
					constant = Enum.Parse(enumType, value);
					break;
				}
			}
			if(constant==null) 
				throw new ParseException("Invalid constant \""+type+"::"+value+"\"!");
		}
	)
	{
		return constant;
	}
}

object Constant():
{
	object constant = null;
	object src = null, dst = null;
	string typeName, typeNameDst;
	Type srcType, dstType;
}
{
	(
		constant=SimpleConstant()
    |
		"set" "<" typeName=Word() ">"
		{
			srcType = DictionaryHelper.GetTypeFromNameForDictionary(typeName, model);
			dstType = typeof(de.unika.ipd.grGen.libGr.SetValueType);
			if(srcType!=null)
				constant = DictionaryHelper.NewDictionary(srcType, dstType);
			if(constant==null) 
				throw new ParseException("Invalid constant \"set<"+typeName+">\"!");
		}
		"{"
			( src=SimpleConstant() { ((IDictionary)constant).Add(src, null); } )? 
				( "," src=SimpleConstant() { ((IDictionary)constant).Add(src, null); })*
		"}"
	|
		"map" "<" typeName=Word() "," typeNameDst=Word() ">"
		{
			srcType = DictionaryHelper.GetTypeFromNameForDictionary(typeName, model);
			dstType = DictionaryHelper.GetTypeFromNameForDictionary(typeNameDst, model);
			if(srcType!=null && dstType!=null) 
				constant = DictionaryHelper.NewDictionary(srcType, dstType);
			if(constant==null) 
				throw new ParseException("Invalid constant \"map<"+typeName+","+typeNameDst+">\"!");
		}
		"{"
			( src=SimpleConstant() "->" dst=SimpleConstant() { ((IDictionary)constant).Add(src, dst); } )?
				( "," src=SimpleConstant() "->" dst=SimpleConstant() { ((IDictionary)constant).Add(src, dst); } )*
		"}"
	)
	{
		return constant;
	}
}

void RuleParameters(List<SequenceVariable> paramVars, List<Object> paramConsts):
{ }
{
	RuleParameter(paramVars, paramConsts) ("," RuleParameter(paramVars, paramConsts))*
}


SequenceVariable Variable(): // usage as well as definition
{
	String varName, typeName = null, typeNameDst;
}
{
	varName=Word() (":" (typeName=Word()
							| "set" "<" typeName=Word() ">" { typeName = "set<"+typeName+">"; }
							| "map" "<" typeName=Word() "," typeNameDst=Word() ">" { typeName = "map<"+typeName+","+typeNameDst+">"; }
						  )
					 )?
	{
		SequenceVariable oldVariable = varDecls.Lookup(varName);
		SequenceVariable newVariable;
		if(typeName!=null)
		{
			if(oldVariable==null) {
				newVariable = varDecls.Define(varName, typeName);
			} else if(oldVariable.Type=="") {
				throw new ParseException("The variable \""+varName+"\" has already been used/implicitely declared as global variable!");
			} else {
				throw new ParseException("The variable \""+varName+"\" has already been declared as local variable with type \""+oldVariable.Type+"\"!");
			}
		}
		else
		{
			if(oldVariable==null) {
				newVariable = varDecls.Define(varName, "");
			} else {
				newVariable = oldVariable;
			}
		}		
		return newVariable;
	}
}

SequenceVariable VariableUse(): // only usage in contrast to Variable()
{
	String varName;
}
{
	varName=Word()
	{
		SequenceVariable oldVariable = varDecls.Lookup(varName);
		SequenceVariable newVariable;
		if(oldVariable==null) {
			newVariable = varDecls.Define(varName, "");
		} else {
			newVariable = oldVariable;
		}
		return newVariable;
	}
}

void VariableList(List<SequenceVariable> variables):
{
	SequenceVariable var;
}
{
	var=Variable() { variables.Add(var); } ("," var=Variable() { variables.Add(var); })*
}

Sequence XGRS():
{
	Sequence seq;
}
{
	seq=RewriteSequence() <EOF>
	{
		return seq;
	}
}

/////////////////////////////////////////
// Extended rewrite sequence           //
// (lowest precedence operators first) //
/////////////////////////////////////////

Sequence RewriteSequence():
{
	Sequence seq, seq2;
	bool random = false, choice = false;
}
{
	seq=RewriteSequenceLazyOr()
	(
		LOOKAHEAD(3)
		(
			LOOKAHEAD(3)
			("$" { random = true; } ("%" { choice = true; })?)? "<;" seq2=RewriteSequence()							
			{
				seq = new SequenceThenLeft(seq, seq2, random, choice);
			}
		|
			("$" { random = true; } ("%" { choice = true; })?)? ";>" seq2=RewriteSequence()							
			{
				seq = new SequenceThenRight(seq, seq2, random, choice);
			}
		)
	)?
	{
		return seq;
	}
}

Sequence RewriteSequenceLazyOr():
{
	Sequence seq, seq2;
	bool random = false, choice = false;
}
{
	seq=RewriteSequenceLazyAnd()
	(
		LOOKAHEAD(3)
		("$" { random = true; } ("%" { choice = true; })?)? "||" seq2=RewriteSequenceLazyOr()							
		{
			seq = new SequenceLazyOr(seq, seq2, random, choice);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequenceLazyAnd():
{
	Sequence seq, seq2;
	bool random = false, choice = false;
}
{
	seq=RewriteSequenceStrictOr()
	(
		LOOKAHEAD(3)
		("$" { random = true; } ("%" { choice = true; })?)? "&&" seq2=RewriteSequenceLazyAnd()
		{
			seq = new SequenceLazyAnd(seq, seq2, random, choice);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequenceStrictOr():
{
	Sequence seq, seq2;
	bool random = false, choice = false;
}
{
	seq=RewriteSequenceStrictXor()
	(
		LOOKAHEAD(3)
		("$" { random = true; } ("%" { choice = true; })?)? "|" seq2=RewriteSequenceStrictOr()
		{
			seq = new SequenceStrictOr(seq, seq2, random, choice);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequenceStrictXor():
{
	Sequence seq, seq2;
	bool random = false, choice = false;
}
{
	seq=RewriteSequenceStrictAnd()
	(
		LOOKAHEAD(3)
		("$" { random = true; } ("%" { choice = true; })?)? "^" seq2=RewriteSequenceStrictXor()
		{
			seq = new SequenceXor(seq, seq2, random, choice);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequenceStrictAnd():
{
	Sequence seq, seq2;
	bool random = false, choice = false;
}
{
	seq=RewriteSequenceNeg()
	(
		LOOKAHEAD(3)
		("$" { random = true; } ("%" { choice = true; })?)? "&" seq2=RewriteSequenceStrictAnd()
		{
			seq = new SequenceStrictAnd(seq, seq2, random, choice);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequenceNeg():
{
	Sequence seq;
}
{
    "!" seq=RewriteSequenceNeg()
	{
		return new SequenceNot(seq);
	}
|	
	seq=RewriteSequenceIteration()
	{
		return seq;
	}
}

Sequence RewriteSequenceIteration():
{
	Sequence seq;
	int minnum, maxnum = -1;
	bool maxspecified = false;
	bool maxstar = false;
}
{
	(
		seq=SimpleSequence()
		(
			"*"
			{
				seq = new SequenceIterationMin(seq, 0);
			}
		|
			"+"
			{
				seq = new SequenceIterationMin(seq, 1);
			}
		|
		    "[" 
				(
					minnum=Number()
				    (
						":"
						(
							maxnum=Number() { maxspecified = true; }
						|
							"*" { maxstar = true; }
						)
					)?
				|
					"*" { minnum = 0; maxstar = true; }
				|
					"+" { minnum = 1; maxstar = true; }
				)
			"]"
			{
			    if(maxstar) {
					seq = new SequenceIterationMin(seq, minnum);
			    } else {
					if(!maxspecified) maxnum = minnum;
					seq = new SequenceIterationMinMax(seq, minnum, maxnum);
				}
			}
		)?
	)
	{
		return seq;
	}
}

Sequence SimpleSequence():
{
	bool special = false, choice = false;
	Sequence seq, seq2, seq3 = null;
	List<SequenceVariable> paramVars = new List<SequenceVariable>();
	List<Sequence> sequences = new List<Sequence>();
	SequenceVariable toVar, fromVar, fromVar2 = null, fromVar3 = null;
	String attrName, method, elemName;
	int num = 0;
	object constant;
	String str;
}
{
	LOOKAHEAD(Variable() "=") toVar=Variable() "="
    (
	    "valloc" "(" ")"
		{
			return new SequenceAssignVAllocToVar(toVar);
		}
	|
		LOOKAHEAD(3) fromVar=VariableUse() "." "visited" "[" fromVar2=VariableUse() "]"
        {
			return new SequenceAssignSequenceResultToVar(toVar, new SequenceIsVisited(fromVar, fromVar2));
        }
	|
        LOOKAHEAD(4) fromVar=VariableUse() "." method=Word() "(" ")"
		{
			if(method=="size") return new SequenceAssignSetmapSizeToVar(toVar, fromVar);
			else if(method=="empty") return new SequenceAssignSetmapEmptyToVar(toVar, fromVar);
			else throw new ParseException("Unknown method name: \"" + method + "\"! (available are size|empty on set/map)");
		}
	|
        LOOKAHEAD(2) fromVar=VariableUse() "." attrName=Word()
        {
            return new SequenceAssignAttributeToVar(toVar, fromVar, attrName);
        }
	|
		LOOKAHEAD(2) fromVar=VariableUse() "[" fromVar2=VariableUse() "]" // parsing v=a[ as v=a[x] has priority over (v=a)[*]
		{
			return new SequenceAssignMapAccessToVar(toVar, fromVar, fromVar2);
		}
	|
		LOOKAHEAD(2) fromVar=VariableUse() "in" fromVar2=VariableUse()
		{
			return new SequenceAssignSequenceResultToVar(toVar, new SequenceIn(fromVar, fromVar2));
		}
	|
        LOOKAHEAD(2) fromVar=VariableUse() "(" // deliver understandable error message for case of missing parenthesis at rule result assignment
        { 
            throw new ParseException("the destination variable(s) of a rule result assignment must be enclosed in parenthesis");
        }
	|
		LOOKAHEAD(2) constant=Constant()
		{
			return new SequenceAssignConstToVar(toVar, constant);
		}
    |
		fromVar=VariableUse()
        {
            return new SequenceAssignVarToVar(toVar, fromVar);
        }
    |
        "@" "(" elemName=Text() ")"
        {
            return new SequenceAssignElemToVar(toVar, elemName);
        }
    |
        LOOKAHEAD(4) "$" "%" "(" str=Text() ")"
        {
            return new SequenceAssignUserInputToVar(toVar, str);
        }
    |
        "$" ("%" { choice = true; } )? "(" num=Number() ")"
        {
            return new SequenceAssignRandomToVar(toVar, num, choice);
        }
	|
		"def" "(" Parameters(paramVars) ")" // todo: eigentliches Ziel: Zuweisung simple sequence an Variable
		{
			return new SequenceAssignSequenceResultToVar(toVar, new SequenceDef(paramVars.ToArray()));
		}
	|
		"(" seq=RewriteSequence() ")"
		{
			return new SequenceAssignSequenceResultToVar(toVar, seq);
		}
    )
|
	LOOKAHEAD(7) toVar=VariableUse() "." "visited" "[" fromVar=VariableUse() "]" "="
		(
			fromVar2=VariableUse() { return new SequenceSetVisited(toVar, fromVar, fromVar2); }
		|
			"true" { return new SequenceSetVisited(toVar, fromVar, true); }
		|
			"false" { return new SequenceSetVisited(toVar, fromVar, false); }
		)
|
	LOOKAHEAD(3) fromVar=VariableUse() "." "visited" "[" fromVar2=VariableUse() "]"
	{
		return new SequenceIsVisited(fromVar, fromVar2);
	}
|
	"vfree" "(" fromVar=VariableUse() ")"
	{
		return new SequenceVFree(fromVar);
	}
|
	"vreset" "(" fromVar=VariableUse() ")"
	{
		return new SequenceVReset(fromVar);
	}
|
	"emit" "("
		( str=TextString() { seq = new SequenceEmit(str); }
		| fromVar=VariableUse() { seq = new SequenceEmit(fromVar);} )
	")" { return seq; } 
|
	LOOKAHEAD(4) toVar=VariableUse() "." attrName=Word() "=" fromVar=VariableUse()
    {
        return new SequenceAssignVarToAttribute(toVar, attrName, fromVar);
    }
|
	LOOKAHEAD(2) fromVar=VariableUse() "." method=Word() "(" ( fromVar2=VariableUse() ("," fromVar3=VariableUse())? )? ")"
	{
		if(method=="add") {
			if(fromVar2==null) throw new ParseException("\"" + method + "\" expects 1(for set) or 2(for map) parameters)");
			return new SequenceSetmapAdd(fromVar, fromVar2, fromVar3);
		} else if(method=="rem") {
			if(fromVar2==null || fromVar3!=null) throw new ParseException("\"" + method + "\" expects 1 parameter)");
			return new SequenceSetmapRem(fromVar, fromVar2); 
		} else if(method=="clear") {
			if(fromVar2!=null || fromVar3!=null) throw new ParseException("\"" + method + "\" expects no parameters)");
			return new SequenceSetmapClear(fromVar);
		} else {
			throw new ParseException("Unknown method name: \"" + method + "\"! (available are add|rem|clear on set/map)");
		}
    }
|
	LOOKAHEAD(2) fromVar=VariableUse() "in" fromVar2=VariableUse()
	{
		return new SequenceIn(fromVar, fromVar2);
	}
|
	LOOKAHEAD(RuleLookahead()) seq=Rule()
	{
		return seq;
	}
|
	"def" "(" Parameters(paramVars) ")"
	{
		return new SequenceDef(paramVars.ToArray());
	}
|
    LOOKAHEAD(2) ("%" { special = true; })? "true"
    {
        return new SequenceTrue(special);
    }
|
    LOOKAHEAD(2) ("%" { special = true; })? "false"
    {
        return new SequenceFalse(special);
    }
|
	LOOKAHEAD(4) "$" ("%" { choice = true; } )? 
		"||" "(" seq=RewriteSequence() { sequences.Add(seq); } ("," seq=RewriteSequence() { sequences.Add(seq); })* ")"
	{
		return new SequenceLazyOrAll(sequences, choice);
	}
|
	LOOKAHEAD(4) "$" ("%" { choice = true; } )? 
		"||" "[" seq=Rule() { sequences.Add(seq); } ("," seq=Rule() { sequences.Add(seq); })* "]"
	{
		return new SequenceLazyOrAllAll(sequences, choice);
	}
|
	LOOKAHEAD(4) "$" ("%" { choice = true; } )? 
		"&&" "(" seq=RewriteSequence() { sequences.Add(seq); } ("," seq=RewriteSequence() { sequences.Add(seq); })* ")"
	{
		return new SequenceLazyAndAll(sequences, choice);
	}
|
	LOOKAHEAD(4) "$" ("%" { choice = true; } )? 
		"&&" "[" seq=Rule() { sequences.Add(seq); } ("," seq=Rule() { sequences.Add(seq); })* "]"
	{
		return new SequenceLazyAndAllAll(sequences, choice);
	}
|
	LOOKAHEAD(4) "$" ("%" { choice = true; } )? 
		"|" "(" seq=RewriteSequence() { sequences.Add(seq); } ("," seq=RewriteSequence() { sequences.Add(seq); })* ")"
	{
		return new SequenceStrictOrAll(sequences, choice);
	}
|
	LOOKAHEAD(4) "$" ("%" { choice = true; } )? 
		"|" "[" seq=Rule() { sequences.Add(seq); } ("," seq=Rule() { sequences.Add(seq); })* "]"
	{
		return new SequenceStrictOrAllAll(sequences, choice);
	}
|
	LOOKAHEAD(4) "$" ("%" { choice = true; } )? 
		"&" "(" seq=RewriteSequence() { sequences.Add(seq); } ("," seq=RewriteSequence() { sequences.Add(seq); })* ")"
	{
		return new SequenceStrictAndAll(sequences, choice);
	}
|
	"$" ("%" { choice = true; } )? 
		"&" "[" seq=Rule() { sequences.Add(seq); } ("," seq=Rule() { sequences.Add(seq); })* "]"
	{
		return new SequenceStrictAndAllAll(sequences, choice);
	}
|
	"(" seq=RewriteSequence() ")"
	{
		return seq;
	}
|
    "<" seq=RewriteSequence() ">"
    {
        return new SequenceTransaction(seq);
    }
|
    "if" "{" { varDecls.PushScope(ScopeType.If); } seq=RewriteSequence() ";"
		{ varDecls.PushScope(ScopeType.IfThenPart); } seq2=RewriteSequence() { varDecls.PopScope(); }
		(";" seq3=RewriteSequence())? { varDecls.PopScope(); } "}"
    {
		if(seq3==null) return new SequenceIfThen(seq, seq2);
        else return new SequenceIfThenElse(seq, seq2, seq3);
    }
|
	"for" "{" { varDecls.PushScope(ScopeType.For); } fromVar=Variable() ("->" fromVar2=Variable())? "in" fromVar3=VariableUse() ";"
		seq=RewriteSequence() { varDecls.PopScope(); } "}"
	{
        return new SequenceFor(fromVar, fromVar2, fromVar3, seq);
    }
|
	"yield" "(" Parameters(paramVars) ")"
	{
		return new SequenceYield(paramVars.ToArray());
	}
}

void RuleLookahead():
{
}
{
	("(" Word() (":" (Word() | "set" "<" Word() ">" | "map" "<" Word() "," Word() ">"))?
			("," Word() (":" (Word() | "set" "<" Word() ">" | "map" "<" Word() "," Word() ">"))?)* ")" "=")?
	(
	    ("$" ("%")? (Variable())?)? "["
	|
	    ("%" | "?")* Word()
	)
}

Sequence Rule():
{
	bool special = false, test = false;
	String str;
	bool chooseRandSpecified = false, choice = false;
	SequenceVariable varChooseRand = null;
	List<SequenceVariable> paramVars = new List<SequenceVariable>();
	List<Object> paramConsts = new List<Object>();
	List<SequenceVariable> returnVars = new List<SequenceVariable>();
}
{
	("(" VariableList(returnVars) ")" "=" )? 
	(
		(
			"$" ("%" { choice = true; })? (varChooseRand=Variable())? { chooseRandSpecified = true; }
		)?
		"[" ("%" { special = true; } | "?" { test = true; })* str=Word()
		("(" RuleParameters(paramVars, paramConsts) ")")?
		"]"
		{
			// No variable with this name may exist
			if(varDecls.Lookup(str)!=null)
				throw new SequenceParserException(str, SequenceParserError.RuleNameUsedByVariable);

			return new SequenceRuleAll(CreateRuleInvocationParameterBindings(str, paramVars, paramConsts, returnVars),
					special, test, chooseRandSpecified, varChooseRand, choice);
		}
	|
		("%" { special = true; } | "?" { test = true; })*
		str=Word() ("(" RuleParameters(paramVars, paramConsts) ")")? // if only str is given, this might be a variable predicate; but this is decided later on in resolve
		{
			if(paramVars.Count==0 && returnVars.Count==0)
			{
				SequenceVariable var = varDecls.Lookup(str);
				if(var!=null)
				{
					if(var.Type!="" && var.Type!="boolean")
						throw new SequenceParserException(str, "untyped or bool", var.Type);
					return new SequenceVarPredicate(var, special);
				}
			}

			// No variable with this name may exist
			if(varDecls.Lookup(str)!=null)
				throw new SequenceParserException(str, SequenceParserError.RuleNameUsedByVariable);
				
			return new SequenceRule(CreateRuleInvocationParameterBindings(str, paramVars, paramConsts, returnVars),
					special, test);
		}
	)
}

CSHARPCODE
RuleInvocationParameterBindings CreateRuleInvocationParameterBindings(String ruleName, 
				List<SequenceVariable> paramVars, List<Object> paramConsts, List<SequenceVariable> returnVars)
{
	IAction action = null;
	if(actions != null)
		action = actions.GetAction(ruleName);
			
	RuleInvocationParameterBindings paramBindings = new RuleInvocationParameterBindings(action, 
			paramVars.ToArray(), paramConsts.ToArray(), returnVars.ToArray());

	if(action == null)
		paramBindings.RuleName = ruleName;

	return paramBindings;
}

TOKEN: { < ERROR: ~[] > }
