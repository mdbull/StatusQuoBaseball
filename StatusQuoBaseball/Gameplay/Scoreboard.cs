using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Base;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Gameplay
{
    /// <summary>
    /// Inning score.
    /// </summary>
    [Serializable]
    public class InningScore
    {
        private int topScore;
        private int bottomScore;

        private int topHits;
        private int bottomHits;

        private int topErrors;
        private int bottomErrors;

        /// <summary>
        /// Gets or sets the top score.
        /// </summary>
        /// <value>int</value>
        public int TopScore { get => topScore; set => topScore = value; }

        /// <summary>
        /// Gets or sets the bottom score.
        /// </summary>
        /// <value>int</value>
        public int BottomScore
        {
            get => bottomScore;
            set => bottomScore = value; 
        }

        /// <summary>
        /// Gets or sets the top hits.
        /// </summary>
        /// <value>int</value>
        public int TopHits { get => topHits; set => topHits = value; }

        /// <summary>
        /// Gets or sets the bottom hits.
        /// </summary>
        /// <value>int</value>
        public int BottomHits { get => bottomHits; set => bottomHits = value; }

        /// <summary>
        /// Gets or sets the top errors.
        /// </summary>
        /// <value>int</value>
        public int TopErrors { get => topErrors; set => topErrors = value; }

        /// <summary>
        /// Gets or sets the bottom errors.
        /// </summary>
        /// <value>int</value>
        public int BottomErrors { get => bottomErrors; set => bottomErrors = value; }
    }

    /// <summary>
    /// Scoreboard.
    /// </summary>
    [Serializable]
    public class Scoreboard
    {
        private Game game;
        private int currentInningIndex;
        private List<InningScore> inningScores = new List<InningScore>();
        private InningScore currentInningScore;
        private Team roadTeam;
        private Team homeTeam;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Gameplay.Scoreboard"/> class.
        /// </summary>
        /// <param name="game">Game.</param>
        /// <param name="roadTeam">Road team.</param>
        /// <param name="homeTeam">Home team.</param>
        public Scoreboard(Game game, Team roadTeam, Team homeTeam)
        {
            this.game = game;

            this.roadTeam = roadTeam;
            this.homeTeam = homeTeam;
        }

        /// <summary>
        /// Adds the inning.
        /// </summary>
        public void AddInning()
        {
            this.currentInningScore = new InningScore();
            this.inningScores.Add(this.currentInningScore);
        }

        /// <summary>
        /// Adds the inning score.
        /// </summary>
        /// <param name="scoringTeam">Scoring team.</param>
        public void AddInningScore(Team scoringTeam)
        {
            if (scoringTeam == roadTeam)
            {
                this.currentInningScore.TopScore++;
            }
            else
                this.currentInningScore.BottomScore++;
        }

        /// <summary>
        /// Adds the bottom of inning not played.
        /// </summary>
        public void AddBottomOfInningNotPlayed()
        {
            this.currentInningScore.BottomScore = -1;
        }

        /// <summary>
        /// Adds the inning hit.
        /// </summary>
        /// <param name="battingTeam">Batting team.</param>
        public void AddInningHit(Team battingTeam)
        {
            if (battingTeam == roadTeam)
            {
                this.currentInningScore.TopHits++;
            }
            else
                this.currentInningScore.BottomHits++;
        }

        /// <summary>
        /// Adds the inning error.
        /// </summary>
        /// <param name="fieldingTeam">Fielding team.</param>
        public void AddInningError(Team fieldingTeam)
        {
            if (fieldingTeam == roadTeam)
            {
                this.currentInningScore.TopErrors++;
            }
            else
                this.currentInningScore.BottomErrors++;
        }

        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>Game</value>
        public Game Game { get => game; set => game = value; }

        /// <summary>
        /// Gets or sets the index of the current inning.
        /// </summary>
        /// <value>int</value>
        public int CurrentInningIndex { get => currentInningIndex; set => currentInningIndex = value; }

        /// <summary>
        /// Gets the road team.
        /// </summary>
        /// <value>Team</value>
        public Team RoadTeam { get => roadTeam; }

        /// <summary>
        /// Gets the home team.
        /// </summary>
        /// <value>Team</value>
        public Team HomeTeam { get => homeTeam; }

        /// <summary>
        /// Gets the team runs.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="team">Team</param>
        private int GetTeamRuns(Team team)
        {
            int totalRuns = 0;
            foreach (InningScore inning in inningScores)
            {
                if (team == roadTeam)
                    totalRuns += inning.TopScore;
                else
                {
                    if (inning.BottomScore >= 0)//don't show the -1 marker for the bottom of last inning not played
                        totalRuns += inning.BottomScore;
                }
            }
            return totalRuns;
        }

        /// <summary>
        /// Gets the team errors.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="team">Team</param>
        private int GetTeamErrors(Team team)
        {
            int totalErrors = 0;
            foreach (InningScore inning in inningScores)
            {
                if (team == roadTeam)
                    totalErrors += inning.TopErrors;
                else
                    totalErrors += inning.BottomErrors;
            }
            return totalErrors;
        }

        /// <summary>
        /// Gets the team hits.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="team">Team</param>
        private int GetTeamHits(Team team)
        {
            int totalHits = 0;
            foreach (InningScore inning in inningScores)
            {
                if (team == roadTeam)
                    totalHits += inning.TopHits;
                else
                    totalHits += inning.BottomHits;
            }
            return totalHits;
        }

        /// <summary>
        /// Gets the road team score.
        /// </summary>
        /// <value>int</value>
        public int RoadTeamScore
        {
            get { return GetTeamRuns(this.roadTeam); }
        }

        /// <summary>
        /// Gets the road team hits.
        /// </summary>
        /// <value>int</value>
        public int RoadTeamHits
        {
            get => GetTeamHits(this.roadTeam);
        }

        /// <summary>
        /// Gets the road team errors.
        /// </summary>
        /// <value>int</value>
        public int RoadTeamErrors
        {
            get => GetTeamErrors(this.roadTeam);
        }

        /// <summary>
        /// Gets the home team score.
        /// </summary>
        /// <value>int</value>
        public int HomeTeamScore
        {
            get { return GetTeamRuns(this.homeTeam); }
        }

        /// <summary>
        /// Gets the team in lead.
        /// </summary>
        /// <value>Team</value>
        public Team TeamInLead
        {
            get
            {
                if(RoadTeamScore > HomeTeamScore)
                {
                    return roadTeam;
                }
                else if(RoadTeamScore < HomeTeamScore)
                {
                    return homeTeam;
                }
                else
                {
                    return null;
                }
            }
        }
        /// <summary>
        /// Gets the home team errors.
        /// </summary>
        /// <value>int</value>
        public int HomeTeamErrors
        {
            get => GetTeamErrors(this.homeTeam);
        }

        /// <summary>
        /// Gets the home team hits.
        /// </summary>
        /// <value>int</value>
        public int HomeTeamHits
        {
            get => GetTeamHits(this.homeTeam);
        }

        /// <summary>
        /// Gets the inning scores.
        /// </summary>
        /// <value>InningScore[]</value>
        public InningScore [] InningScores
        {
            get { return inningScores.ToArray(); }
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Scoreboard"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Gameplay.Scoreboard"/>.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("The score is ");
            if(this.RoadTeamScore > this.HomeTeamScore)
            {
                sb.AppendFormat($"{this.roadTeam} {this.RoadTeamScore}, {this.homeTeam}, {this.HomeTeamScore}");
            }
            else if (this.HomeTeamScore > this.RoadTeamScore)
            {
                sb.AppendFormat($"{this.homeTeam} {this.HomeTeamScore}, {this.roadTeam}, {this.RoadTeamScore}");
            }
            else
            {
                sb.Clear();
                sb.AppendFormat($"The {this.homeTeam} and {this.roadTeam} are tied at {this.HomeTeamScore}-{this.RoadTeamScore}.");
            }
            return sb.ToString();
        }
    }
}
