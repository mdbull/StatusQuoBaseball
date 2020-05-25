using System;
using System.Text;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Base
{

    /// <summary>
    /// Player Stamina Reduced event handler.
    /// </summary>
    public delegate void PlayerStaminaReducedEventHandler(PlayerStaminaReducedEventArgs e);

    /// <summary>
    /// Player Stamina Reduced event arguments.
    /// </summary>
    public class PlayerStaminaReducedEventArgs : EventArgs
    {
        private Player player;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.PlayerStaminaReducedEventArgs"/> class.
        /// </summary>
        /// <param name="player">Player</param>
        public PlayerStaminaReducedEventArgs(Player player)
        {
            this.player = player;
        }

        /// <summary>
        /// Gets the player.
        /// </summary>
        /// <value>Player</value>
        public Player Player { get => this.player; }
    }

    /// <summary>
    /// Player.
    /// </summary>
    public class Player : Person
    {
        /// <summary>
        /// The year of this player.
        /// </summary>
        protected int year;

        /// <summary>
        /// Occurs when player stamina reduced.
        /// </summary>
        public event PlayerStaminaReducedEventHandler PlayerStaminaReduced;

        /// <summary>
        /// Whether or not the player is batting.
        /// </summary>
        protected bool isBatting;

        /// <summary>
        /// The show extended to string.
        /// </summary>
        protected bool showExtendedToString;

        /// <summary>
        /// The stamina.
        /// </summary>
        protected int stamina;

        /// <summary>
        /// The current stamina.
        /// </summary>
        protected int currentStamina;

        /// <summary>
        /// The made appearance.
        /// </summary>
        protected bool madeAppearance;

        /// <summary>
        /// The uniform.
        /// </summary>
        protected Uniform uniform;

        /// <summary>
        /// The number.
        /// </summary>
        protected string number = string.Empty;

        /// <summary>
        /// The bats.
        /// </summary>
        protected Handedness bats = Handedness.Unknown;

        /// <summary>
        /// The throws.
        /// </summary>
        protected Handedness throws = Handedness.Unknown;

        /// <summary>
        /// The natural position.
        /// </summary>
        protected string naturalPosition = String.Empty;

        /// <summary>
        /// The current position.
        /// </summary>
        protected string currentPosition = String.Empty;

        /// <summary>
        /// The pitching stats.
        /// </summary>
        protected PitchingStats pitchingStats;

        /// <summary>
        /// The batting stats.
        /// </summary>
        protected BattingStats battingStats;

        /// <summary>
        /// The fielding stats.
        /// </summary>
        protected FieldingStats fieldingStats;

        /// <summary>
        /// The player is running.
        /// </summary>
        protected bool isRunning;

        /// <summary>
        /// The batting statistics.
        /// </summary>
        protected BattingStatisticsContainer battingStatistics;

        /// <summary>
        /// The pitching statistics.
        /// </summary>
        protected PitchingStatisticsContainer pitchingStatistics;

        /// <summary>
        /// The fielding statistics.
        /// </summary>
        protected FieldingStatisticsContainer fieldingStatistics;

        /// <summary>
        /// The season statistics.
        /// </summary>
        protected SeasonStatisticsContainer seasonStatistics;

        /// <summary>
        /// The team.
        /// </summary>
        protected Team team;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Player"/> class.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="lName">string</param>
        /// <param name="fName">string</param>
        /// <param name="number">string</param>
        /// <param name="naturalPosition">Natural position.</param>
        /// <param name="race">Race</param>
        /// <param name="handedness">Handedness</param>
        /// <param name="bats">Handedness</param>
        /// <param name="height">Height</param>
        /// <param name="weight">Weight</param>
        /// <param name="birthday">Birthday</param>
        public Player(string id, string lName, string fName, string number, string naturalPosition, Race race, Handedness handedness, Handedness bats, Height height, Weight weight, Birthday birthday,Deathday deathday=null) :base (id,lName, fName, race, handedness, height, weight, birthday,deathday)
        {
            this.number = number;
            this.naturalPosition = naturalPosition;
            this.CurrentPosition = this.naturalPosition;
            this.bats = bats;
            this.throws = handedness;

#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Player"/> class from a PersonBasicInformation struct.
        /// </summary>
        /// <param name="personInfo">Person info.</param>
        public Player(PersonBasicInformation personInfo) : base(personInfo.Id, personInfo.LName, personInfo.FName,  personInfo.Race, personInfo.Handedness,  personInfo.Height, personInfo.Weight, personInfo.Birthday,personInfo.Deathday)
        {
            this.number = personInfo.Number;
            this.naturalPosition = personInfo.NaturalPosition;
            this.currentPosition = this.naturalPosition;
            this.throws = personInfo.Handedness;
            this.bats = personInfo.Bats;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(Utilities.TextUtilities.FillString(this.currentPosition, ' ',2));
            ret.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            if (this.number.Length > 0)
            {
                ret.Append(Utilities.TextUtilities.FillString(this.number, ' ', 2));
                ret.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            }
            ret.Append(this.firstName);
            ret.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            ret.Append(this.lastName);
            if (this.bats == Handedness.Left)
                ret.Append("*");
            if (this.bats == Handedness.Switch)
                ret.Append("#");
            //ret.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            //ret.Append('(');
            //ret.Append(this.height);
            //ret.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            //ret.Append(this.weight);
            //ret.Append(')');
            this.toString = ret.ToString();
            this.capitalizedName = this.toString.ToUpper();
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>string</value>
        public string Number { get => number; set => number = value; }

        /// <summary>
        /// Gets the bats.
        /// </summary>
        /// <value>Handedness</value>
        public Handedness Bats { get => bats; }

        /// <summary>
        /// Gets the throws.
        /// </summary>
        /// <value>Handedness</value>
        public Handedness Throws { get => throws; }

        /// <summary>
        /// Gets or sets the natural position of the player
        /// </summary>
        /// <value>string</value>
        public string NaturalPosition 
        { 
            get => naturalPosition;
            set
            {
                naturalPosition = value;
                BuildToString();
            }
        }

        /// <summary>
        /// Gets or sets the current position of the player.
        /// </summary>
        /// <value>string</value>
        public string CurrentPosition 
        { 
            get => currentPosition;
            set
            {
                currentPosition = value;
                BuildToString();
            }
        
        }

        /// <summary>
        /// Gets or sets the pitching stats.
        /// </summary>
        /// <value>PitchingStats</value>
        public PitchingStats PitchingStats
        {
            get => pitchingStats;
            set
            {
                pitchingStats = value;
                BuildToString();
            }
        }

        /// <summary>
        /// Gets the batting stats.
        /// </summary>
        /// <value>The batting stats.</value>
        public BattingStats BattingStats 
        { 
            get => battingStats;
            set
            {
                battingStats = value;
                BuildToString();
            }
        }

        /// <summary>
        /// Gets the fielding stats.
        /// </summary>
        /// <value>FieldingStats</value>
        public FieldingStats FieldingStats
        {
            get => fieldingStats;
            set
            {
                fieldingStats = value;
                BuildToString();
            }
        }

        /// <summary>
        /// Gets or sets the team.
        /// </summary>
        /// <value>Team</value>
        public Team Team { get => team; set => team = value; }

        /// <summary>
        /// Gets or sets the batting statistics.
        /// </summary>
        /// <value>BattingStatisticsContainer</value>
        public BattingStatisticsContainer BattingStatistics { get => battingStatistics; set => battingStatistics = value; }

        /// <summary>
        /// Gets or sets the pitching statistics.
        /// </summary>
        /// <value>PitchingStatisticsContainer</value>
        public PitchingStatisticsContainer PitchingStatistics { get => pitchingStatistics; set => pitchingStatistics = value; }

        /// <summary>
        /// Gets or sets the fielding statistics.
        /// </summary>
        /// <value>FieldingStatisticsContainer</value>
        public FieldingStatisticsContainer FieldingStatistics { get => fieldingStatistics; set => fieldingStatistics = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.Player"/> is running.
        /// </summary>
        /// <value><c>true</c> if is running; otherwise, <c>false</c>.</value>
        public bool IsRunning { get => isRunning; set => isRunning = value; }

        /// <summary>
        /// Gets or sets the uniform.
        /// </summary>
        /// <value>Uniform</value>
        public Uniform Uniform 
        { 
            get => uniform;
            set
            {
                uniform = value;
                BuildToString();//update to include number
            }
        }

        /// <summary>
        /// Gets the season statistics.
        /// </summary>
        /// <value>SeasonStatisticsContainer</value>
        public SeasonStatisticsContainer SeasonStatistics { get => seasonStatistics; set => seasonStatistics = value; }
       
       /// <summary>
       /// Gets or sets whether the player made an appearance in the game.
       /// </summary>
       /// <value><c>true</c> if made appearance; otherwise, <c>false</c>.</value>
        public bool MadeAppearance { get => madeAppearance; set => madeAppearance = value; }

        /// <summary>
        /// Gets or sets the stamina.
        /// </summary>
        /// <value>int</value>
        public int Stamina 
        { 
            get => stamina;
            set
            {
                stamina = value;
                this.currentStamina = this.stamina;

            }
        }

        /// <summary>
        /// Gets or sets the current stamina of the player.
        /// </summary>
        /// <value>int</value>
        public int CurrentStamina 
        { 
            get => currentStamina; 
            set
            {
                currentStamina = value;
                if(value!=stamina)
                {
                    OnPlayerStaminaReduced(new PlayerStaminaReducedEventArgs(this));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.Player"/> is batting.
        /// </summary>
        /// <value><c>true</c> if is batting; otherwise, <c>false</c>.</value>
        public bool IsBatting { get => isBatting; set => isBatting = value; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.Player"/> show extended to string.
        /// </summary>
        /// <value><c>true</c> if show extended to string; otherwise, <c>false</c>.</value>
        public bool ShowExtendedToString { get => showExtendedToString; set => showExtendedToString = value; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        public int Year { get => year; set => year = value; }

        /// <summary>
        /// Ons the player stamina reduced.
        /// </summary>
        /// <param name="e">PlayerStaminaReducedEventArgs</param>
        protected virtual void OnPlayerStaminaReduced(global::StatusQuoBaseball.Base.PlayerStaminaReducedEventArgs e)
        {
            PlayerStaminaReduced?.Invoke(e);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Player"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Player"/>.</returns>
        public override string ToString()
        {
            if (this.capitalizeName)
            {
                this.capitalizedName = toString.ToUpper();
                if (showExtendedToString)
                {
                    if (this.currentPosition.Length > 0)
                    {
                        if (this.currentPosition == "P")
                        {
                            if (this.pitchingStats != null)
                            {
                                if (!this.isBatting)
                                {
                                    return this.capitalizedName + $" [ST{this.CurrentStamina}:CT{this.pitchingStats.CurrentControl}:PR{this.pitchingStats.PowerRating}]";
                                }
                                else
                                {
                                    return this.capitalizedName + $" [CM{this.battingStats.ControlModifier}:ST{this.CurrentStamina}:PR{this.battingStats.PowerRating}]";
                                }
                            }
                        }
                        else if (this.battingStats != null)
                        {
                            return this.capitalizedName + $" [CM{this.battingStats.ControlModifier}:ST{this.CurrentStamina}:PR{this.battingStats.PowerRating}]";
                        }
                    }
                }
                return this.capitalizedName;
            }
            else//not capitalized
            {
                if (showExtendedToString)
                {
                    if (this.currentPosition.Length > 0)
                    {
                        if (this.currentPosition == "P")
                        {
                            if (this.pitchingStats != null)
                            {
                                if (!this.isBatting)
                                {
                                    return toString + $" [ST{this.CurrentStamina}:CT{this.pitchingStats.CurrentControl}:PR{this.pitchingStats.PowerRating}]";
                                }
                                else
                                {
                                    return toString + $" [CM{this.battingStats.ControlModifier}:ST{this.CurrentStamina}:PR{this.battingStats.PowerRating}]";
                                }
                            }
                        }
                        else if (this.battingStats != null)
                        {
                            return toString + $" [CM{this.battingStats.ControlModifier}:ST{this.CurrentStamina}:PR{this.battingStats.PowerRating}]";
                        }
                    }
                }
            }
           
            return toString;
        }

    }
}
