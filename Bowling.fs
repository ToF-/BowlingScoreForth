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

: update-bonus ( bonus,quality -- bonus )
    quality-offset swap 
    status-offset + bonuses + @ ;

1 4 lshift constant -in-frame

: not -1 xor ;

: in-frame? ( status -- flag )
    -in-frame and ;

: end-frame ( status -- status )
    -in-frame not and ;

: in-frame ( status -- status )
    -in-frame or ;

: frame ( status -- n )
    15 and ;

: frame++ ( status -- status )
    dup frame 1+ swap 15 not and or ;    

: next-frame ( status -- status )
    end-frame frame++ ;
