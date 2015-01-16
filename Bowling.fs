( Bowling.fs )

0 constant half
1 constant normal
2 constant spare
3 constant strike 

0 constant B00 
1 constant B10
2 constant B11
3 constant B21

-1 constant end-frame

variable score
variable bonus
variable frame
variable last-roll

create factors  
( B00 )  0 ,
( B10 )  1 ,
( B11 )  1 ,
( B21 )  2 ,

create next-bonus 
           ( half  normal spare strike )
  ( B00 )    B00 , B00 ,  B10 , B11 ,
  ( B10 )    B00 , B00 ,  B10 , B11 ,
  ( B11 )    B10 ,  -1 ,   -1 , B21 ,
  ( B21 )    B10 ,  -1 ,   -1 , B21 ,

: start-game
    0 score ! 
    0 frame ! 
    B00 bonus !
    end-frame last-roll ! ;

: in-game 
    frame @ 10 < ;

: frame-factor ( n -- n ) 
    in-game if 1+ then ;

: update-score ( n -- )
    factors bonus @ cells + @
    in-game if 1+ then 
    * score +! ; 

: new-frame 
    last-roll @ end-frame = ;

: all-down ( n -- f )
    10 = ;

: 1st-roll ( n -- q )
    all-down if 
        strike 
    else 
        half
    then ;

: 2nd-roll ( n -- q )
    last-roll @ +
    all-down if 
        spare
    else
        normal
    then ; 

: qualify-roll ( n -- q )
    new-frame if 1st-roll else 2nd-roll then ;

: quality ( n -- q )
    in-game if qualify-roll else drop half then ;

: bonus-row ( b -- offset )
    4 cells * + ;

: quality-col ( offset,q -- offset )
    cells ;

: update-bonus ( q -- )
    quality-col
    bonus @ bonus-row 
    next-bonus +
    @ bonus ! ;

: update-frame ( n,q -- )
    half <> if 1 frame +! 
               drop end-frame 
            then
    last-roll ! ;

: update-last-roll ( n,q -- )
    half <> if drop end-frame then
    last-roll ! ;

: add-roll ( n -- )
    dup update-score
    dup quality
    dup update-bonus 
    update-frame ;




