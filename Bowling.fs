( Bowling.fs )

0 constant first 
1 constant second
2 constant spare
3 constant strike
  variable frame
  variable bonus
  variable last-roll
  variable new-frame

: in-game       ( -- 1|0 )   frame @ 10 < 1 and ;
: current-bonus ( -- 0|1|2 ) bonus @ 3 and ;
: next-bonus    ( -- 0|1 )   bonus @ 2 rshift ;
: roll-score    ( roll -- n ) current-bonus in-game + * ;
: end-frame! true new-frame ! ;
: in-frame! false new-frame ! ;
: all-down      ( n -- f)    10 = ;
: spare!  ( b -- b )  1 or ;
: strike! ( b -- b )  5 + ;
 
: 1st-roll-type ( roll -- t )
    dup all-down if drop end-frame!  strike
    else     last-roll !  in-frame!  first 
    then ;

: 2nd-roll-type ( roll,last -- t )
    + all-down if spare else second then
    end-frame! ;

: roll-type ( roll -- t )
    new-frame @ if 1st-roll-type 
    else last-roll @ 2nd-roll-type then ;

: roll-bonus ( type,b -- b )
    swap dup spare = if  drop spare!
    else    strike = if strike!
    then then  ;
    
: new-bonus ( type -- b )
    next-bonus 
    in-game if roll-bonus else swap drop then ; 

: adjust-frame 
    in-game new-frame @ and  if 1 frame +! then ;

: start-game ( -- score )
    0 bonus !  0 frame !  end-frame!  0 ;

: add-roll ( score,roll -- score )
    swap over roll-score +
    swap roll-type new-bonus bonus !
    adjust-frame ;
     

