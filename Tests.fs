s" Bowling.fs" included

: equals ( result,expected -- f )
    2dup <> if
        ." assertion failed: expected " . ." but was " . cr
    else
        2drop true
    then ;

: tests
( start-game initialize score and status )
start-game assert( 0 equals ) drop

( add-roll increases score )
start-game 5 add-roll 4 add-roll assert( 9 equals ) drop

( add-roll takes bonus into account )
start-game swap 1 bonus! swap 4 add-roll assert( 8 equals ) drop
start-game swap 2 bonus! swap 4 add-roll assert( 12 equals ) drop

( add-roll takes frame number into account )
start-game swap 10 frame! 1 bonus! swap 4 add-roll assert( 4 equals ) drop 

( roll-type is determined by last-roll and roll )
0 new-frame last-roll! 10 roll-type assert( strike equals ) 
0 new-frame last-roll!  9 roll-type assert( first  equals ) 
0         5 last-roll!  5 roll-type assert( spare  equals ) 
0         5 last-roll!  4 roll-type assert( second equals ) 

( new bonus is determined by last bonus and roll type )
start-game  4 add-roll drop assert( bonus 0 equals )
start-game 10 add-roll drop assert( bonus 5 equals )

; 
tests
.s
