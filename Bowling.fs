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

0 constant first
1 constant second
2 constant spare
3 constant strike

: roll-type ( last,roll -- type )
    +    dup 25 = if drop strike
    else dup 10 = if drop spare 
    else     10 < if second
    else             first 
    then then then ; 

0 constant no-bonus
1 constant spare-bonus
4 1 or constant strike-bonus 
4 2 or constant double-bonus

: next-bonus ( bonus -- bonus )
    2 rshift ;

: frame-factor ( frame -- 1|0 )
    10 / 1  swap - ;

: add-roll-bonus ( bonus,type -- bonus )
    dup strike = if drop strike-bonus + 
    else spare = if spare-bonus or 
    then then ; 

: roll-bonus ( frame,bonus,last,roll -- bonus )
        roll-type 
    rot frame-factor *
    swap next-bonus
    swap add-roll-bonus ;

: current-bonus ( bonus -- bonus )
    3 and ;

: roll-score ( frame,bonus,roll -- n )
    swap current-bonus  
    rot  frame-factor  +  *  ;

: start-game ( -- score,state )
    0 initial ;

: state-roll-score ( roll,state -- n )
    dup frame .@ swap bonus .@ rot roll-score ; 
 
: add-roll ( score,state,roll -- score,state )
    over state-roll-score
    rot + swap
    ;
