s" Bowling.fs" included

: equals ( result,expected -- f )
    2dup <> if
        ." assertion failed: expected " . ." but was " . cr 
    else
        2drop true
    then ;

: tests

 9 15 mark-frame assert(  9 equals )
10 15 mark-frame assert( 15 equals )
4   6 mark-frame assert( 15 equals )
4   5 mark-frame assert( 15 equals )

 0 15 new-frame assert( 1 equals )
 0  5 new-frame assert( 0 equals )
10 15 new-frame assert( 10 equals )

7 0 .frame .! assert( .frame .@ 7 equals )

4 0 .lastr .! assert( .lastr .@ 4 equals )

5 0 .bonus .! assert( .bonus .@ 5 equals )
 


; 
tests
~~

