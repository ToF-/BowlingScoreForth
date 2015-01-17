( Bowling.fs )

0 constant first
1 constant second
2 constant spare
3 constant strike 

0 constant no-bonus 
1 constant bonus1-0
2 constant bonus1-1
3 constant bonus2-1

-1 constant end-frame

variable score
variable bonus
variable frame
variable last-roll

create bonus-factor  
( no-bonus )  0 ,
( bonus1-0 )  1 ,
( bonus1-1 )  1 ,
( bonus2-1 )  2 ,

create next-bonus 
           ( first      second      spare      strike )
( no-bonus ) no-bonus , no-bonus ,  bonus1-0 , bonus1-1 ,
( bonus1-0 ) no-bonus , no-bonus ,  bonus1-0 , bonus1-1 ,
( bonus1-1 ) bonus1-0 ,  -1      ,   -1      , bonus2-1 ,
( bonus2-1 ) bonus1-0 ,  -1      ,   -1      , bonus2-1 ,

: start-game
    0 score !  no-bonus bonus !
    0 frame !  end-frame last-roll ! ;

: in-game ( -- f )
    frame @ 10 < ;

: update-score ( n -- )
    bonus-factor bonus @ cells + @
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

: bonus-row ( b -- offset )
    4 cells * + ;

: roll-type-col ( offset,q -- offset )
    cells ;

: update-bonus ( q -- )
    roll-type-col
    bonus @ bonus-row 
    next-bonus +
    @ bonus ! ;

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




