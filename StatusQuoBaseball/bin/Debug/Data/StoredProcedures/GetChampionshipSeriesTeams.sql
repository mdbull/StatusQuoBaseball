SELECT yearID,
       round,
       teamIDwinner,
       teamIDloser
  FROM seriespost
  WHERE yearID=? AND round LIKE'?%'
