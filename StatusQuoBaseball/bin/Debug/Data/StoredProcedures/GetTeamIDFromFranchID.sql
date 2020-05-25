SELECT teams.teamID,teamsfranchises.franchName FROM  teams,teamsfranchises where teams.franchID=teamsfranchises.franchID AND teams.franchID = '?' AND yearID=?
