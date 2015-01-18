( Bowling.fs )

0 constant first
1 constant second
2 constant spare
3 constant strike

15 constant new-frame

0 constant no-bonus
1 constant b-spare
5 constant b-strike
6 constant b-double

: factor   ( bonus -- n )  3 and ;
: in-game  ( frame -- f )  10 < ;
: all-down ( roll  -- f )  10 = ;

: score+ ( score,frame,bonus,roll -- score )
    swap factor
    rot in-game if 1+ then
    * + ;

: roll-type ( last,roll -- roll type )
    swap dup new-frame = if 
        drop all-down if strike else first then 
    else
        + all-down if spare else second then
    then ;

: next-bonus! ( bonus -- bonus ) 2 rshift ;
: spare!      ( bonus -- bonus ) 1 or ;
: strike!     ( bonus -- bonus ) 5 +  ;

: new-bonus ( bonus,type -- bonus )
    swap next-bonus!
    swap dup spare =  if drop spare!  
    else    strike =  if      strike!
    then then ; 

: last-roll! ( roll,type -- last-roll )
    first <> if drop new-frame then ;
    
: adjust-frame ( frame,last - frame )
    new-frame = if 1+ then ;

: get  ( w,i -- n )    2* 2* rshift 15 and ;        
: >nibble ( v,i -- v)  2* 2* lshift ; 
: mask ( w,i -- w )    15 swap >nibble -1 xor and ;
: store ( v,w,i -- w ) rot swap >nibble or ; 
: put ( v,w,i -- w )   dup rot swap mask swap store ;

0 constant bonus->
1 constant lastr->
2 constant frame-> 

: start-game ( -- score,status )
    0 new-frame 0 lastr-> put ;
    
: update-score ( score,status,roll -- score )
    swap  
    dup  frame-> get 
    swap bonus-> get 
    rot  score+  ;
0 variable pins
0 variable status
0 variable r-type

