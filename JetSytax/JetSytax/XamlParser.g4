parser grammar XamlParser;

options { tokenVocab=XamlLexer; }

content     :   chardata?
                ((element | COMMENT) chardata?)* ;

element     :   '<' Name attribute* '>' content '<' '/' Name '>'
            |   '<' Name S attribute* S? '/>'
            ;


attribute   :   Name '=' '"' STRING '"'
			| 	Name '=' '{' Name '=' STRING '}'
			; 							

chardata    :   TEXT | SEA_WS ;