( Bowling.fs )

0 constant normal
2 constant strike
 
: bonus ( r,f -- n )
    if 
        10 = if strike else normal then
    else 
        drop normal 
    then ;
        

: bonus_should_be_0_when_first_roll_and_not_strike
    4 true 
    bonus assert( 0= ) ;

: bonus_should_be_2_when_first_roll_and_strike
    10 true
    bonus assert( 2 = ) ;

bonus_should_be_0_when_first_roll_and_not_strike
bonus_should_be_2_when_first_roll_and_strike

bye
