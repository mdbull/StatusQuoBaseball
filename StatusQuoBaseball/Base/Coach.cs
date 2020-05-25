using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Loaders;

namespace StatusQuoBaseball.Base
{

    /// <summary>
    /// Represents a coach/manager.
    /// </summary>
    public class Coach:Player
    {
        //A coach or a manager will have the same attributes as a player plus others to be defined later.
        private CoachingStats coachingStats;
        private string[] coachingAwards = { };

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Coach"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="lName">string</param>
        /// <param name="fName">string</param>
        /// <param name="number">int</param>
        /// <param name="naturalPosition">string</param>
        /// <param name="race">Race</param>
        /// <param name="handedness">Handedness</param>
        /// <param name="bats">Bats</param>
        /// <param name="height">Height</param>
        /// <param name="weight">Weight</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="awards">string[]</param>
        public Coach(string id,string lName, string fName, string number="", string naturalPosition="", Race race=Race.Unknown, Handedness handedness=Handedness.Unknown, Handedness bats=Handedness.Unknown, Height height=null, Weight weight=null, Birthday birthday=null, params string [] awards):base(id, lName, fName, number, naturalPosition, race,  handedness, bats, height, weight, birthday)
        {
            this.coachingAwards = awards;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Coach"/> class.
        /// </summary>
        /// <param name="personInfo">PersonBasicInformation</param>
        /// <param name="awards">string[]</param>
        public Coach(PersonBasicInformation personInfo, params string[] awards):base(personInfo.Id,personInfo.LName,personInfo.FName,personInfo.Number,personInfo.NaturalPosition,personInfo.Race,personInfo.Handedness,personInfo.Bats,personInfo.Height,personInfo.Weight,personInfo.Birthday)
        {
            this.coachingAwards = awards;
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
            ret.Append("Manager");
            ret.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            ret.Append(this.firstName);
            ret.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            ret.Append(this.lastName);
            if(this.birthday!=null)
                ret.Append($"\nDOB: {this.birthday.ToLongDateString()}");
            if (this.IsDeceased)
                ret.Append("✝");
            if(this.coachingStats!=null)
                ret.Append($"\n{this.coachingStats}");
            if(this.coachingAwards.Length > 0)
            {
                int i = 1;
                ret.Append("\n***Awards***");
                foreach(string award in this.coachingAwards)
                {
                    ret.Append($"\n[{i}]  {award}");
                    i++;
                }
            }
            this.toString = ret.ToString();
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Coach"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Coach"/>.</returns>
        public override string ToString()
        {
            return this.toString;
        }

        /// <summary>
        /// Gets or sets the coaching stats.
        /// </summary>
        /// <value>CoachingStats</value>
        public CoachingStats CoachingStats
        {
            get => coachingStats;
            set 
            {
                coachingStats = value;
                BuildToString();
            }
        }

        /// <summary>
        /// Gets the coaching awards.
        /// </summary>
        /// <value>string[]</value>
        public string [] CoachingAwards { get => coachingAwards;}
    }
}
