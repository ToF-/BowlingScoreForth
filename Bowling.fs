( Bowling.fs )

15 constant no-roll
10 constant all-down
no-roll all-down + constant strike-roll

: mark-prev-roll ( last,roll -- last )
    + dup dup
    strike-roll =  swap all-down <=  or 
    if drop no-roll  else no-roll - then ; 

: new-frame ( frame,last -- frame )
    no-roll = if 1+ 10 min then ;

4 constant field-size
1 field-size lshift 1- constant mask

: >field ( v -- w ) field-size * lshift ;
: field> ( w -- w ) field-size * rshift ;

0 constant prev-roll
1 constant frame
2 constant bonus

: .! ( value,state,n -- state )
    >r mask r@ >field -1 xor and swap r> >field or ;  

: .@ ( state,n -- value )
    field> mask and ;

: initial ( -- state )
    no-roll 0 prev-roll .!
    0 swap bonus .! 
    0 swap frame .! ;

