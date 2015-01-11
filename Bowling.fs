( Bowling.fs )

0 constant usual0
1 constant bonus1
2 constant boni11
3 constant boni21

0 constant normal
1 constant spare
2 constant strike

create statuses  ( usual0   bonus1   boni11   boni21 )
     ( normal )    usual0 , usual0 , bonus1 , bonus1 ,
     ( spare  )    bonus1 , bonus1 , bonus1 , bonus1 ,
     ( strike )    boni11 , boni11 , boni21 , boni21 ,

: quality-offset ( quality -- line-offset )
    4 cells * ;
: status-offset  ( status  -- col-offset )
    cells ;

: new-status ( status,quality -- status )
    quality-offset swap 
    status-offset + statuses + @ ;
    
