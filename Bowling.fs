\ Bowling.fs

: clear -1 xor and ; ( w -- w )

: get               ( word,mask,pos -- field )
    rot swap rshift swap and ;

: set               ( word,value,mask,pos -- word )
    rot over lshift >r 
    lshift clear r> or ;

: score 511  0 ; ( -- mask,pos )
: track 15   9 ; ( -- mask,pos )
: bonus  7  13 ; ( -- mask,pos )
: frame 15  16 ; ( -- mask,pos )

: bonus-factor      ( game -- factor )
    bonus get 3 and ;

: frame-factor      ( game -- factor )
    frame get 10 / negate 1+ ;

: roll-score        ( roll,game -- score )
    dup  bonus-factor 
    swap frame-factor + * ;

: score+            ( game,roll -- game )
    over roll-score 
    over score get + 
    score set ;

: close-frame    ( roll -- track )
    drop 11 ;

: track-1st-roll    ( roll -- track )
    dup 10 = if close-frame then ;

: track!            ( game,roll -- game )
    over track get  
    11 = if track-1st-roll else close-frame then
    track set ;  

0 constant first 
1 constant second
2 constant spare
3 constant strike

: roll-type         ( roll,game -- type )
    track get 
    + dup 21 = if drop strike else 
      dup 10 = if drop spare  else
          10 < if      second else
                       first  then then then ; 

: next-bonus        ( game -- bonus )
    bonus get 2 rshift ; 

: new-bonus         ( bonus,type -- bonus )
    dup strike = if drop 5 +  else
        spare  = if      1 or then then ;

: bonus!            ( game,roll -- game )
    over next-bonus 
    -rot over roll-type 
    over frame-factor * 
    rot swap new-bonus 
    bonus set ;

: frame!            ( game -- game )
    dup  frame get
    over track get
    11 = if 1+ 10 min then 
    frame set ;
  
: start-game        ( -- game )
    0 11 track set ;

: add-roll          ( game,roll -- game )
    swap over score+
    over      bonus!
    swap      track!
              frame! ;  

: show-game         ( game -- )
    ."  frame: "  dup frame get . 
    ."  bonus: "  dup bonus get . 
    ."  track: "  dup track get .
    ."  score: "      score get . ;  
