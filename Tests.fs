s" Bowling.fs" included

: tests

( new-status should determine new status from previous status and roll quality )
    usual0 normal assert( new-status usual0 = ) 
    boni11 strike assert( new-status boni21 = )
    boni21 strike assert( new-status boni21 = )
    bonus1 normal assert( new-status usual0 = )
;
tests .s

