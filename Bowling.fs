( Bowling.fs )
 
: 1st-roll ( s r -- s f)
    dup 10 = -rot 
    +        swap ;

: 1st-roll-is-added-to-score
    48                  ( current score ) 
    4 1st-roll 
    drop                ( end-frame )
    assert( 52 = ) ;

: 1st-roll-end-frames-if-a-strike
    0 ( current score )
    10 1st-roll
    assert(  ) ;


 
1st-roll-is-added-to-score
1st-roll-end-frames-if-a-strike

bye
