SELECT DISTINCT people.playerID,batting.playerID,batting.G,batting.teamID,batting.yearID,batting.AB,batting.H,batting."2B",batting."3B",batting.HR,batting.CS,batting.HBP,batting.IBB,batting.SO,batting.SB,batting.SO,batting.RBI,batting.R,batting.BB,batting.SF,batting.SH
FROM people,batting 
WHERE people.playerID=batting.playerID AND teamID='NYA' AND yearID=2018
ORDER BY batting.G DESC