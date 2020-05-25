SELECT playerID, nameFirst, nameLast, bats, throws, weight, height, birth_date, death_date
FROM people
WHERE playerID IN (
   SELECT playerID 
   FROM batting
   WHERE teamID='?' AND yearID=?
);
