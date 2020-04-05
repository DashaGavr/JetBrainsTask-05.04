lexer grammar XamlLexer;


COMMENT     :   '<!--' .*? '-->' ;

SEA_WS      :   (' '|'\t'|'\r'? '\n')+ ;

OPEN        :   '<' ;

TEXT        :   ~[<&]+ ;        // match any 16 bit char other than < and &

CLOSE       :   '>'  ;

EQUALS      :   '=' ;

STRING      :   '"' ~[<"]* '"'
            |   '\'' ~[<']* '\''
            ;

Name        :   NameStartChar NameChar* ;
S           :   [ \t\r\n]               -> skip ;

fragment
DIGIT       :   [0-9] ;

fragment
NameChar    :   NameStartChar
            |   '-' | '_' | '.' | DIGIT
            |   '\u00B7'
            |   '\u0300'..'\u036F'
            |   '\u203F'..'\u2040'
            ;

fragment
NameStartChar
            :   [:a-zA-Z]
            |   '\u2070'..'\u218F'
            |   '\u2C00'..'\u2FEF'
            |   '\u3001'..'\uD7FF'
            |   '\uF900'..'\uFDCF'
            |   '\uFDF0'..'\uFFFD'
            ;
