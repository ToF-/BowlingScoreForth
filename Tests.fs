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
    usual0 bonus-factor assert( 1 = )
    bonus1 bonus-factor assert( 2 = )
    boni11 bonus-factor assert( 2 = )
    boni21 bonus-factor assert( 3 = )

( bonus-factor given the bonus situation and frame number )
    boni21 0 update-bonus factor assert( 3 = )
    0 10 0 do frame++ loop
    boni21 swap update-bonus factor assert( 2 = ) 

( roll-score calculate score for the roll )
    bonus1 0 update-bonus 10 roll-score assert( 20 = )
    boni21 0 update-bonus 7 roll-score assert( 21 = )

( add-score update score with a roll )
    100 boni21 0 update-bonus 7 add-score assert( 121 = )

( add-roll update frame if not in-frame )
    0 10 update-status assert( frame 1 = ) 
    0 5  update-status assert( frame 0 = )

( update-status set new bonus situation according to quality )
    0 10 update-status assert( bonus boni11 = )   

( add-roll update score, bonus and frame ) 
    start-game 5 add-roll assert( bonus usual0 = swap 5 = and ) 
    start-game 10 add-roll assert( bonus boni11 = swap 10 = and ) 
    start-game 10 add-roll
               3  add-roll assert( bonus bonus1 = swap 16 = and )

    start-game 10 add-roll
               3  add-roll
               6  add-roll assert( bonus usual0 = swap 28 = and )
    start-game 10 add-roll
               10 add-roll
               10 add-roll .s 
;
tests .s

