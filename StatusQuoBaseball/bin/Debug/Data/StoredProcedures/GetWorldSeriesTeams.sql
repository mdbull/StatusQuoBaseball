SELECT yearID,
       teamIDwinner,
       teamIDloser
  FROM seriespost
  WHERE yearID=? AND round='WS';
