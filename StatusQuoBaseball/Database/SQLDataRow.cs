using System.Data;

namespace StatusQuoBaseball.Database
{
    /// <summary>
    /// SQLD ata row.
    /// </summary>
    public class SQLDataRow : DataRow
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:StatusQuoBaseball.Database.SQLDataRow"/> class.
        /// </summary>
        /// <param name="builder">DataRowBuilder</param>
        protected internal SQLDataRow(DataRowBuilder builder) : base(builder)
        {
        }
    }
}
