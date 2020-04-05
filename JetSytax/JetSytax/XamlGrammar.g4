grammar XamlGrammar;

S : ('\t' | '\n' | ' ' | '\r')+ -> skip ;

Eq: '='
	;
OpenF: '{'
	;
CloseF: '}'
	;

XamlNameEl : NameStartChar(NameChar)* ;
NameStartChar : LetterChar  ; 
NameChar:  NameStartChar | '.'  (LetterChar)+ ; 
LetterChar: ('A'..'Z') | ('a'..'z') ; 

XamlAttributeName : ANameStartChar(ANameChar)* ; 
ANameStartChar : ALetterChar | '_' | ':' ;
ANameChar  : ANameStartChar | ('0' .. '9');
ALetterChar : ('A' .. 'Z') | ('a' .. 'z') ;


Value :(LetterCharValue)+ | OpenF ME  CloseF  ; 
LetterCharValue : ('A'..'Z') | ('a'..'z') | DigSpec;
DigSpec : ('0' .. '9') | ('0' .. '9') ',' ('0' .. '9') ; 


ME:  MEName (XamlNameEl Eq  Value )* ; 
MEName:  (LetterChar)+ ;

Attribute : (XamlAttributeName) Eq '"' (Value) '"' ;

Element : EmptyElemTag | STag  CharData? (Element)* ETag	;
STag : '<' XamlNameEl (S Attribute)* S? '>'	;
ETag : '</' XamlNameEl S? '>' ; 
CharData :  LetterCharValue ;
EmptyElemTag : '<' XamlNameEl (S Attribute)* S? '/>' ;
