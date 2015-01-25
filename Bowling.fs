( Bowling.fs )

15 constant no-roll
10 constant all-down
no-roll all-down + constant strike-roll

: mark-track ( last,roll -- last )
    + dup dup
    strike-roll =  swap all-down <=  or 
    if drop no-roll  else no-roll - then ; 

: new-frame ( frame,last -- frame )
    no-roll = if 1+ 10 min then ;

4 constant field-size
1 field-size lshift 1- constant mask

: >field ( v -- w ) field-size * lshift ;
: field> ( w -- w ) field-size * rshift ;

2 constant frame
1 constant track
0 constant bonus

: set ( value,state,n -- state )
    >r mask r@ >field -1 xor and swap r> >field or ;  

: get ( state,n -- value )
    field> mask and ;

: initial ( -- state )
    no-roll 0 track set
    0 swap bonus set 
    0 swap frame set ;

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

: roll-score ( roll,frame,bonus -- n )
    current-bonus  
    swap frame-factor  + * ;

: start-game ( -- state )
    initial ;

: >roll-score ( roll,state -- n )
    dup frame get swap bonus get roll-score ;

: >roll-bonus ( state,roll -- bonus )
    >r 
    dup frame get
    swap dup bonus get
    swap track get
    r> roll-bonus ; 

: >mark-track ( state,roll -- last )
    swap track get swap mark-track ;

: >new-frame ( state,track -- frame )
    swap frame get
    swap new-frame ;

: score ( state -- score )
    12 rshift ;   

: add-score ( state,n -- state )
    swap over score + 
    12 lshift 
    swap 16773120 -1 xor and or ;

: add-roll ( state,roll -- state )
    2dup swap >roll-score            ( state,roll,n )
    rot add-score swap          ( state,roll ) 
    2dup >roll-bonus -rot       ( b,state,roll )
    over swap >mark-track swap  ( b,t,state )
    2dup                        ( b,t,state,t,state )
    swap >new-frame swap        ( b,t,f,state )
    frame set                   ( b,t,state )
    track set                   ( b,state )
    bonus set ;                 ( state )

