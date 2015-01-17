In order to calculate the score of a game just after a roll, you need to know:  
* the current score,
* the bonus situation,
* the frame number,
* the last roll or an info that the frame is complete. 

Then there are 5 steps for each roll.  

###1 calculate the new score value
Using the bonus situation, the frame number and the roll value.

Possible bonus situations:  
* B00 : there is no bonus to add to the score, as the previous roll was not a *spare* or a *strike*.
* B10 : the roll should be added once, as the previous roll was a *spare* or the roll before was a *strike*
* B11 : the roll should be added once, and the next roll should too, as the previous roll was a *srtike* 
* B21 : the roll should be added twice, and the next roll will be added once, as the previous roll was a *double* 

After each roll, until the tenth frame is played, the roll is added to the score, then the bonus are added according to the bonus situation. After the tenth frame has been played, the rolls that come are added only as bonus rolls.  

###2 determine the type of the roll 
Depending on the last roll played, there are 4 different nature of rolls:  
* 1st roll : the roll knocked 0 to 9 pins, it was the first ball in the frame  
* strike : the roll knocked 10 pins, it was the first roll in the frame
* 2nd roll : the roll completes the frame, and the two rolls added make less than ten
* spare : the roll completes the frame, and the two rolls added make 10  

Thus the type of the roll is determined:

    last | roll || type
    -----+------++---------
     n-a | 10   || strike
     n-a | < 10 || 1st roll
      x  | 10-x || spare
      x  |<10-x || 2nd roll
   
###3 determine the new bonus situation
Given the current bonus situation, and the type of roll just played, the bonus status evolves (e.g a strike at the frame before now adds only one roll).
Also, after the tenth frame is played, bonus rolls don't make new bonus.

    status     | type     || new status
    B00 or B10 | 1st roll ||   B00
    B00 or B10 | 2nd roll ||   B00
    B00 or B10 | spare    ||   B10
    B00 or B10 | strike   ||   B11
    B11 or B21 | 1st roll ||   B10
    B11 or B21 | strike   ||   B21

(It is not possible to make a spare or a 2nd roll just after a strike or a double)
If the tenth frame has been played then the status evolves according to this table: 

    status     || new status
    B00 or B10 ||   B00
    B11 or B21 ||   B10

That is, only the bonus made on previous rolls are counted.

###4 update the last roll information
If the roll is the first in a frame, then its value is to be memorized, otherwise, it's discarded.

###5 increment the frame count
If the roll type is other than a 1st roll, and the frame number is not ten, then the frame is incremented.

