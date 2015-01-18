s" Bowling.fs" included

: equals ( result,expected -- f )
    2dup <> if
        ." assertion failed: expected " . ." but was " . cr
    else
        2drop true
    then ;

: tests

cr ." roll is added to score " 
( score frame bonus roll            --  new score )
   100    0  no-bonus 5  score+ assert( 105 equals ) 

cr ." score takes bonus into account "
( score frame bonus roll            --  new score )
   100    0  b-spare  2  score+ assert( 104 equals )
   100    0  b-strike 3  score+ assert( 106 equals )
   100    0  b-double 4  score+ assert( 112 equals )

cr ." roll is added only as bonus to score if frame = 10 "
( score frame bonus roll           --  new score )
   100   10  b-spare  5  score+ assert( 105 equals ) 
   100   10  b-double 3  score+ assert( 106 equals )
   100   10  no-bonus 4  score+ assert( 100 equals )

cr ." roll type is calculated with last-roll and roll value "
(  last   roll                -- roll-type )
new-frame   4  roll-type assert( first  equals )
new-frame  10  roll-type assert( strike equals )
    5       4  roll-type assert( second equals )
    5       5  roll-type assert( spare  equals )

cr ." new bonus depends on previous bonus and roll type "
(  bonus   type                  -- new bonus )
  no-bonus first  new-bonus assert( no-bonus equals )
  b-spare  first  new-bonus assert( no-bonus equals )
  b-strike first  new-bonus assert( b-spare  equals )
  no-bonus spare  new-bonus assert( b-spare  equals )
  no-bonus strike new-bonus assert( b-strike equals )
  b-spare  strike new-bonus assert( b-strike equals )
  b-strike strike new-bonus assert( b-double equals )
  b-double strike new-bonus assert( b-double equals )

cr ." adjusting last roll depends on roll and roll type "
( roll  type                    -- new last-roll )
   10   first  last-roll!  assert( 10 equals )   
   10   strike last-roll!  assert( new-frame equals )   
    5   spare  last-roll!  assert( new-frame equals )   
    4   second last-roll!  assert( new-frame equals )

cr ." adjusting frame depends on last-roll "
( frame,last                       -- new frame )
    0   5        adjust-frame assert( 0 equals )  
    5  new-frame adjust-frame assert( 6 equals )  

cr ." status word stores frame,last-roll,bonus "
   6 4807 bonus-> put assert( bonus-> get 6 equals ) 
   8 4807 frame-> put assert( frame-> get 8 equals )  
   9 4807 lastr-> put assert( lastr-> get 9 equals )

cr ." start-game creates a null score and initial bonus "
start-game assert( bonus-> get no-bonus equals )  drop
start-game assert( frame-> get 0 equals )         drop
start-game assert( lastr-> get new-frame equals ) drop

cr ." updating score of a current game "
start-game 10 update-score assert( 10 equals ) 
start-game 6 swap bonus-> put 10 update-score assert( 30 equals )
; 
tests
