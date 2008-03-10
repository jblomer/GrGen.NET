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
		BaseActions actions;
		NamedGraph namedGraph;
		
		/// <summary>
		/// Maps variable names to type names.
		/// Variable usages before declaration create a map entry with a null type.
		/// If varDecls is null, no variable declarations are allowed.
		/// </summary>
		Dictionary<String, String> varDecls;
		
        /// <summary>
        /// Parses a given string in xgrs syntax and builds a Sequence object.
        /// </summary>
        /// <param name="sequenceStr">The string representing a xgrs (e.g. "test[7] &amp;&amp; (chicken+ || egg)*")</param>
        /// <param name="actions">The BaseActions object containing the rules used in the string.</param>
        /// <returns>The sequence object according to sequenceStr.</returns>
        /// <exception cref="ParseException">Thrown when a syntax error was found in the string.</exception>
        /// <exception cref="SequenceParserRuleException">Thrown when a rule is used with the wrong number of arguments
        /// or return parameters.</exception>
		public static Sequence ParseSequence(String sequenceStr, BaseActions actions)
		{
			SequenceParser parser = new SequenceParser(new StringReader(sequenceStr));
			parser.actions = actions;
			return parser.RewriteSequence();
		}		

        /// <summary>
        /// Parses a given string in xgrs syntax and builds a Sequence object.
        /// </summary>
        /// <param name="sequenceStr">The string representing a xgrs (e.g. "test[7] &amp;&amp; (chicken+ || egg)*")</param>
        /// <param name="actions">The BaseActions object containing the rules used in the string.</param>
        /// <param name="varDecls">A map from variables to types which will be filled for the
        /// given sequence. It may already contain predefined variables.</param>
        /// <returns>The sequence object according to sequenceStr.</returns>
        /// <exception cref="ParseException">Thrown when a syntax error was found in the string.</exception>
        /// <exception cref="SequenceParserRuleException">Thrown when a rule is used with the wrong number of arguments
        /// or return parameters.</exception>
		public static Sequence ParseSequence(String sequenceStr, BaseActions actions,
		        Dictionary<String, String> varDecls)
		{
			SequenceParser parser = new SequenceParser(new StringReader(sequenceStr));
			parser.actions = actions;
			parser.varDecls = varDecls;
			return parser.RewriteSequence();
		}		

        /// <summary>
        /// Parses a given string in xgrs syntax and builds a Sequence object.
        /// </summary>
        /// <param name="sequenceStr">The string representing a xgrs (e.g. "test[7] &amp;&amp; (chicken+ || egg)*")</param>
        /// <param name="actions">The BaseActions object containing the rules used in the string.</param>
        /// <param name="namedGraph">A NamedGraph object to be used for named element access (@-operator).</param>
        /// <returns>The sequence object according to sequenceStr.</returns>
        /// <exception cref="ParseException">Thrown when a syntax error was found in the string.</exception>
        /// <exception cref="SequenceParserRuleException">Thrown when a rule is used with the wrong number of arguments
        /// or return parameters.</exception>
		public static Sequence ParseSequence(String sequenceStr, BaseActions actions, NamedGraph namedGraph)
		{
			SequenceParser parser = new SequenceParser(new StringReader(sequenceStr));
			parser.actions = actions;
			parser.namedGraph = namedGraph;
			return parser.RewriteSequence();
		}		
	}
PARSER_END(SequenceParser)

// characters to be skipped
SKIP: {
	" " |
	"\t" |
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
|	< COLON: ":" >
|   < PERCENT: "%" >
|   < QUESTIONMARK: "?" >
|	< AT : "@" >
|   < DEF: "def" >
|   < TRUE: "true" >
|   < FALSE: "false" >
}

TOKEN: {
	< NUM: (["0"-"9"])+ >
|	< DOUBLEQUOTEDTEXT : "\"" (~["\"", "\n", "\r"])* "\"" >
		{ matchedToken.image = matchedToken.image.Substring(1, matchedToken.image.Length-2); }
|	< SINGLEQUOTEDTEXT : "\'" (~["\'", "\n", "\r"])* "\'" >
		{ matchedToken.image = matchedToken.image.Substring(1, matchedToken.image.Length-2); }
|	< WORD : ~["0"-"9", "=", ":", ";", ".", ",", "+", "-", "*", "/", "&", "%", "?", "$", "|", "^", "<", ">", "(", ")", "{", "}", "[", "]", "*", "!", "#", " ", "@", "\n", "\r"]
	     (~["\'", "\"", "=", ":", ";", ".", ",", "+", "-", "*", "/", "&", "%", "?", "$", "|", "^", "<", ">", "(", ")", "{", "}", "[", "]", "*", "!", "#", " ", "@", "\n", "\r"])*	>
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

long Number():
{
	Token t;
	long val;
}
{
	t=<NUM>
	{
	    if(!long.TryParse(t.image, out val))
	        throw new ParseException("64-bit integer expected but found: \"" + t.image + "\"");
	    return val;
	}
}

void Parameters(List<String> parameters):
{
	String str;
}
{
	str=Text() { parameters.Add(str); } ("," str=Text() { parameters.Add(str); })*
}

String Variable():
{
	String toVarName, typeName = null;
}
{
	toVarName=Text() (":" typeName=Text())?
	{
		if(varDecls != null)
		{
			String oldTypeName;
			if(varDecls.TryGetValue(toVarName, out oldTypeName))
			{
				if(typeName != null)
				{
					if(oldTypeName != null)
						throw new ParseException("The variable \"" + toVarName + "\" has already been declared!");
					varDecls[toVarName] = typeName;
				}
			}
			else varDecls[toVarName] = typeName;
		}
		else if(typeName != null)
			throw new ParseException("Variable types are not supported here!");
		return toVarName;
	}
}

void VariableList(List<String> variables):
{
	String str;
}
{
	str=Variable() { variables.Add(str); } ("," str=Variable() { variables.Add(str); })*
}


/////////////////////////////////////////
// Extended rewrite sequence           //
// (lowest precedence operators first) //
/////////////////////////////////////////

Sequence RewriteSequence():
{
	Sequence seq, seq2;
	bool random = false;
}
{
	seq=RewriteSequence2()
	(
		LOOKAHEAD(2)
		("$" { random = true; })? "||" seq2=RewriteSequence()							
		{
			seq = new SequenceLazyOr(seq, seq2, random);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequence2():
{
	Sequence seq, seq2;
	bool random = false;
}
{
	seq=RewriteSequence3()
	(
		LOOKAHEAD(2)
		("$" { random = true; })? "&&" seq2=RewriteSequence2()
		{
			seq = new SequenceLazyAnd(seq, seq2, random);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequence3():
{
	Sequence seq, seq2;
	bool random = false;
}
{
	seq=RewriteSequence4()
	(
		LOOKAHEAD(2)
		("$" { random = true; })? "|" seq2=RewriteSequence3()
		{
			seq = new SequenceStrictOr(seq, seq2, random);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequence4():
{
	Sequence seq, seq2;
	bool random = false;
}
{
	seq=RewriteSequence5()
	(
		LOOKAHEAD(2)
		("$" { random = true; })? "^" seq2=RewriteSequence4()
		{
			seq = new SequenceXor(seq, seq2, random);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequence5():
{
	Sequence seq, seq2;
	bool random = false;
}
{
	seq=RewriteSequence6()
	(
		LOOKAHEAD(2)
		("$" { random = true; })? "&" seq2=RewriteSequence5()
		{
			seq = new SequenceStrictAnd(seq, seq2, random);
		}
	)?
	{
		return seq;
	}
}

Sequence RewriteSequence6():
{
	Sequence seq;
}
{
    "!" seq=RewriteSequence6()
	{
		return new SequenceNot(seq);
	}
|	
	seq=SingleSequence()
	{
		return seq;
	}
}

Sequence SingleSequence():
{
	Sequence seq;
	long minnum = -1, maxnum, temp;
	bool maxspecified = false;
	bool maxstar = false;
}
{
	(
		seq=SimpleSequence()
		(
			"*"
			{
				seq = new SequenceMin(seq, 0);
			}
		|
			"+"
			{
				seq = new SequenceMin(seq, 1);
			}
		|
		    "[" maxnum=Number() (":"
				(
					temp=Number() { minnum = maxnum; maxnum = temp; maxspecified = true; }
				|
					"*" { minnum = maxnum; maxstar = true; }
				))? "]"
			{
			    if(maxstar)
			    {
					seq = new SequenceMin(seq, minnum);
			    }
			    else
			    {
					if(!maxspecified) minnum = maxnum;
					seq = new SequenceMinMax(seq, minnum, maxnum);
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
	bool special = false;
	Sequence seq;
	List<String> defParamVars = new List<String>();
	String toVarName, typeName = null, fromName;
	IGraphElement elem;
}
{
	LOOKAHEAD(2) toVarName=Text() (":" typeName=Text())? "="
	{
		if(varDecls != null)
		{
			String oldTypeName;
			if(varDecls.TryGetValue(toVarName, out oldTypeName))
			{
				if(typeName != null)
				{
					if(oldTypeName != null)
					throw new ParseException("The variable \"" + toVarName + "\" has already been declared!");
					varDecls[toVarName] = typeName;
				}
			}
			else varDecls[toVarName] = typeName;
		}
	}
    (
        fromName=Text()
        {
            return new SequenceAssignVarToVar(toVarName, fromName);
        }
    |
        "@" "(" fromName=Text() ")"
        {
            if(actions == null)
                throw new ParseException("The @-operator is not allowed without an BaseActions instance!");
            if(namedGraph == null)
                throw new ParseException("The @-operator can only be used with NamedGraphs!");
                
            elem = namedGraph.GetGraphElement(fromName);
            if(elem == null)
                throw new ParseException("Graph element does not exist: \"" + fromName + "\"!");
            return new SequenceAssignElemToVar(toVarName, elem);
        }
    )
|
    // 4 tokens lookahead: "(" <TEXT> ")" ("=" => next is Rule() | (<NL> | operator) => parentheses around RewriteSequence)
	LOOKAHEAD(4) seq=Rule()
	{
		return seq;
	}
|
	"def" "(" Parameters(defParamVars) ")"
	{
		return new SequenceDef(defParamVars.ToArray());
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
	"(" seq=RewriteSequence() ")"
	{
		return seq;
	}
|
    "<" seq=RewriteSequence() ">"
    {
        return new SequenceTransaction(seq);
    }
}


Sequence Rule():
{
	bool special = false, test = false;
	String str;
	IAction action = null;
	bool retSpecified = false;
	List<String> paramVars = new List<String>();
	List<String> returnVars = new List<String>();
}
{
	("(" VariableList(returnVars) ")" "=" { retSpecified = true; })? 
	(
	    "[" ("%" { special = true; } | "?" { test = true; })* str=Text() ("(" Parameters(paramVars) ")")? "]"
	    {
   		    return new SequenceRuleAll(CreateRuleObject(str, paramVars, returnVars, retSpecified), special, test);
	    }
	|
	    ("%" { special = true; } | "?" { test = true; })* str=Text() ("(" Parameters(paramVars) ")")?
	    {
   		    return new SequenceRule(CreateRuleObject(str, paramVars, returnVars, retSpecified), special, test);
	    }
	)
}

CSHARPCODE
RuleObject CreateRuleObject(String ruleName, List<String> paramVars, List<String> returnVars, bool retSpecified)
{
    IAction action = null;
    if(actions != null)
    {
        action = actions.GetAction(ruleName);
        if(action == null || action.RulePattern.Inputs.Length != paramVars.Count
                          || retSpecified && action.RulePattern.Outputs.Length != returnVars.Count)
	        throw new SequenceParserRuleException(ruleName, action, paramVars.Count, returnVars.Count);
        if(!retSpecified && action.RulePattern.Outputs.Length > 0)
        {
            for(int i = action.RulePattern.Outputs.Length; i > 0; i--)
                returnVars.Add(null);
        }
    }
    RuleObject ruleObj = new RuleObject(action, paramVars.ToArray(), returnVars.ToArray());
    if(actions == null)
        ruleObj.RuleName = ruleName;
        
    return ruleObj;
}
