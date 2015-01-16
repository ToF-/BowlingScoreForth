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

create next-bonus  ( half   normal   spare   strike  )
  ( B00 )            B00 ,  B00 ,  B10 , B11 ,
  ( B10 )            B00 ,  B00 ,  B10 , B11 ,
  ( B11 )            B10 ,   -1 ,   -1 , B21 ,
  ( B21 )            B10 ,   -1 ,   -1 , B21 ,

: start-game
    0 score ! 
    0 frame ! 
    B00 bonus !
    end-frame last-roll ! ;

: frame-factor ( n -- n ) 
    frame @ 10 < if 1+ then ;

: update-score ( n -- )
    factors bonus @ cells + @
    frame-factor * score +! ; 

: quality ( n -- )
    last-roll @ end-frame = if 
        10   = if strike else half then
    else
        last-roll @ + 10 = if spare else normal then
    then 
    frame @ 9 > if drop half then ;

: update-bonus ( q -- )
    next-bonus bonus @ 4 cells * + swap cells + @ bonus ! ;

: update-frame ( n,q -- )
    half <> if 1 frame +! 
               drop end-frame 
            then
    last-roll ! ;

: update-last-roll ( n,q -- )
    half <> if drop end-frame then
    last-roll ! ;

: add-roll ( n -- )
    dup dup update-score
            quality
    dup update-bonus 
    update-frame 
;




