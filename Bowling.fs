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

: adjust-frame ( frame,last - frame )
    new-frame = if 1+ then ;

: last-roll! ( roll,type -- last-roll )
    first <> if drop new-frame then ;
    
