\ Tests.fs

s" Bowling.fs" included

: tests
cr ." initial score should be zero "         
start-game score assert( 0= ) 

cr ." adding a roll should increase score "
start-game 7 add-roll score assert( 7 = )

;

tests
cr .s
