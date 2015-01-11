
<<<<<<< Updated upstream
previous roll            : factor
0: normal                : 1
2: spare / strike+normal : 2
3: strike                : 2
4: double strike         : 3

: factor 2 / 1+ ;


previous roll            : rollst: next status
0: normal                : normal: normal
0: normal                : spare : spare / strike + normal 
0: normal                : strike: strike
1: spare / strike+normal : normal: normal
1: spare / strike+normal : spare : IMPOSSIBLE
1: spare / strike+normal : strike: strike
2: strike                : normal: strike+normal
2: strike                : spare : IMPOSSIBLE
2: strike                : strike: double strike
3: double strike         : normal: strike+normal
3: double strike         : spare : IMPOSSIBLE
3: double strike         : strike: double strike

1st roll : last : roll : rollst
  1         x      10  : strike
  1         x     <10  : normal
  0         x      y   | x+y == 10 : spare
  0         x      y   | x+y < 10  : normal


    



=======
the bowling state includes:
- frame number
- last roll or 10 if the frame is complete
- bonus 

>>>>>>> Stashed changes

0 0 0 0

 
