\ Tests.fs

s" Bowling.fs" included

: tests
cr ." initial score should be zero "         
start-game score assert( 0= ) 

cr ." adding a roll should increase score "
start-game 7 add-roll score assert( 7 = )

cr ." after 10 frames rolls don't increase score "
start-game 20 0 do 4 add-roll loop 
5 add-roll score assert( 80 = )

;

tests
cr .s
