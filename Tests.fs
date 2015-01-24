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


; 
tests
~~

