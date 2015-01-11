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

: tests
( qualify should find quality of roll )
    10 10 qualify assert( strike = ) 
     4  6 qualify assert( spare = )  
     0 10 qualify assert( spare = )  
     3  5 qualify assert( normal = ) 

( factor should depend on quality of roll )
    normal assert( factor 1 = ) 
    spare  assert( factor 2 = )
    strike assert( factor 2 = )
    double assert( factor 3 = ) 

( score should update score depending on status )
    100 normal 5 assert( score 105 = )
    100 spare  5 assert( score 110 = )
    100 strike 5 assert( score 110 = )
    100 double 5 assert( score 115 = )

( new-status should update status depending on satus and quality )
    normal normal assert( new-status normal = )
    normal spare  assert( new-status spare  = )
    normal strike assert( new-status strike = )
    spare  normal assert( new-status normal = )
    spare  strike assert( new-status strike = )
    strike normal assert( new-status normal = )
    strike strike assert( new-status double = )
    double normal assert( new-status strike = )
    double strike assert( new-status double = )

;
tests .s


bye
