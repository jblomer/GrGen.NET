header {
/*
  GrGen: graph rewrite generator tool.
  Copyright (C) 2005  IPD Goos, Universit"at Karlsruhe, Germany

  This library is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public
  License as published by the Free Software Foundation; either
  version 2.1 of the License, or (at your option) any later version.

  This library is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
  Lesser General Public License for more details.

  You should have received a copy of the GNU Lesser General Public
  License along with this library; if not, write to the Free Software
  Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/

/**
 * @author Sebastian Hack, Daniel Grund, Rubino Geiss
 * @version $Id$
 */
	package de.unika.ipd.grgen.parser.antlr;

	import java.util.Iterator;
	import java.util.List;
	import java.util.LinkedList;
	import java.util.Map;
	import java.util.HashMap;
	import java.util.Collection;
	import java.io.DataInputStream;
	import java.io.FileInputStream;
	import java.io.FileNotFoundException;
	import java.io.File;
	
	import de.unika.ipd.grgen.parser.*;
	import de.unika.ipd.grgen.ast.*;
	import de.unika.ipd.grgen.util.report.*;
	import de.unika.ipd.grgen.util.*;
	import de.unika.ipd.grgen.Main;
	
	import antlr.*;
	
}

class GRLexer extends Lexer;

options {
  charVocabulary = '\u0000'..'\u00FF';
	testLiterals=false;    // don't automatically test for literals
	k=8;                   // four characters of lookahead
	codeGenBitsetTestThreshold=20;
  exportVocab = GRBase;

}

tokens {
  TEST = "test";
  RULE = "rule";
  CLASS = "class";
  ACTIONS = "actions";
  USING = "using";
  MODEL = "model";
  NODE = "node";
  EDGE = "edge";
  PATTERN = "pattern";
  REPLACE = "replace";
  NEGATIVE = "negative";
  ENUM = "enum";
  ABSTRACT = "abstract";
  CONST = "const";
  EXTENDS = "extends";
  TRUE = "true";
  FALSE = "false";
  COND = "if";
  EVAL = "eval";
  TERM = "term";
  CONNECT = "connect";
  RETURN = "return";
  TYPEOF = "typeof";
  MODIFY = "modify";
  DELETE = "delete";
  HOM = "hom";
}

{
  GRParserEnvironment env;
  
  void setEnv(GRParserEnvironment env) {
    this.env = env;
  }
}


QUESTION		:	'?'		;
LPAREN			:	'('		;
RPAREN			:	')'		;
LBRACK			:	'['		;
RBRACK			:	']'		;
LBRACE			:	'{'		;
RBRACE			:	'}'		;
COLON			:	':'		;
COMMA			:	','		;
DOT 			:	'.'		;
ASSIGN			:	'='		;
EQUAL			:	"=="	;
NOT         	:	'!'		;
TILDE			:	'~'		;
NOT_EQUAL		:	"!="	;
SL			  : "<<" ;
SR 			  : ">>" ;
BSR       : ">>>" ;
DIV				:	'/'		;
PLUS			:	'+'		;
MINUS			:	'-'		;
STAR			:	'*'		;
MOD				:	'%'		;
GE				:	">="	;
GT				:	">"		;
LE				:	"<="	;
LT				:	'<'		;
RARROW    : "->"  ;
LARROW    : "<-"  ;
BXOR			:	'^'		;
BOR				:	'|'		;
LOR				:	"||"	;
BAND			:	'&'		;
LAND			:	"&&"	;
SEMI			:	';'		;
BACKSLASH : '\\'  ;

// Whitespace -- ignored
WS	:	(	' '
		|	'\t'
		|	'\f'
			// handle newlines
		|	(	options {generateAmbigWarnings=false;}
			:	"\r\n"  // Evil DOS
			|	'\r'    // Macintosh
			|	'\n'    // Unix (the right way)
			)
			{ newline(); }
		)+
		{ $setType(Token.SKIP); }
	;

SL_COMMENT
  :	"//" (~('\n'|'\r'))* ('\n'|'\r'('\n')?)
        {
			$setType(Token.SKIP);
			newline();
		}
	;

// multiple-line comments
ML_COMMENT
  :	"/*"
		(	/*	'\r' '\n' can be matched in one alternative or by matching
				'\r' in one iteration and '\n' in another.  I am trying to
				handle any flavor of newline that comes in, but the language
				that allows both "\r\n" and "\r" and "\n" to all be valid
				newline is ambiguous.  Consequently, the resulting grammar
				must be ambiguous.  I'm shutting this warning off.
			 */
			options {
				generateAmbigWarnings=false;
			}
		:
			{ LA(2)!='/' }? '*'
		|	'\r' '\n'		{newline();}
		|	'\r'			{newline();}
		|	'\n'			{newline();}
		|	~('*'|'\n'|'\r')
		)*
		"*/"
		{ $setType(Token.SKIP); }
  ;
  
NUM_DEC
	: ('0'..'9')+
	;
	
NUM_HEX
	: '0' 'x' ('0'..'9' | 'a' .. 'f' | 'A' .. 'F')+
	;
	
protected
ESC
	:	'\\'
		(	'n'
		|	'r'
		|	't'
		|	'b'
		|	'f'
		|	'"'
		|	'\''
		|	'\\')
		;
		
STRING_LITERAL
	:	'"' (ESC|~('"'|'\\'))* '"'
	;

INCLUDE
  : "include" WS s:STRING_LITERAL ';' {
  	$setType(Token.SKIP);
	String file = s.getText();
	file = file.substring(1,file.length()-1);
	env.pushFile(new File(file));
  }
  ;

IDENT
	options {testLiterals=true;}
	:	('a'..'z'|'A'..'Z') ('a'..'z'|'A'..'Z'|'_'|'0'..'9')*;
