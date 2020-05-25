SELECT playerID, nameFirst, nameLast, bats, throws, weight, height, birth_date
FROM people
WHERE playerID IN (
    SELECT playerID 
    FROM pitching
    WHERE teamID='?' AND yearID=?
);
