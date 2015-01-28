\ Bowling.fs

: clear -1 xor and ; ( w -- w )

: get               ( word,size,pos -- field )
    rot swap rshift swap and ;

: set               ( word,value,size,pos -- word )
    rot over lshift >r 
    lshift clear r> or ;

: score 4095 0 ; ( -- size,pos )
: track 15  12 ; ( -- size,pos )
: bonus  7  16 ; ( -- size,pos )
: frame 15  19 ; ( -- size,pos )

: bonus-factor      ( game -- factor )
    bonus get 3 and ;

: frame-factor      ( game -- factor )
    frame get 10 / 1 swap - ;

: score+            ( game,roll -- game )
    over dup bonus-factor swap frame-factor + * 
    over score get + score set ;

: close-frame    ( roll -- track )
    drop 11 ;

: track-1st-roll    ( roll -- track )
    dup 10 = if close-frame then ;

: track!            ( game,roll -- game )
    over track get  
    11 = if track-1st-roll 
    else    close-frame then
    track set ;  

0 constant first 
1 constant second
2 constant spare
3 constant strike

: roll-type         ( roll,game -- type )
    track get 
    + dup 21 = if drop strike else 
      dup 10 = if drop spare  else
          10 < if second else
                  first 
    then then then ; 

: next-bonus        ( game -- bonus )
    bonus get 2 rshift ; 

: new-bonus         ( bonus,type -- bonus )
    dup strike = if drop 5 +  else
        spare  = if      1 or then then ;

: bonus!            ( game,roll -- game )
    over next-bonus -rot
    over roll-type 
    over frame-factor * 
    rot swap
    new-bonus bonus set ;

: frame!            ( game -- game )
    dup  frame get
    over track get
    11 = if 1+ 10 min then 
    frame set ;
  
: start-game        ( -- game )
    0 11 track set ;

: add-roll          ( game,roll -- game )
    swap over       ( roll,game,roll )
    score+          ( roll,game )
    over            ( roll,game,roll )
    bonus!          ( roll,game )
    swap track!     ( game )
    frame! ;        ( game )

: show-game         ( game -- )
    ."  frame: "  dup frame get . 
    ."  bonus: "  dup bonus get . 
    ."  track: "  dup track get .
    ."  score: "      score get . ;  
