
###information available:
score  : current score ( 0 .. 300 )  
frame  : current frame number ( 0..10 )  
track  : last roll | frame complete  ( 0..9 | 11 )  
bonus  : current bonus factor    ( 000|001|101|110 )   
roll   : roll just thrown ( 0 .. 10 )  

###calculating the new score :

score' = score + roll * bonus-factor + frame-factor  
bonus-factor = bonus % 4   
frame-factor = 1 - (frame / 10)   

###calculating the new bonus :

bonus' = roll-type = strike ? last-bonus + 5 : roll-type = spare ? last-bonus || 1 : last-bonus   
last-bonus = bonus / 4  
roll-type = frame-factor * (track + roll = 21 ? strike : track + roll = 10 ? spare : track + roll < 10 ? second : first)  
first  = 0  
second = 1    
spare  = 2  
strike = 3  

###calculating the new track :
track' = track+roll = 21 ? 11 : track+roll > 10 ? roll : 11   

###calculating the new frame :
frame' = track = 11 ? min(10,frame + 1) : frame   

