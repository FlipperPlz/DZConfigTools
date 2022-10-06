﻿parser grammar ParamFileParser;

@header {namespace DZConfigTools.Core.Generated;}

options { tokenVocab=ParamFileLexer; }

computationalStart: statement*;

statement: 
    deleteStatement           Semicolon        |
    arrayAppension            Semicolon        |
    arrayTruncation           Semicolon        |
    arrayDeclaration          Semicolon        |
    tokenDeclaration          Semicolon        |
    classDeclaration          Semicolon        |
    externalClassDeclaration  Semicolon        ;

arrayAppension: arrayName Add_Assign literalArray;
arrayTruncation: arrayName Sub_Assign literalArray;
deleteStatement: Delete identifier;

externalClassDeclaration: Class classname=identifier;
classDeclaration: Class classname=identifier (Colon superclass=identifier)? LCBracket statement* RCBracket;
arrayDeclaration: arrayName Assign value=literalArray;
tokenDeclaration: tokenName=identifier Assign value=literal;

literalArray: LCBracket (literalOrArray (Comma literalOrArray)* Comma?)? RCBracket;
literalString: LiteralString;
literalInteger: LiteralInteger;
literalFloat: LiteralFloat;

literalOrArray: literal | literalArray;
literal: literalString | literalInteger | literalFloat;

arrayName: identifier LSBracket RSBracket;
identifier: Identifier;