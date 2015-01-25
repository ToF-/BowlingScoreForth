s" Bowling.fs" included

: equals ( result,expected -- f )
    2dup <> if
        ~~ ." assertion failed: expected " . ." but was " . cr 
    else
        2drop true
    then ;

: nr no-roll ;

: tests

initial assert( bonus get 0 equals )
initial assert( frame get 0 equals )
initial assert( track get no-roll equals )

7 0 frame     set  assert( frame     get 7 equals )
4 0 track set  assert( track get 4 equals )
5 0 bonus     set  assert( bonus     get 5 equals )

nr  9 mark-track assert(  9 equals )
nr 10 mark-track assert( nr equals )
 6  4 mark-track assert( nr equals )
 5  4 mark-track assert( nr equals )

 0 nr new-frame assert( 1 equals )
 0  5 new-frame assert( 0 equals )
10 nr new-frame assert( 10 equals )

nr 10 roll-type assert( strike equals )
nr  9 roll-type assert( first  equals )
 2  8 roll-type assert( spare  equals )
 2  7 roll-type assert( second equals )

0 no-bonus     nr 0 roll-bonus assert( no-bonus equals )
0 spare-bonus  nr 0 roll-bonus assert( no-bonus equals )
0 strike-bonus nr 0 roll-bonus assert( spare-bonus equals )
0 double-bonus nr 0 roll-bonus assert( spare-bonus equals )

0 no-bonus     nr 10 roll-bonus assert( strike-bonus equals )
0 spare-bonus  nr 10 roll-bonus assert( strike-bonus equals ) 
0 strike-bonus nr 10 roll-bonus assert( double-bonus equals ) 

0 no-bonus     6  4  roll-bonus assert( spare-bonus  equals )

10 spare-bonus  nr 10 roll-bonus assert( no-bonus equals ) 
10 strike-bonus nr 10 roll-bonus assert( spare-bonus equals ) 

5 0 no-bonus     roll-score assert( 5  equals )
5 0 spare-bonus  roll-score assert( 10 equals )
5 0 strike-bonus roll-score assert( 10 equals )
5 0 double-bonus roll-score assert( 15 equals )

5 10 no-bonus     roll-score assert( 0  equals )
5 10 spare-bonus  roll-score assert( 5  equals )
5 10 strike-bonus roll-score assert( 5  equals )
5 10 double-bonus roll-score assert( 10 equals )

start-game assert( score 0 equals ) 
start-game assert( initial equals )

initial
strike-bonus swap bonus set 
1  swap frame set
15 swap track set
dup 10 swap >roll-score assert( 20 equals )
dup 10 >roll-bonus assert( double-bonus equals )
dup 10 >mark-track assert( 15 equals )
    15 >new-frame assert( 2 equals )

start-game 10 add-roll assert( score 10 equals )
start-game 10 add-roll assert( frame get 1 equals )
start-game 10 add-roll assert( bonus get strike-bonus equals )
start-game 10 add-roll assert( track get 15 equals )


start-game 12 0 do 10 add-roll loop assert( score 300 equals )  
start-game 20 0 do 4 add-roll  loop assert( score 20 4 * equals )  
; 
hex
tests
~~

