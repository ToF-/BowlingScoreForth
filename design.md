In order to calculate the score of a game just after a roll, you need to know:

* the current score,
* the bonus situation,
* the frame number,
* the last roll or an info that the frame is complete. 

Then there are 6 steps for each roll:

###1 calculate the new score value, using the bonus situation, the frame number and the roll value

Possible bonus situations:

* B0 : there is no bonus
* B1 : there's a bonus of 1 (this just after a spare has been played, or 2 rolls after a strike has been played )
* B11: there's a bonus of 1 for this roll, and 1 for the next roll (this is just after a strike has been played)
* B21: there's a bonus of 2 for this roll, and 1 for the next roll (this is just after two strikes has been played)

The bonus factor are:

* B0 : 0
* B1 : 1
* B11: 1
* B21: 2

After the last frame (10), rolls that are played are added only in case of bonus, they don't count by themselves.
Thus if the frame is < 10, the value added to the score is : (bonus factor + 1) x roll value  
in the other case it is : bonus factor x roll value
 
###2 determine the quality of the roll, depending on the last roll played

If last roll is -1, the last roll was ending a frame

If last roll is different, the last roll should be add to this roll.

  | Tables   |      Are      |  Cool |
  |----------|:-------------:|------:|
  | col 1 is |  left-aligned | $1600 |
  | col 2 is |    centered   |   $12 |
  | col 3 is | right-aligned |    $1 |

  |Last Roll|Roll|Quality|
  |---------|----|-------|
  -1         10    Strike
  -1         <10   Half 
  x         10-x   Spare
  x           y    Normal

###3 determine the new bonus situation, given the current situation, and the quality of the roll

Situation   Quality           New situation
B0 or B1    Half or Normal       B0
B0 or B1    Strike               B11
B11 or B21  Half                 B1     (it's not possible to have a spare or a normal frame, in one roll just after a strike) 
B11 or B21  Strike               B21 
            
this can be codified into a transition table:

Situation  Half   Normal   Spare  Strike
  B0        B0      B0      B1     B11
  B1        B0      B0      B1     B11
  B11       B1      --      --     B21
  B21       B1      --      --     B21 

###4 update the last roll information
if the quality of the roll is a Half, the last roll value is replaced with the roll value, in other cases it's replaced with a flag -1

###5 increment the frame count





