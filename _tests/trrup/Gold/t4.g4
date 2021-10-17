grammar t4;
p : '+=' | '?=' ;
p : '+=' | '?=' ;
p : '+=' | '?=' ;
p : a ( '+=' | '?=' ) ;
p : a ( '+=' | '?=' ) ;
p : a ( '+=' | '?=' ) ;
a : a'a' a;
a : a'a'? a;
a :'a' b;
a : ('a' b)?;
a : c 'a' b d;
a : e ( 'a' | b) f;
a : ('=>' |'->' )?;
d :a b | c;
d : (a b | c)?;
d : x (a b | c) y;
assignment : ( '=>' | '->' ) ? validID ( '+=' | '=' | '?=' ) assignableTerminal ;
