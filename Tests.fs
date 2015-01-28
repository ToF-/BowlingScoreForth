\ Tests.fs

s" Bowling.fs" included

: tests
cr ." initial score should be zero "         
start-game score get assert( 0= ) 

cr ." adding a roll should increase score "
start-game 7 add-roll dup score get assert( 7 = )
           2 add-roll     score get assert( 9 = )

cr ." adding a roll should leave a track "
start-game  dup  track get assert( 11 = ) 
 7 add-roll dup  track get assert(  7 = )
 2 add-roll dup  track get assert( 11 = )
10 add-roll dup  track get assert( 11 = )
 5 add-roll      track get assert(  5 = )
;

hex
tests
cr .s
