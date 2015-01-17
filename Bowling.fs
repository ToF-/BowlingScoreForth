( Bowling.fs )

: start-game ( -- st,sc )
    0 0 ;

: bonus ( st -- b )
    3 and ;

: frame ( st -- fr )
    4 rshift 15 and ; 

: not ( n -- n ) 
    -1 xor ;

: bonus! ( st,b -- ~st )
    swap  3 not and  or ; 

: frame! ( st,fr -- ~st )
    4 lshift  swap 240 not and  or ;
 
: in-game ( st -- f )
    frame 10 < ;

: factor ( st -- n )
    dup bonus
    swap in-game if 1+ then ;

: add-roll ( st,sc,n -- st,sc )
    rot dup factor 
    rot *          
    rot + ; 

