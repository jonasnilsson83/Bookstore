using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData
{
    public sealed class Database : IDisposable
    {
        #region Fields

        /// <summary>
        /// The sql connection.
        /// </summary>
        private SqlConnection _sqlConnection;

        /// <summary>
        /// The sql transaction
        /// </summary>
        private SqlTransaction _sqlTransaction;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database()
        {
            //TODO fix hardcoded connectionstring
            var connectionString = @"Data Source=|DataDirectory|\BookstoreDB.sdf;Password=Pa$$w0rd";

            // Handle if there is no connection string.
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException("Connection string is missing");
            }

            _sqlConnection = new SqlConnection(connectionString);

            // Open connection
            _sqlConnection?.Open();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the database name.
        /// </summary>
        public string Name
        {
            get
            {
                return _sqlConnection.Database;
            }
        }

        /// <summary>
        /// Gets the database server name.
        /// </summary>
        public string ServerName
        {
            get
            {
                return _sqlConnection.DataSource;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Releases all recources held by the <see cref="Database"/> object.
        /// </summary>
        public void Dispose()
        {
            try
            {
                // If transaction exist, commit it
                if (_sqlTransaction != null)
                {
                    _sqlTransaction.Commit();
                    _sqlTransaction.Dispose();
                    _sqlTransaction = null;
                }
            }
            catch (Exception)
            {
                // Cannot commit transaction, try to rollback
                _sqlTransaction?.Rollback();
                throw;
            }
            finally
            {
                var connection = _sqlConnection;

                // If connection exist, close it
                if (connection != null)
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }

                    connection.Dispose();
                    _sqlConnection = null;
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Executes the select satement with the optional <paramref name="parameters"/>.
        /// </summary>
        /// <param name="sqlStatement">
        /// The sql statement.
        /// </param>
        /// <param name="parameters">
        /// The parameters (optional).
        /// </param>
        /// <returns>
        /// The <see cref="DataTable"/>.
        /// </returns>
        internal DataTable ExecuteSelectQuery(string sqlStatement, IEnumerable<SqlParameter> parameters = null)
        {
            // Create new transaction
            if (_sqlTransaction == null)
            {
                _sqlTransaction = _sqlConnection.BeginTransaction();
            }

            // Use given SQL statement 
            using (var command = new SqlCommand(sqlStatement, _sqlConnection, _sqlTransaction) { CommandType = CommandType.Text })
            {
                // Add eventual parameters
                if (parameters != null)
                {
                    foreach (var sqlParamValues in parameters)
                    {
                        command.Parameters.Add(sqlParamValues);
                    }
                }

                DataTable table;
                try
                {
                    // Execute the SQL
                    using (var adapter = new SqlDataAdapter(command))
                    {
                        table = new DataTable();
                        adapter.Fill(table);
                    }
                }
                catch (Exception exception)
                {
                    // Rollback transaction
                    _sqlTransaction.Rollback();
                    _sqlTransaction.Dispose();
                    _sqlTransaction = null;

                    // Throw exception
                    throw exception;
                }

                command.Parameters.Clear();

                return table;
            }
        }

        /// <summary>
        /// Executes the <paramref name="sqlStatement"/> with the optional <paramref name="parameters"/>.
        /// </summary>
        /// <param name="sqlStatement">
        /// The sql statement.
        /// </param>
        /// <param name="parameters">
        /// The parameters (optional).
        /// </param>
        /// <returns>
        /// The <see cref="Int64"/>.
        /// </returns>
        internal long ExecuteSingleValueQuery(string sqlStatement, IEnumerable<SqlParameter> parameters = null)
        {
            // Create new transaction
            if (_sqlTransaction == null)
            {
                _sqlTransaction = _sqlConnection.BeginTransaction();
            }

            // Use given SQL statement 
            using (var command = new SqlCommand(sqlStatement, _sqlConnection, _sqlTransaction) { CommandType = CommandType.Text })
            {
                // Add eventual parameters
                if (parameters != null)
                {
                    foreach (var sqlParamValues in parameters)
                    {
                        command.Parameters.Add(sqlParamValues);
                    }
                }

                long returnValue;
                try
                {
                    // Execute the SQL
                    returnValue = Convert.ToInt64(command.ExecuteScalar());
                }
                catch (Exception exception)
                {
                    // Rollback transaction
                    _sqlTransaction.Rollback();
                    _sqlTransaction.Dispose();
                    _sqlTransaction = null;

                    // Throw exception
                    throw exception;
                }


                command.Parameters.Clear();

                return returnValue;
            }
        }

        /// <summary>
        /// Executes the insert statement with the optional <paramref name="parameters"/>.
        /// </summary>
        /// <param name="sqlStatement">
        /// The sql statement.
        /// </param>
        /// <param name="parameters">
        /// The parameters (optional).
        /// </param>
        /// <returns>
        /// First column of first row selected (usually Id)
        /// </returns>
        internal long ExecuteInsertQuery(string sqlStatement, IEnumerable<SqlParameter> parameters = null)
        {
            // Create new transaction
            if (_sqlTransaction == null)
            {
                _sqlTransaction = _sqlConnection.BeginTransaction();
            }

            // Use given SQL statement 
            using (var command = new SqlCommand(sqlStatement, _sqlConnection, _sqlTransaction) { CommandType = CommandType.Text })
            {
                // Add eventual parameters
                if (parameters != null)
                {
                    foreach (var sqlParamValues in parameters)
                    {
                        command.Parameters.Add(sqlParamValues);
                    }
                }

                object returnValue;

                try
                {
                    // Execute the SQL
                    returnValue = command.ExecuteScalar();
                }
                catch (Exception exception)
                {
                    // Rollback transaction
                    _sqlTransaction.Rollback();
                    _sqlTransaction.Dispose();
                    _sqlTransaction = null;

                    // Throw exception
                    throw exception;
                }

                command.Parameters.Clear();

                // Convert to long
                return Convert.ToInt64(returnValue);
            }
        }

        /// <summary>
        /// Executes the update statement with the optional <paramref name="parameters"/>.
        /// </summary>
        /// <param name="sqlStatement">
        /// The sql statement.
        /// </param>
        /// <param name="parameters">
        /// The parameters (optional).
        /// </param>
        /// <returns>
        /// Number of affected rows
        /// </returns>
        internal long ExecuteUpdateQuery(string sqlStatement, IEnumerable<SqlParameter> parameters = null)
        {
            // Create new transaction
            if (_sqlTransaction == null)
            {
                _sqlTransaction = _sqlConnection.BeginTransaction();
            }

            // Use given SQL statement 
            using (var command = new SqlCommand(sqlStatement, _sqlConnection, _sqlTransaction) { CommandType = CommandType.Text })
            {
                // Add eventual parameters
                if (parameters != null)
                {
                    foreach (var sqlParamValues in parameters)
                    {
                        command.Parameters.Add(sqlParamValues);
                    }
                }

                object affectedRows = 0;

                try
                {
                    // Execute the SQL
                    affectedRows = command.ExecuteNonQuery();
                }
                catch (Exception exception)
                {
                    // Rollback transaction
                    _sqlTransaction.Rollback();
                    _sqlTransaction.Dispose();
                    _sqlTransaction = null;

                    // Throw exception
                    throw exception;
                }

                command.Parameters.Clear();

                // Convert to long
                return Convert.ToInt64(affectedRows);
            }
        }

        #endregion

        #region Bulk operations
        internal bool BulkCopyToDataBase(DataTable table, string tableName)
        {
            using (var bulkCopy = new SqlBulkCopy(_sqlConnection, SqlBulkCopyOptions.Default, _sqlTransaction))
            {
                bulkCopy.DestinationTableName = tableName;

                table.Columns.Add("SyncId", typeof(int));

                for (var i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["SyncId"] = i;
                }

                foreach (var column in table.Columns)
                {
                    bulkCopy.ColumnMappings.Add(column.ToString(), column.ToString());
                }

                bulkCopy.BatchSize = 100000;
                bulkCopy.BulkCopyTimeout = 120;

                try
                {
                    // Bulk copy to table
                    bulkCopy.WriteToServer(table);
                }
                catch (Exception exception)
                {
                    // Rollback transaction
                    _sqlTransaction.Rollback();
                    _sqlTransaction.Dispose();
                    _sqlTransaction = null;

                    // Throw exception
                    throw exception;
                }

                return true;
            }
        }
        

        #endregion
    }
}
