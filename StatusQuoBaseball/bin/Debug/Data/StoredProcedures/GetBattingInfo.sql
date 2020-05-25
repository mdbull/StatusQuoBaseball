SELECT *
FROM people,batting
WHERE people.playerID=batting.PlayerID AND teamID='?' AND yearID=?;
