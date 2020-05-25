using System;
using StatusQuoBaseball.Configuration;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{


    /// <summary>
    /// Birthday.
    /// </summary>
    [Serializable]
    public class Birthday
    {
        /// <summary>
        /// The default birthdate.
        /// </summary>
        public static readonly Birthday Default = new Birthday(ConfigurationManager.GetConfigurationValue("DEFAULT_PROFESSIONAL_BIRTHDAY"));

        /// <summary>
        /// The year.
        /// </summary>
        protected int year;

        /// <summary>
        /// The month.
        /// </summary>
        protected int month;

        /// <summary>
        /// The day.
        /// </summary>
        protected int day;

        /// <summary>
        /// The age.
        /// </summary>
        protected int age;

        /// <summary>
        /// The short date string.
        /// </summary>
        protected string shortDateString = String.Empty;

        /// <summary>
        /// The long date string.
        /// </summary>
        protected string longDateString = String.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Birthday"/> class.
        /// </summary>
        private Birthday()
        {
            this.age = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Birthday"/> class.
        /// </summary>
        /// <param name="y">int</param>
        /// <param name="m">int</param>
        /// <param name="d">int</param>
        public Birthday(int y, int m, int d)
        {
            this.year = y;
            this.month = m;
            this.day = d;
            this.age = CalculateAge(this.year, this.month, this.day);
            this.shortDateString = String.Format("{0}/{1}/{2}", this.month, this.day, this.year);
            this.longDateString = String.Format("{0} {1}, {2}", Constants.MONTHS[this.month - 1], this.day, this.year);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Birthday"/> class.
        /// </summary>
        /// <param name="birthday">string</param>
        public Birthday(string birthday)
        {
            if (birthday.Length > 0)
            {
                DateTime bDay = DateTime.Now;
                DateTime.TryParse(birthday, out bDay);
                this.year = bDay.Year;
                this.month = bDay.Month;
                this.day = bDay.Day;
                this.age = CalculateAge(this.year, this.month, this.day);
            }
            else
            {
                this.year =1980;
                this.month = 1;
                this.day =1;
                this.age = CalculateAge(this.year, this.month, this.day);
            }
            this.shortDateString = String.Format("{0}/{1}/{2}", this.month, this.day, this.year);
            this.longDateString = String.Format("{0} {1}, {2}", Constants.MONTHS[this.month - 1], this.day, this.year);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Birthday"/> class.
        /// </summary>
        /// <param name="birthday">Birthday</param>
        public Birthday(DateTime birthday)
        {
            this.year = birthday.Year;
            this.month = birthday.Month;
            this.day = birthday.Day;
            this.age = CalculateAge(this.year, this.month, this.day);
            this.shortDateString = String.Format("{0}/{1}/{2}", this.month, this.day, this.year);
            this.longDateString = String.Format("{0} {1}, {2}", Constants.MONTHS[this.month - 1], this.day, this.year);
        }

        /// <summary>
        /// Deconstruct the specified year, month and day.
        /// </summary>
        /// <param name="year">int</param>
        /// <param name="month">int</param>
        /// <param name="day">int</param>
        public virtual void Deconstruct(out int year, out int month, out int day)
        {
            year = this.year;
            month = this.month;
            day = this.day;
        }

        /// <summary>
        /// Calculates the age.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="y">int</param>
        /// <param name="m">int</param>
        /// <param name="d">int</param>
        protected int CalculateAge(int y, int m, int d)
        {
            int ret = 0;
            DateTime dob = new DateTime(y, m, d);
            ret = DateTime.Now.Year - dob.Year;
            if (DateTime.Now.DayOfYear < dob.DayOfYear)
                ret -= 1;

            return ret;
        }
        /// <summary>
        /// Gets the year.
        /// </summary>
        /// <value>int</value>
        public int Year { get => year; }

        /// <summary>
        /// Gets the month.
        /// </summary>
        /// <value>int</value>
        public int Month { get => month; }

        /// <summary>
        /// Gets the day.
        /// </summary>
        /// <value>int</value>
        public int Day { get => day; }

        /// <summary>
        /// Gets the age.
        /// </summary>
        /// <value>int</value>
        public int Age { get => age; }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Birthday"/>.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return shortDateString;
        }

        /// <summary>
        /// Tos the long date string.
        /// </summary>
        /// <returns>string</returns>
        public virtual string ToLongDateString()
        {

            return longDateString;
        }
    }
}
