SELECT *
FROM people,pitching
WHERE people.playerID=pitching.PlayerID AND teamID='?' AND yearID=?;
