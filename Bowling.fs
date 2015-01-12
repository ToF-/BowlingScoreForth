( Bowling.fs )

0 constant usual0
1 constant bonus1  
2 constant boni11
3 constant boni21

0 constant half
1 constant normal
2 constant spare
3 constant strike

create bonuses   ( usual0   bonus1   boni11   boni21 )
     ( half   )    usual0 , usual0 , bonus1 , bonus1 ,
     ( normal )    usual0 , usual0 , bonus1 , bonus1 ,
     ( spare  )    bonus1 , bonus1 , bonus1 , bonus1 ,
     ( strike )    boni11 , boni11 , boni21 , boni21 ,

: quality-offset ( quality -- line-offset )
    4 cells * ;
: status-offset  ( bonus  -- col-offset )
    cells ;

: next-bonus ( bonus,quality -- bonus )
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

: last-roll ( status -- n )
    5 rshift ;

: keep-roll ( status,roll -- status )
    5 lshift swap 31 and or ;

: qualify-second ( roll,status -- quality )
    last-roll + 
    10 = if spare else normal then ;

: qualify-first ( roll,status -- quality )
    drop 10 = if strike else half then ;

: qualify ( status,roll -- quality )
    swap dup
    in-frame? if qualify-second else qualify-first then ;

: bonus ( status -- bonus )
    8 rshift 3 and ;

: update-bonus ( bonus,status -- bonus )
    255 and swap 8 lshift or ;

: bonus-factor ( bonus -- n )
    dup  boni21 = if drop 3 
    else usual0 = if 1
    else 2 then then ;

: factor ( status -- n )
    dup bonus bonus-factor 
    swap frame 10 >= if 1- then ;

: roll-score ( status,roll -- n )
    swap factor * ;

: add-score ( score,status,roll -- score )
    roll-score + ;

: update-status ( status,roll -- status )
    over swap qualify 
    over bonus swap next-bonus 
    swap update-bonus ;

        


