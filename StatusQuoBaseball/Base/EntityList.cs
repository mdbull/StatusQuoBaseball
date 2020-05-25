using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StatusQuoBaseball.Gameplay;
using StatusQuoBaseball.Utilities;
using StatusQuoBaseball.Configuration;

namespace StatusQuoBaseball.Base
{
    /// <summary>
    /// EntityList
    /// </summary>
    public abstract class EntityList<T> : List<T>, IExecutable
    {
        /// <summary>
        /// The EntityList Id.
        /// </summary>
        protected string id = String.Empty;

        /// <summary>
        /// The name.
        /// </summary>
        protected string name = String.Empty;

        /// <summary>
        /// To string.
        /// </summary>
        protected string toString = String.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.EntityList`1"/> class.
        /// </summary>
        /// <param name="id">string</param>
        /// <param name="name">string</param>
        protected EntityList(string id, string name)
        {
            this.id = id;
            this.name = name;

        }

        /// <summary>
        /// Builds to string.
        /// </summary>
        protected abstract void BuildToString();


        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Base.EntityList`1"/> class.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="name">Name.</param>
        /// <param name="items">Items.</param>
        protected EntityList(string id, string name, IEnumerable<T> items) : base(items)
        {
            this.id = id;
            this.name = name;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>string</value>
        public string Id { get => id; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>string</value>
        public string Name { get => name; }

        /// <summary>
        /// Execute this instance.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Gets the total count.
        /// </summary>
        /// <returns>int</returns>
        /// <param name="items">Items</param>
        protected int GetTotalCount<K>(IEnumerable<T> items)
        {

            int total = 0;

            foreach (T item in items)
            {
                if (item is ICollection<K>)
                {
                    total += ((ICollection<K>)item).Count;
                }
                else
                {
                    total++;
                }
            }
            return total;
        }

        /// <summary>
        /// Gets the total item count.
        /// </summary>
        /// <value>int</value>
        public int GetTotalItemCount<K>()
        {
            return GetTotalCount<K>(this);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.EntityList`1"/>.
        /// </summary>
        /// <returns>A <see cref="T:System.String"/> that represents the current <see cref="T:StatusQuoBaseball.Base.EntityList`1"/>.</returns>
        public override string ToString()
        {
            return this.toString;
        }
    }

}
