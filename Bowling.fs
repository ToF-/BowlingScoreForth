( Bowling.fs )

0 constant usual0
1 constant bonus1
2 constant boni11
3 constant boni21

0 constant normal
1 constant spare
2 constant strike

create bonuses   ( usual0   bonus1   boni11   boni21 )
     ( normal )    usual0 , usual0 , bonus1 , bonus1 ,
     ( spare  )    bonus1 , bonus1 , bonus1 , bonus1 ,
     ( strike )    boni11 , boni11 , boni21 , boni21 ,

: quality-offset ( quality -- line-offset )
    4 cells * ;
: status-offset  ( bonus  -- col-offset )
    cells ;

: new-bonus ( bonus,quality -- bonus )
    quality-offset swap 
    status-offset + bonuses + @ ;

: get-bonus ( status -- bonus ) 
    5 rshift 3 and ;

: set-bonus ( bonus,status -- status )
    swap 5 lshift or ;

: get-frame ( status -- frame )
    15 and ;

: set-frame ( frame,status -- status )
    or ;

: in-frame? ( status -- flag )
    16 and ;

: end-frame ( status -- status )
    239 and ;

: in-frame ( status -- status )
    16 or ;



    
