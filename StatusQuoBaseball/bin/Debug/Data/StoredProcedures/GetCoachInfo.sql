SELECT people.playerID, people.nameFirst, people.nameLast, people.bats, people.throws, people.weight, people.height, people.birth_date, people.death_date, managers.playerID, managers.yearID, managers.teamID, managers.G, managers.W, managers.L, managers.teamRank 
FROM people, managers
WHERE managers.teamID='?' AND managers.yearID = ? AND managers.playerID = people.playerID AND people.playerID IN(
    SELECT managers.PlayerID
    from managers
ORDER BY managers.G DESC
);
