( calculating bowling score )

( FEDCBA9876543210 
                 b
             last
)

: not ( n -- ~n ) 
    -1 xor ;
: bonus? ( score,status -- score,status,flag )
    dup 1 and ;

: bonus! ( score,status,f -- score,~status )
    1 and 
    swap 1 not and 
    or ;

: score? ( score,status -- score,status,score )
    over ; 

: score+ ( score,status,n -- ~score,status )
    rot + swap ;

: last-roll? ( score, status -- score,status,last )
    dup 1 rshift 15 and ;

: last-roll! ( score,status,n -- score,~status )
    1 lshift swap 
    30 not and
    or ;
    
: start-game ( -- score,status  )
    0 0 ; 

: end-game ( score,status -- )
    2drop ;

: spare? ( last,roll -- f )
    + 10 = ;

: factor ( flag,roll -- roll*2 or roll  )
    swap if 2 * then ;
 
: add-roll ( score,status,roll -- ~score,~status ) 
    >r 
    bonus? r@ factor
    score+ 
    last-roll? r@
    spare? bonus! 
    r> last-roll! ;


    

    
