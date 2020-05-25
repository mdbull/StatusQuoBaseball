SELECT franchID,
       franchName,
       active,
       NAassoc
  FROM teamsfranchises
  WHERE franchID IN(
SELECT franchID from teams where name LIKE '?%' AND yearID=?);
