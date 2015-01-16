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
    start-game B00 bonus !  3 add-roll assert( score @ 3 equals )
    start-game B10 bonus !  4 add-roll assert( score @ 8 equals )
    start-game B11 bonus !  5 add-roll assert( score @ 10 equals )
    start-game B21 bonus !  6 add-roll assert( score @ 18 equals )

( quality depends on last-roll and roll )
    start-game 
    end-frame last-roll ! 5  assert( quality half equals ) 
    end-frame last-roll ! 10 assert( quality strike equals ) 
    5 last-roll ! 5  assert( quality spare equals ) 
    5 last-roll ! 3  assert( quality normal equals ) 
    0 last-roll ! 10 assert( quality spare equals ) 

( new bonus depends on bonus and quality )
    start-game  B00 bonus !  3 add-roll  assert( bonus @ B00 equals )
    start-game  B10 bonus !  3 add-roll  assert( bonus @ B00 equals )
    start-game  B00 bonus ! 10 add-roll  assert( bonus @ B11 equals )
    start-game  B21 bonus !  0 add-roll  assert( bonus @ B10 equals )
    start-game  B21 bonus ! 10 add-roll  assert( bonus @ B21 equals )

( add-roll update frame depending on quality )
    start-game 4  add-roll assert( frame @ 0 equals )
               4  add-roll assert( frame @ 1 equals )
               10 add-roll assert( frame @ 2 equals )
               3  add-roll assert( frame @ 2 equals )
               7  add-roll assert( frame @ 3 equals ) 

( after 10th frame, rolls dont count as score, only bonus )
    start-game 10 frame ! B21 bonus ! 5 add-roll assert( score @ 10 equals )

( after 10th frame, strike don't generate bonus )
    start-game 10 frame ! B21 bonus ! 10 assert( quality half equals )
    start-game 10 frame ! B21 bonus ! 10 add-roll assert( bonus @ B10 equals )
( after 10th frame, frame doesn't increment )
    start-game 10 frame ! 10 add-roll 10 add-roll 10 add-roll 
    assert( frame @ 10 equals )
    

( a perfect )
    start-game 10 0 do 10 add-roll loop assert( score @ 270 equals  )
    assert( bonus @ B21 equals )
    10 add-roll
    assert( score @ 290 equals )
    assert( bonus @ B10 equals )
    10 add-roll
    assert( score @ 300 equals )

( spares )
    start-game 10 0 do 5 add-roll 5 add-roll loop 5 add-roll
    assert( score @ 150 equals )

( a random test )
    
 ;
tests
.s
