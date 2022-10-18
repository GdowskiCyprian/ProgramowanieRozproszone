using System.Data;
using System.Text;

namespace ProgramowanieRozproszone
{
    public static class DataRowExtensions
    {
        private const string ERROR_MESSAGE_DATAROW_NULL = "DataRow cannot be null!";

        private static void ValidDataRow(DataRow row)
        {
            if (row is null)
                throw new ArgumentNullException(ERROR_MESSAGE_DATAROW_NULL);
        }

        #region int and int?
        public static int GetValueAsInt(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);
            if (dataRow[columnName] == DBNull.Value)
            {
                dataRow[columnName] = 0;
            }
            return Convert.ToInt32(dataRow[columnName]);
        }

        public static int? GetValueAsNullableInt(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return dataRow[columnName] != DBNull.Value ? Convert.ToInt32(dataRow[columnName]) : (int?)null;
        }
        #endregion

        #region double and double?
        public static double GetValueAsDouble(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return Convert.ToDouble(dataRow[columnName]);
        }

        public static double? GetValueAsNullableDouble(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return dataRow[columnName] != DBNull.Value ? Convert.ToDouble(dataRow[columnName]) : (double?)null;
        }
        #endregion

        #region decimal and decimal?
        public static decimal GetValueAsDecimal(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);
            if (dataRow[columnName] == DBNull.Value)
            {
                dataRow[columnName] = 0;
            }
            return Convert.ToDecimal(dataRow[columnName]);
        }

        public static decimal? GetValueAsNullableDecimal(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return dataRow[columnName] != DBNull.Value ? Convert.ToDecimal(dataRow[columnName]) : (decimal?)null;
        }
        #endregion

        #region bool
        public static bool GetValueAsBool(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return dataRow[columnName] != DBNull.Value ? Convert.ToBoolean(dataRow[columnName]) : true;
        }
        #endregion

        #region string
        public static string GetRowDataToString(this DataRow dataRow)
        {
            ValidDataRow(dataRow);

            StringBuilder rowDataStringBuilder = new StringBuilder();

            foreach (DataColumn column in dataRow.Table.Columns)
                rowDataStringBuilder.AppendLine($"{column.ColumnName}='{dataRow[column.ColumnName]}'");

            return rowDataStringBuilder.ToString();
        }

        public static string GetValueAsString(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return dataRow != null ? dataRow[columnName].ToString() : string.Empty;
        }

        public static string? GetValueAsNullableString(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return dataRow[columnName] != DBNull.Value ? dataRow[columnName].ToString() : null;
        }
        #endregion

        #region DateTime and DateTime?
        public static DateTime GetValueAsDateTime(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return Convert.ToDateTime(dataRow[columnName].ToString());
        }

        public static DateTime? GetValueAsNullableDateTime(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return dataRow[columnName] != DBNull.Value ? Convert.ToDateTime(dataRow[columnName]) : (DateTime?)null;
        }
        #endregion
        #region Long
        public static long GetValueAsLong(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return (long)dataRow[columnName];
        }
        #endregion

        #region TimeSpan and TimeSpan?
        public static TimeSpan GetValueAsTimeSpan(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return Convert.ToDateTime(dataRow[columnName].ToString()).TimeOfDay;
        }

        public static TimeSpan? GetValueAsNullableTimeSpan(this DataRow dataRow, string columnName)
        {
            ValidDataRow(dataRow);

            return dataRow[columnName] != DBNull.Value ? Convert.ToDateTime(dataRow[columnName].ToString()).TimeOfDay : (TimeSpan?)null;
        }
        #endregion

    }
}
