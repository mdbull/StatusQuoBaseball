SELECT DISTINCT fielding.playerID, people.nameFirst, people.nameLast, fielding.POS,fielding.G, fielding.GS, fielding.InnOuts,fielding.PO, fielding.A, fielding.E, fielding.SB, fielding.CS
FROM people,fielding
WHERE people.playerID=fielding.PlayerID AND teamID='?' AND yearID=?
ORDER BY fielding.G DESC;
