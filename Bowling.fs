\ Bowling.fs

\ in this first version, we can add rolls and get the score
\ no bonus for special rolls, no frame limit

: start-game        ( -- game )
    0 ;

: score             ( game -- score )
    ;

: add-roll          ( game,roll -- game )
     + ;
