SELECT ID,
       playerID,
       awardID,
       yearID,
       lgID,
       tie,
       notes
  FROM awardsmanagers
  WHERE playerID LIKE '%?%'
