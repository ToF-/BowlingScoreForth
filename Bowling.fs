( Bowling.fs )

0 constant first 
1 constant second
2 constant spare
3 constant strike

16 constant new-frame
variable frame
variable bonus
variable last-roll

: in-game ( -- 1|0 )
    frame @ 10 < 1 and ;

: c-bonus ( -- 0|1|2 )
    bonus @ 3 and ;

: factor ( roll -- n )
    c-bonus in-game + * ;

: end-frame
    new-frame last-roll ! ;
   
: all-down 
    10 = ;
 
: 1st-roll-type ( roll -- t )
    dup all-down if drop strike end-frame 
    else last-roll ! first then ;


: 2nd-roll-type ( roll,last -- t )
    + all-down if spare else second then
    end-frame ;

: roll-type ( roll -- t )
    last-roll @ dup new-frame and 
    if drop 1st-roll-type else 2nd-roll-type then ;


