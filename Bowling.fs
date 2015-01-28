\ Bowling.fs

: clear -1 xor and ; ( w -- w )
    

: get               ( word,size,pos -- field )
    rot swap rshift swap and ;

: set               ( word,value,size,pos -- word )
    rot over lshift >r 
    lshift clear r> or ;

: score 4095 0 ; ( -- size,pos )
: track 15  12 ; ( -- size,pos )

: score+            ( game,roll -- game )
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

: start-game        ( -- game )
    0 11 track set ;

: add-roll          ( game,roll -- game )
    swap over
    score+ 
    swap track! ;
