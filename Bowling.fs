\ Bowling.fs

: clear             ( w -- w )
    -1 xor and ;

: get               ( word,size,pos -- word )
    rot swap rshift swap and ;

: set               ( word,value,size,pos -- word )
    rot over lshift >r 
    lshift clear r> or ;

: score       ( -- size,pos )
    4095 0 ;

: track       ( -- size,pos )
    15  12 ;

: score+            ( game,roll -- game )
    over score get + score set ;

: track-2nd-roll    ( roll -- track )
    drop 11 ;

: track-1st-roll    ( roll -- track )
    dup 10 = if track-2nd-roll then ;

: track!            ( game,roll -- game )
    over track get  
    11 = if track-1st-roll 
    else    track-2nd-roll then
    track set ;  

: start-game        ( -- game )
    0 11 track set ;

: add-roll          ( game,roll -- game )
    swap over
    score+ 
    swap track! ;
