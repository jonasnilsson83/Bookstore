using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData
{
    public class BaseDataMapper
    {
        /// <summary>
        /// Get string value from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The string value</returns>
        protected static string GetString(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                return String.Empty;
            }
            return value.ToString();
        }

        /// <summary>
        /// Get integer value from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The integer value</returns>
        protected static int GetInt(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                throw new ArgumentException(string.Format("Int value from field {0} should not be null", field));
            }

            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Get int64 value from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The integer value</returns>
        protected static long GetLong(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                throw new ArgumentException(string.Format("Long value from field {0} should not be null", field));
            }

            return Convert.ToInt64(value);
        }

        /// <summary>
        /// Get date value from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The date value</returns>
        protected static DateTime GetDateTime(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                return new DateTime();
            }
            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// Get nullable date from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The nullable date value</returns>
        protected static DateTime? GetDateTimeNullable(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                return null;
            }
            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// Get nullable integer from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The nullable integer value</returns>
        protected static int? GetIntNullable(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                return null;
            }
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Get nullable int64 from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The nullable integer value</returns>
        protected static long? GetLongNullable(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                return null;
            }
            return Convert.ToInt64(value);
        }

        /// <summary>
        /// Get nullable double from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The nullable double value</returns>
        protected static double? GetDoubleNullable(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                return null;
            }
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Get double from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The double value</returns>
        protected static double GetDouble(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                throw new ArgumentException(string.Format("Double value from field {0} should not be null", field));
            }
            return Convert.ToDouble(value);
        }

        /// <summary>
        /// Get decimal from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The double value</returns>
        protected static decimal GetDecimal (DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                throw new ArgumentException(string.Format("Decimal value from field {0} should not be null", field));
            }
            return Convert.ToDecimal(value);
        }

        /// <summary>
        /// Get boolean from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The boolean value</returns>
        protected static bool GetBool(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                return false;
            }
            return Convert.ToBoolean(value);
        }

        /// <summary>
        /// Get nullable boolean from a dataset row
        /// </summary>
        /// <param name="dr">The datarow</param>
        /// <param name="field">The field to be converted</param>
        /// <returns>The nullable boolean value</returns>
        protected static bool? GetBoolNullable(DataRow dr, string field)
        {
            var value = dr[field];
            if (value == DBNull.Value)
            {
                return null;
            }
            return Convert.ToBoolean(value);          
        }

    }
}
