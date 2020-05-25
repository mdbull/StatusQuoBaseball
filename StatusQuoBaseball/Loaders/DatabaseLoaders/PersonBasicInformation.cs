using StatusQuoBaseball.Base;

namespace StatusQuoBaseball.Loaders
{
    /// <summary>
    /// Pass person basic info (shared by coaches and players) because the tuple only takes 8 arguments.
    /// </summary>
    public struct PersonBasicInformation
    {
        string id;
        string lName;
        string fName;
        string number;
        string naturalPosition;
        Race race;
        Handedness handedness;
        Handedness bats;
        Height height;
        Weight weight;
        Birthday birthday;
        Deathday deathday;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Loaders.PersonBasicInformation"/> struct.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="lName">L name.</param>
        /// <param name="fName">F name.</param>
        /// <param name="number">Number.</param>
        /// <param name="naturalPosition">Natural position.</param>
        /// <param name="race">Race.</param>
        /// <param name="handedness">Handedness.</param>
        /// <param name="bats">Bats.</param>
        /// <param name="height">Height.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="birthday">Birthday</param>
        /// <param name="deathday">Deathday</param>
        public PersonBasicInformation(string id, string lName, string fName, string number, string naturalPosition, Race race, Handedness handedness, Handedness bats, Height height, Weight weight, Birthday birthday,Deathday deathday)
        {
            this.id = id;
            this.lName = lName;
            this.fName = fName;
            this.number = number;
            this.naturalPosition = naturalPosition;
            this.race = race;
            this.handedness = handedness;
            this.bats = bats;
            this.height = height;
            this.weight = weight;
            this.birthday = birthday;
            this.deathday = deathday;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>string</value>
        public string Id { get => id; }

        /// <summary>
        /// Gets the LN ame.
        /// </summary>
        /// <value>The LN ame.</value>
        public string LName { get => lName; }

        /// <summary>
        /// Gets the FN ame.
        /// </summary>
        /// <value>The FN ame.</value>
        public string FName { get => fName; }

        /// <summary>
        /// Gets the number.
        /// </summary>
        /// <value>The number.</value>
        public string Number { get => number; }

        /// <summary>
        /// Gets the natural position.
        /// </summary>
        /// <value>The natural position.</value>
        public string NaturalPosition { get => naturalPosition; }

        /// <summary>
        /// Gets the race.
        /// </summary>
        /// <value>The race.</value>
        public Race Race { get => race; }

        /// <summary>
        /// Gets the handedness.
        /// </summary>
        /// <value>The handedness.</value>
        public Handedness Handedness { get => handedness; }

        /// <summary>
        /// Gets the bats.
        /// </summary>
        /// <value>The bats.</value>
        public Handedness Bats { get => bats; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>The height.</value>
        public Height Height { get => height; }

        /// <summary>
        /// Gets the weight.
        /// </summary>
        /// <value>The weight.</value>
        public Weight Weight { get => weight; }

        /// <summary>
        /// Gets the birthday.
        /// </summary>
        /// <value>The birthday.</value>
        public Birthday Birthday { get => birthday; }

        /// <summary>
        /// Gets the deathday.
        /// </summary>
        /// <value>Deathday</value>
        public Deathday Deathday { get => deathday; }
    }
}
