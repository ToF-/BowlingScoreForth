s" Bowling.fs" included

: equals ( result,expected -- f )
    2dup <> if
        ." assertion failed: expected " . ." but was " . cr 
    else
        2drop true
    then ;

: tests

initial assert( .bonus .@ 0 equals )
initial assert( .frame .@ 0 equals )
initial assert( .lastr .@ no-roll equals )

7 0 .frame .! assert( .frame .@ 7 equals )
4 0 .lastr .! assert( .lastr .@ 4 equals )
5 0 .bonus .! assert( .bonus .@ 5 equals )

15  9 mark-frame assert(  9 equals )
15 10 mark-frame assert( 15 equals )
 6  4 mark-frame assert( 15 equals )
 5  4 mark-frame assert( 15 equals )

 0 15 new-frame assert( 1 equals )
 0  5 new-frame assert( 0 equals )
10 15 new-frame assert( 10 equals )


; 
tests
~~

