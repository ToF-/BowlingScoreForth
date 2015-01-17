( Bowling.fs )

0 constant first
1 constant second
2 constant spare
3 constant strike 

-1 constant end-frame

variable score
variable bonus
variable frame
variable last-roll

: bonus-factor ( n -- n )
    3 and ;

: start-game
    0 score !
    0 bonus !
    0 frame !  end-frame last-roll ! ;

: in-game ( -- f )
    frame @ 10 < ;

: update-score ( n -- )
    bonus @ bonus-factor 
    in-game if 1+ then
    * score +! ;

: new-frame ( -- f )
    last-roll @ end-frame = ;

: all-down ( n -- f )
    10 = ;

: 1st-roll ( n -- q )
    all-down if strike else first then ;

: 2nd-roll ( n -- q )
    last-roll @ +
    all-down if spare else second then ; 

: qualify-roll ( n -- q )
    new-frame if 1st-roll else 2nd-roll then ;

: roll-type ( n -- q )
    in-game if qualify-roll else drop first then ;

: update-bonus ( q -- )
    dup strike = if drop bonus @ 4 and if 6 else 5 then
    else dup spare = if drop 1 
    else drop bonus @ 2 rshift then then 
    bonus ! ;
 
: update-frame ( n,q -- )
    first <> if 1 frame +! 
               drop end-frame 
            then
    last-roll ! ;

: update-last-roll ( n,q -- )
    first <> if drop end-frame then
    last-roll ! ;

: add-roll ( n -- )
    dup update-score
    dup roll-type
    dup update-bonus
    update-frame ;


