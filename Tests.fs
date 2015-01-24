s" Bowling.fs" included

: equals ( result,expected -- f )
    2dup <> if
        ." assertion failed: expected " . ." but was " . cr 
    else
        2drop true
    then ;

: nr no-roll ;

: tests

initial assert( bonus .@ 0 equals )
initial assert( frame .@ 0 equals )
initial assert( prev-roll .@ no-roll equals )

7 0 frame     .!  assert( frame     .@ 7 equals )
4 0 prev-roll .!  assert( prev-roll .@ 4 equals )
5 0 bonus     .!  assert( bonus     .@ 5 equals )

nr  9 mark-prev-roll assert(  9 equals )
nr 10 mark-prev-roll assert( nr equals )
 6  4 mark-prev-roll assert( nr equals )
 5  4 mark-prev-roll assert( nr equals )

 0 nr new-frame assert( 1 equals )
 0  5 new-frame assert( 0 equals )
10 nr new-frame assert( 10 equals )

nr 10 roll-type assert( strike equals )
nr  9 roll-type assert( first  equals )
 2  8 roll-type assert( spare  equals )
 2  7 roll-type assert( second equals )

no-bonus     nr 0 roll-bonus assert( no-bonus equals )
spare-bonus  nr 0 roll-bonus assert( no-bonus equals )
strike-bonus nr 0 roll-bonus assert( spare-bonus equals )
double-bonus nr 0 roll-bonus assert( spare-bonus equals )

no-bonus     nr 10 roll-bonus assert( strike-bonus equals )
spare-bonus  nr 10 roll-bonus assert( strike-bonus equals ) 
strike-bonus nr 10 roll-bonus assert( double-bonus equals ) 

no-bonus     6  4  roll-bonus assert( spare-bonus  equals )
; 
tests
~~

