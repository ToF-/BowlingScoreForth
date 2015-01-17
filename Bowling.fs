( Bowling.fs )

0 constant first
1 constant second
2 constant spare
3 constant strike

15 constant end-frame

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

: last-roll! ( st,n -- ~st )
    8 lshift  swap 255 not and  or ;

: last-roll ( st -- lr )
    8 rshift 15 and ;

: 1st-roll-type ( n -- rt )
    10 = if strike else first then ;

: 2nd-roll-type ( n -- rt )
    10 = if spare else second then ;
   
: roll-type ( st,r -- rt )
    swap last-roll dup 
    end-frame  = if drop 1st-roll-type 
    else + 2nd-roll-type then ;


: add-roll ( st,sc,n -- st,sc )
    rot dup factor 
    rot *          
    rot + ; 

