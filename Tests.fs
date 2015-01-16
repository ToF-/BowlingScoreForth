s" Bowling.fs" included

: tests

( after start-game score should be 0 )
start-game assert( score @ 0 = )

( update-score calculates new score depending on roll, bonus and frame )
    start-game B00 bonus !  3 add-roll assert( score @ 3 = )
    start-game B10 bonus !  4 add-roll assert( score @ 8 = )
    start-game B11 bonus !  5 add-roll assert( score @ 10 = )
    start-game B21 bonus !  6 add-roll assert( score @ 18 = )

( quality depends on last-roll and roll )
    start-game 
    end-frame last-roll ! 5  assert( quality half = ) 
    end-frame last-roll ! 10 assert( quality strike = ) 
    5 last-roll ! 5  assert( quality spare = ) 
    5 last-roll ! 3  assert( quality normal = ) 
    0 last-roll ! 10 assert( quality spare = ) 

( new bonus depends on bonus and quality )
    start-game  B00 bonus !  3 add-roll  assert( bonus @ B00 = )
    start-game  B10 bonus !  3 add-roll  assert( bonus @ B00 = )
    start-game  B00 bonus ! 10 add-roll  assert( bonus @ B11 = )
    start-game  B21 bonus !  0 add-roll  assert( bonus @ B10 = )
    start-game  B21 bonus ! 10 add-roll  assert( bonus @ B21 = )

( add-roll update frame depending on quality )
    start-game 4  add-roll assert( frame @ 0 = )
               4  add-roll assert( frame @ 1 = )
               10 add-roll assert( frame @ 2 = )
               3  add-roll assert( frame @ 2 = )
               7  add-roll assert( frame @ 3 = ) 

( after 10th frame, rolls dont count as score and no more bonus )
    start-game 10 frame ! B21 bonus ! 5 add-roll assert( score @ 5 = )

( a perfect )
    start-game 12 0 do 10 add-roll loop assert( score @ 300 =  )
 ;
tests
.s
