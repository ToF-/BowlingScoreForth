( Bowling.fs )

 
-1 constant n-a
0 constant normal
1 constant spare
2 constant strike
3 constant double

create factors 1 , 2 , 2 , 3 , 

create statuses ( normal    spare   strike  )
 ( normal )         normal ,  spare , strike , 
 ( spare  )         normal ,  n-a   , strike , 
 ( strike )         normal ,  n-a   , double , 
 ( double )         strike ,  n-a   , double ,


: qualify ( last roll or 10, roll -- status )
    + dup 20 = if drop strike 
     else 10 = if spare
     else normal then then ;

: factor ( status -- factor )
    factors swap cells + @ ;

: score ( score,status,roll -- score )
    swap factor * + ;

: new-status ( status,quality -- status )
    swap 3 cells *
    swap cells + statuses + @ ;

