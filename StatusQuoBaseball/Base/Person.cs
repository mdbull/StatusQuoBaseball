using System;
using System.Text;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{

    /// <summary>
    /// Person.
    /// </summary>
    public abstract class Person: Entity
    {
        /// <summary>
        /// Determines whether the name of the person will be capitalized.
        /// </summary>
        protected bool capitalizeName;

        /// <summary>
        /// The last name.
        /// </summary>
        protected string lastName = string.Empty;

        /// <summary>
        /// The first name.
        /// </summary>
        protected string firstName = string.Empty;

        /// <summary>
        /// The full name.
        /// </summary>
        protected string fullName = string.Empty;

        /// <summary>
        /// The race of the person.
        /// </summary>
        protected Race race = Race.Unknown;

        /// <summary>
        /// The handedness.
        /// </summary>
        protected Handedness handedness = Handedness.Unknown;

        /// <summary>
        /// The height.
        /// </summary>
        protected Height height = Height.Default;

        /// <summary>
        /// The weight.
        /// </summary>
        protected Weight weight = Weight.Default;

        /// <summary>
        /// The birthday.
        /// </summary>
        protected Birthday birthday;

        /// <summary>
        /// The death date.
        /// </summary>
        protected Deathday deathDate;

        /// <summary>
        /// The capitalized name of the Person.
        /// </summary>
        protected string capitalizedName = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Person"/> class.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="lName">string</param>
        /// <param name="fName">string</param>
        /// <param name="race">Race</param>
        /// <param name="handedness">Handedness</param>
        /// <param name="height">Height</param>
        /// <param name="weight">Weight</param>
        /// <param name="birthday">Birthday</param>
        protected Person(string id, string lName, string fName, Race race, Handedness handedness, Height height, Weight weight, Birthday birthday, Deathday deathDate):base(id)
        {
            this.lastName = lName;
            this.firstName = fName;
            this.fullName = String.Format($"{fName} {lName}");
            this.capitalizedName = this.fullName.ToUpper();
            this.race = race;
            this.handedness = handedness;
            this.height = height;
            this.weight = weight;
            this.birthday = birthday;
            this.deathDate = deathDate;
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
            ret.Append(this.firstName);
            ret.Append(Configuration.ConfigurationManager.GetConfigurationValue("SPACE"));
            ret.Append(this.lastName);
            this.toString = ret.ToString();
            this.capitalizedName = this.toString.ToUpper();
        }

        /// <summary>
        /// Gets the name of the longest player.
        /// </summary>
        /// <returns>The longest person name.</returns>
        /// <param name="people">Person[]</param>
        public static int GetLongestPersonName(params Person [] people)
        {
            List<string> peopleNames = new List<string>();
            foreach (Person p in people)
            {
                peopleNames.Add(p.ToString());
            }
            return TextUtilities.GetLengthOfLongestString(peopleNames.ToArray());
        }

        /// <summary>
        /// Gets the name parts.
        /// Example: Ken Griffey Jr.
        /// </summary>
        /// <returns>Tuple</returns>
        /// <param name="name">string</param>
        public static (string, string) GetNameParts(string name)
        {
            string[] fullName = name.Split(' ');
            string lname = fullName[1];
            string fname = fullName[0];
           
            if (fullName.Length > 2)
            {
                for (int ct = 2; ct < fullName.Length; ct++)
                {
                    lname += $" {fullName[ct]}";
                }
            }

            return (fname, lname);
        }

        /// <summary>
        /// Gets the name parts as a full name
        /// Ex. Ken Griffey Jr.
        /// </summary>
        /// <returns>Tuple</returns>
        /// <param name="name">string</param>
        /// <param name="lastNameDelimeter">string </param>
        public static Tuple<string, string> GetNameParts(string name, string lastNameDelimeter)
        {
            string[] fullName = name.Split(' ');
            string lname = fullName[1];
            string fname = fullName[0];
            
            string [] lnameParts= lname.Split(Convert.ToChar(lastNameDelimeter));
            if (lnameParts.Length > 1)
            {
                lname = String.Join(" ", lnameParts);
            }
            return Tuple.Create(fname, lname);

        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get => lastName; set => lastName = value; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName { get => firstName; set => firstName = value; }

        /// <summary>
        /// Gets or sets the race.
        /// </summary>
        /// <value>The race.</value>
        public Race Race { get => race;}

        /// <summary>
        /// Gets or sets the handedness.
        /// </summary>
        /// <value>The handedness.</value>
        public Handedness Handedness { get => handedness;}

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>The height.</value>
        public Height Height { get => height; }

        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public Weight Weight { get => weight;}

        /// <summary>
        /// Gets the birthday of the person.
        /// </summary>
        /// <value>Birthday</value>
        public Birthday Birthday { get => birthday; }

        /// <summary>
        /// Gets the death date of the person.
        /// </summary>
        /// <remarks>Returns <see langword="null"/> if the person is still alive</remarks>
        /// <value>Deathday</value>
        public Deathday DeathDate { get => deathDate; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.Person"/> is deceased.
        /// </summary>
        /// <value><c>true</c> if is deceased; otherwise, <c>false</c>.</value>
        public bool IsDeceased
        {
            get=>deathDate!=null;
        }

        /// <summary>
        /// Returns the player's age in years based on the year provided.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="year">int</param>
        public int Age(int year=0)
        {
            try
            {
                DateTime bDay = new DateTime(this.birthday.Year, this.birthday.Month, this.birthday.Day);
                DateTime endYear;
                if (year!=0)
                {
                    endYear = new DateTime(year, DateTime.Now.Month,DateTime.Now.Day);
                }
                else
                {
                    endYear = new DateTime(this.deathDate.Year, this.deathDate.Month, this.deathDate.Day);
                }
                return (int)((endYear - bDay).Days / 365);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            return 0;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:StatusQuoBaseball.Base.Person"/> capitalize person name.
        /// </summary>
        /// <value><c>true</c> if capitalize person name; otherwise, <c>false</c>.</value>
        public bool CapitalizeName { get => capitalizeName; set => capitalizeName = value; }

        /// <summary>
        /// Gets the name of the capitalized.
        /// </summary>
        /// <value>The name of the capitalized.</value>
        public string CapitalizedName { get => capitalizedName; }

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>string</value>
        public string FullName { get => fullName; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Person"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Person"/>.</returns>
        public override string ToString()
        {
            if (this.capitalizeName)
            {
                return this.capitalizedName;
            }
            return this.toString;
        }
    }
}
