lexer grammar ParamFileLexer;

@header {namespace DZConfigTools.Core.Generated;}

SINGLE_LINE_COMMENT: '//' ~[\r\n]*           -> channel(HIDDEN);
EMPTY_DELIMITED_COMMENT: ('/*/' | '/**/')    -> channel(HIDDEN);
DELIMITED_COMMENT: '/*' .*? '*/'             -> channel(HIDDEN);
PREPROCESSOR_DIRECTIVE: '#' ~[\r\n]*         -> channel(HIDDEN)/*-> mode(PREPROC_MODE)*/;
WHITESPACES: [\r\n \t]                       -> channel(HIDDEN);

Class:              'class';
Delete:             'delete';
Add_Assign:         '+=';
Assign:             '=';
LSBracket:          '[';
RSBracket:          ']';
LCBracket:          '{';
RCBracket:          '}';
Semicolon:          ';';
Colon:              ':';
Comma:              ',';
DoubleQuote:        '"';

LiteralString: '"' (EnforceEscapeSequence | .)*? '"';
LiteralInteger: Number;
LiteralFloat: DecimalNumber | ScientificNumber;

fragment EnforceEscapeSequence: '\\\\' | '\\"' | '\\\'';
fragment Diget: [0-9];
fragment Number: '-'? Diget+;
fragment DecimalNumber:  Number ('.' Diget+)?;
fragment ScientificNumber: DecimalNumber Scientific DecimalNumber;
fragment Scientific: ('e'|'E') ('+'|'-');