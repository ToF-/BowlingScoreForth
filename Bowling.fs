\ Bowling.fs

: clear -1 xor and ; ( w -- w )

: get               ( word,mask,pos -- field )
    rot swap rshift swap and ;

: set               ( word,value,mask,pos -- word )
    rot over lshift >r 
    lshift clear r> or ;

: _score 511  0 ; ( -- mask,pos )
: _track 15   9 ; ( -- mask,pos )
: _bonus  7  13 ; ( -- mask,pos )
: _frame 15  16 ; ( -- mask,pos )

: score _score get ; ( game -- score )
: track _track get ; ( game -- track )
: bonus _bonus get ; ( game -- bonus )
: frame _frame get ; ( game -- frame )

: score! _score set ; ( game,v -- game )
: track! _track set ; ( game,v -- game )
: bonus! _bonus set ; ( game,v -- game )
: frame! _frame set ; ( game,v -- game )


: bonus-factor      ( game -- factor )
    bonus 3 and ;

: frame-factor      ( game -- factor )
    frame 10 / negate 1+ ;

: roll-score        ( roll,game -- score )
    dup  bonus-factor 
    swap frame-factor + * ;

: score+            ( game,roll -- game )
    over roll-score 
    over score +  score! ;

: close-frame    ( roll -- track )
    drop 11 ;

: track-1st-roll    ( roll -- track )
    dup 10 = if close-frame then ;

: track+            ( game,roll -- game )
    over track 11 = if 
    track-1st-roll else
    close-frame then track! ;  

0 constant first 
1 constant second
2 constant spare
3 constant strike

: roll-type         ( roll,game -- type )
    track 
    + dup 21 = if drop strike else 
      dup 10 = if drop spare  else
          10 < if      second else
                       first  then then then ; 

: next-bonus        ( game -- bonus )
    bonus 2 rshift ; 

: new-bonus         ( bonus,type -- bonus )
    dup strike = if drop 5 +  else
        spare  = if      1 or then then ;

: bonus+            ( game,roll -- game )
    over next-bonus 
    -rot over roll-type 
    over frame-factor * 
    rot swap new-bonus 
    bonus! ;

: frame+            ( game -- game )
    dup  frame
    over track
    11 = if 1+ 10 min then 
    frame! ;
  
: start-game        ( -- game )
    0 11 track! ;

: add-roll          ( game,roll -- game )
    tuck score+
    over bonus+
    swap track+
         frame+ ;  

: show-game         ( game -- )
    cr
    ."  frame: "  dup frame . 
    ."  bonus: "  dup bonus . 
    ."  track: "  dup track .
    ."  score: "      score . ;  
