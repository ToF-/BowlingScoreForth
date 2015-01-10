( Bowling.fs )

0 constant normal
2 constant spare
3 constant strike
4 constant double

: qualify ( last roll, roll -- status )
    + dup 20 = if strike 
     else 10 = if spare
     else normal then then ;

: factor ( status -- factor )
    2 / 1 + ;

: qualify_should_find_status_of_roll
    10 10 qualify assert( strike = ) 
     4  6 qualify assert( spare = )
     0 10 qualify assert( spare = )
     3  5 qualify assert( normal = ) ;

: factor_should_depend_on_status_of_roll
    normal assert( factor 1 = ) 
    spare  assert( factor 2 = )
    strike assert( factor 2 = )
    double assert( factor 3 = ) ;

qualify_should_find_status_of_roll
factor_should_depend_on_status_of_roll
bye
