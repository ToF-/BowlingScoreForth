( Bowling.fs )

0 constant first
1 constant second
2 constant spare
3 constant strike

15 constant new-frame

: bonus ( st -- b )
    7 and ;

: frame ( st -- fr )
    4 rshift 15 and ; 

: not ( n -- n ) 
    -1 xor ;

: bonus! ( st,b -- ~st )
    swap  7 not and  or ; 

: frame! ( st,fr -- ~st )
    4 lshift  swap 240 not and  or ;
 
: in-game ( st -- f )
    frame 10 < ;

: factor ( st -- n )
    dup bonus
    swap in-game if 1+ then ;

: last-roll! ( st,n -- ~st )
    8 lshift  swap 255 not and  or ;

: last-roll ( st -- lr )
    8 rshift 15 and ;

: all-down ( n - f )
    10 = ;

: 1st-roll-type ( n -- rt )
    all-down if strike else first then ;

: 2nd-roll-type ( n -- rt )
    all-down if spare else second then ;
   
: roll-type ( st,r -- rt )
    swap last-roll dup 
    new-frame  = if 
        drop 1st-roll-type 
    else 
        + 2nd-roll-type 
    then ;

: score! ( st,sc,n -- st,sc )
    rot dup factor
    rot *
    rot + ;

: next-bonus ( st,n -- st )
    over swap roll-type   ( st,rt )
    over bonus 2 rshift   ( st,rt,b )
    swap  
    dup  strike = if
        drop 5 +
    else spare  = if 
        drop 1 
    then then 
    bonus! ;

: start-game ( -- st,sc )
    0 new-frame last-roll!
    0 ;

: add-roll ( st,sc,n -- st,sc )
    dup >r   
    score!  
    swap r>
    next-bonus swap ;
