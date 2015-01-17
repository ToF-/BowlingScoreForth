s" Bowling.fs" included

: equals ( result,expected -- f )
    2dup <> if
        ." assertion failed: expected " . ." but was " . cr
    else
        2drop true
    then ;

: tests

( after start-game score should be 0 )
start-game assert( score @ 0 equals )

( update-score calculates new score depending on roll, bonus and frame )
start-game no-bonus bonus !  3 add-roll assert( score @ 3 equals )
start-game bonus1-0 bonus !  4 add-roll assert( score @ 8 equals )
start-game bonus1-1 bonus !  5 add-roll assert( score @ 10 equals )
start-game bonus2-1 bonus !  6 add-roll assert( score @ 18 equals )

( roll type depends on last-roll and roll )
start-game 
end-frame last-roll ! 5  assert( roll-type first equals ) 
end-frame last-roll ! 10 assert( roll-type strike equals ) 
5 last-roll ! 5  assert( roll-type spare equals ) 
5 last-roll ! 3  assert( roll-type second equals ) 
0 last-roll ! 10 assert( roll-type spare equals ) 

( new bonus depends on bonus and roll type )
start-game  no-bonus bonus !  3 add-roll  assert( bonus @ no-bonus equals )
start-game  bonus1-0 bonus !  3 add-roll  assert( bonus @ no-bonus equals )
start-game  no-bonus bonus ! 10 add-roll  assert( bonus @ bonus1-1 equals )
start-game  bonus2-1 bonus !  0 add-roll  assert( bonus @ bonus1-0 equals )
start-game  bonus2-1 bonus ! 10 add-roll  assert( bonus @ bonus2-1 equals )

( add-roll update frame depending on roll type )
start-game 4  add-roll assert( frame @ 0 equals )
           4  add-roll assert( frame @ 1 equals )
           10 add-roll assert( frame @ 2 equals )
           3  add-roll assert( frame @ 2 equals )
           7  add-roll assert( frame @ 3 equals ) 

( after 10th frame, rolls dont count as score, only bonus )
start-game 10 frame ! bonus2-1 bonus ! 5 add-roll assert( score @ 10 equals )

( after 10th frame, strike don't generate bonus )
start-game 10 frame ! bonus2-1 bonus ! 10 assert( roll-type first equals )
start-game 10 frame ! bonus2-1 bonus ! 10 add-roll assert( bonus @ bonus1-0 equals )
( after 10th frame, frame doesn't increment )
start-game 10 frame ! 10 add-roll 10 add-roll 10 add-roll 
assert( frame @ 10 equals )

( a perfect )
start-game 12 0 do 10 add-roll loop assert( score @ 300 equals  )

( spares )
start-game 10 0 do 5 add-roll 5 add-roll loop 5 add-roll
assert( score @ 150 equals )

( a random test )
    
 ;
tests
.s
