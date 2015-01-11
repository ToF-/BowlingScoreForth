s" Bowling.fs" included

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

( encode should encode frame, status and last roll in one value )
    1 1 1 encode assert( 256 16 1 + +  = )
    1 2 9 encode assert( 256 32 9 + +  = )

( decode should decode frame, status and last roll from one value )
    256 32 9 + + decode assert( 9 = swap 2 = and swap 1 = and )
;
tests .s

