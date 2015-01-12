s" Bowling.fs" included

: tests

( next-bonus should determine new status from previous status and roll quality )
    usual0 normal assert( next-bonus usual0 = ) 
    boni11 strike assert( next-bonus boni21 = )
    boni21 strike assert( next-bonus boni21 = )
    bonus1 normal assert( next-bonus usual0 = )

( in-frame? should be determined from status )
    0 assert( in-frame? 0= )
    255 end-frame assert( in-frame? 0= ) 
    0 in-frame assert( in-frame? )

( frame should keep track of frame number )
    24 assert( frame 8 = )
    24 frame++ assert( frame 9 = )

    0 next-frame assert( in-frame? 0= )
    0 next-frame assert( frame 1 = )

( last-roll keep track of last roll )
    24 6 keep-roll assert( last-roll 6 = )

( qualify qualifies type of roll )
    0 10 qualify assert( strike = )
    0 5  qualify assert( half = )
    0 in-frame 4 keep-roll 
    dup 6 qualify assert( spare = )
        5 qualify assert( normal = )

( update-bonus keep bonus in status )
    boni21 0 update-bonus assert( bonus boni21 = ) 

( factor calculate factor according to bonus situation and frame count)
    usual0 factor assert( 1 = )
    bonus1 factor assert( 2 = )
    boni11 factor assert( 2 = )
    boni21 factor assert( 3 = )

( roll-score given the bonus situation and frame number )
    boni21 0 update-bonus roll-score assert( 3 = )
    0 10 0 do frame++ loop
    boni21 swap update-bonus roll-score assert( 2 = ) 

;
tests .s

