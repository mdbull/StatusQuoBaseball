using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using StatusQuoBaseball.Utilities;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// Uniform.
    /// </summary>
    [Serializable]
    public class Uniform:Entity
    {
        private string name = String.Empty;
        private string lastName = String.Empty;
        private string number = String.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Uniform"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="number">Number.</param>
        public Uniform(string name, string number)
        {
            this.name = name;
            this.lastName = name.Split(' ')[1];
            this.number = number;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.Uniform"/> class.
        /// </summary>
        /// <param name="firstName">string</param>
        /// <param name="lastName">string</param>
        /// <param name="number">string</param>
        public Uniform(string firstName, string lastName, string number)
        {
            this.name = String.Join(" ", firstName, lastName);
            this.lastName = lastName;
            this.number = number;
#pragma warning disable RECS0021 // Warns about calls to virtual member functions occuring in the constructor
            BuildToString();
#pragma warning restore RECS0021 // Warns about calls to virtual member functions occuring in the constructor
        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected override void BuildToString()
        {
            toString = String.Format($"{this.number} {this.lastName}");
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get => name; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get => lastName;}

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>The number.</value>
        public string Number { get => number;}

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Uniform"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.Uniform"/>.</returns>
        public override string ToString()
        {
            return toString;
        }
    }
}
