s" Bowling.fs" included

: equals ( result,expected -- f )
    2dup <> if
        ." assertion failed: expected " . ." but was " . cr ~~
    else
        2drop true
    then ;

: tests

0  frame !  in-game assert( 1 equals )
10 frame !  in-game assert( 0 equals )

5 bonus !   current-bonus assert( 1 equals )
6 bonus !   current-bonus assert( 2 equals )
6 bonus !   next-bonus assert( 1 equals )

5 bonus !  3 frame !  5 factor assert( 10 equals )
6 bonus !  3 frame !  5 factor assert( 15 equals )

end-frame  10 roll-type  assert( strike equals )
end-frame  10 roll-type drop  last-roll @ assert( new-frame equals )
end-frame   9 roll-type  assert( first  equals ) 
end-frame   4 roll-type drop last-roll @ assert( 4 equals ) 

4 last-roll ! 6  roll-type assert( spare equals ) 
4 last-roll ! 6  roll-type drop last-roll @ assert( new-frame equals )

0 bonus ! spare new-bonus assert( 1 equals )
5 bonus ! strike new-bonus assert( 6 equals )
10 frame !
0 bonus ! spare new-bonus assert( 0 equals )
5 bonus ! strike new-bonus assert( 1 equals )

0 frame !
4 last-roll !  adjust-frame  frame @ assert( 0 equals )
end-frame  adjust-frame frame @ assert( 1 equals )

10 frame !
end-frame  adjust-frame frame @ assert( 10 equals )
; 
tests
~~

