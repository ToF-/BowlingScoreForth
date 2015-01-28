\ Tests.fs

s" Bowling.fs" included

: tests

cr ." setting a field to zero "
11 3 clear assert( 8 = ) 

cr ." getting a field "
11 3 2 get assert( 2 = )

cr ." setting a field "
11 3 3 2 set assert( 15 = )

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

cr ." a spare should generate bonus "
start-game  4 add-roll 6 add-roll bonus get assert( 1 = )

cr ." a strike should generate bonus "
start-game 10 add-roll bonus get assert( 5 = )

cr ." after a strike a bonus should remain "
start-game 10 add-roll 4 add-roll bonus get assert( 1 = )

cr ." two strikes should generate bonus "
start-game 10 add-roll 10 add-roll bonus get assert( 6 = )

cr ." score takes existing bonus into account "
start-game 10 add-roll 5 add-roll score get assert( 20 = )

cr ." adding rolls increase frame "
start-game 3 add-roll dup frame get assert( 0 = )
           3 add-roll dup frame get assert( 1 = )  
          10 add-roll     frame get assert( 2 = ) 

cr ." after 10 frames roll don't add to score " 
start-game 10 frame set 5 add-roll score get assert( 0 = ) 

cr ." after 10 frame strikes don't make bonus "
start-game 10 frame set 10 add-roll bonus get assert( 0 = ) 

cr ." a perfect game scores 300 "
start-game 12 0 do 10 add-roll loop score get assert( 300 = )

cr ." an average game add all rolls without bonus "
start-game 20 0 do 1 add-roll loop score get assert( 20 = )
;


hex
tests
cr .s
