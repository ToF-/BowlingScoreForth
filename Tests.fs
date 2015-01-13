s" Bowling.fs" included

: tests

( start-game should push a score of 0 )
    start-game assert( score? 0= ) 
    end-game

( start-game should not have a bonus ) 
    start-game assert( bonus? 0= )
    end-game

( score? should extract score )
    start-game 123 score+
    assert( score? 123 = )
    end-game

( last-roll? should extract last roll )
    start-game 7 last-roll! assert( last-roll? 7 = )
    end-game

( score+ should update score )
    start-game 12 score+ 
    assert( score? 12 = )
    end-game

( bonus! should update bonus )
    start-game 1 bonus! assert( bonus? 1 = )
    end-game

( last-roll! should update last roll )
    start-game 4 last-roll! assert( last-roll? 4 = )
    end-game

( updates should presever states )
    start-game 4 last-roll! 6 score+ 1 bonus! 
    assert( last-roll? 4 = )
    assert( score? 6 = )
    assert( bonus? 1 = )
    end-game

( add-roll should update score )
    start-game 5 add-roll assert( score? 5 = ) 
    end-game

( add-roll should update last-roll )
    start-game 5 add-roll 2 add-roll assert( last-roll? 2 = )
    end-game

( add-roll should update bonus according to spare )
    start-game 5 add-roll assert( bonus? 0= )
    5 add-roll assert( bonus? )
    4 add-roll 3 add-roll assert( bonus? 0= )
    end-game

( add-roll should add roll twice after a spare )
    start-game 5 add-roll 5 add-roll 
    3 add-roll assert( score? 16 = )
    end-game

;

tests
.s
