s" Bowling.fs" included

: tests

( new-bonus should determine new status from previous status and roll quality )
    usual0 normal assert( new-bonus usual0 = ) 
    boni11 strike assert( new-bonus boni21 = )
    boni21 strike assert( new-bonus boni21 = )
    bonus1 normal assert( new-bonus usual0 = )

( set-bonus and get-bonus should store and retrieve bonus info )
    boni21 0 set-bonus assert( get-bonus boni21 = )

( set-frame and get-frame should store and retrieve frame number )
    7 0 set-frame assert( get-frame 7 = )

( in-frame? end-frame and in-frame should keep in-frame status )
    7 0 set-frame boni21 swap set-bonus
    dup in-frame  assert( in-frame? ) 
    end-frame assert( in-frame? 0 = ) 
    

;
tests .s

