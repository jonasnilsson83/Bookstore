using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreData
{
    public class BaseDataObject
    {
        protected SQLiteConnection connection;
        private SQLiteTransaction2 transaction;

        //protected BaseDataObject(SqlCeConnection _connection, SqlCeTransaction _transaction)
        //{
        //    connection = _connection;
        //    transaction = _transaction;
        //}

        public BaseDataObject()
        {
            //TODO should be moved out of here, to a new abstration 
            connection = new SQLiteConnection(Db.ConnectionString);
        }

        protected DataTable ExecuteSelect(string sqlStatement, IEnumerable<SqlParamValues> sqlParameterValuesList = null)
        {
            connection = new SQLiteConnection(Db.ConnectionString);

            // Use given SQL statement 

            DataTable table;
            DataSet myDataSet = new DataSet();
            try
            {
                if (connection != null && connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                SQLiteDataAdapter myAdapter = new SQLiteDataAdapter();
                myAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                var command = new SQLiteCommand(sqlStatement, connection);


                // Add eventual parameters
                if (sqlParameterValuesList != null)
                {
                    foreach (var sqlParamValues in sqlParameterValuesList)
                    {
                        //command.Parameters.Add(CreateParam(sqlParamValues));
                        command.Parameters.AddWithValue("@" + sqlParamValues.Name, sqlParamValues.Value);
                    }
                }

                myAdapter.SelectCommand = command;
                myAdapter.Fill(myDataSet);
                //Get all data from all tables within the dataset
                foreach (DataTable myTable in myDataSet.Tables)
                {
                    foreach (DataRow myRow in myTable.Rows)
                    {
                        foreach (DataColumn myColumn in myTable.Columns)
                        {
                            Console.Write(myRow[myColumn] + "\t");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }
            }
            finally
            {
                if (connection != null && connection.State == ConnectionState.Open &&
                    (transaction == null))
                {
                    connection.Close();
                }
            }

            return myDataSet.Tables[0];

        }


        protected static SQLiteParameter CreateParam(SqlParamValues paramValues)
        {
            return CreateParam(paramValues.Direction, paramValues.Type, paramValues.Name, paramValues.Value);
        }

        protected static SqlParamValues CreateParamValues(ParameterDirection direction, DbType type, string name, object value)
        {
            return new SqlParamValues { Type = type, Direction = direction, Name = name, Value = value };
        }

        protected static SQLiteParameter CreateParam(ParameterDirection direction, DbType type, string name, object value)
        {
            var param = new SQLiteParameter();

            param.DbType = type;
            param.Direction = direction;
            param.ParameterName = name.StartsWith("@") ? name : string.Format("@{0}", name);
            param.Value = value;

            return param;
        }


        //protected DataTable ExecuteSelect(string sqlStatement, IEnumerable<SqlParamValues> sqlParameterValuesList = null)
        //{
        //    // Use given SQL statement 
        //    using (
        //        var command = new SQLiteCommand(sqlStatement, connection)
        //        {
        //            CommandType = CommandType.Text,
        //            Transaction = transaction
        //        })
        //    {
        //        // Add eventual parameters
        //        if (sqlParameterValuesList != null)
        //        {
        //            foreach (var sqlParamValues in sqlParameterValuesList)
        //            {
        //                command.Parameters.Add(CreateParam(command, sqlParamValues));
        //            }
        //        }

        //        DataTable table;

        //        try
        //        {
        //            if (connection != null && connection.State != ConnectionState.Open)
        //            {
        //                connection.Open();
        //            }

        //            using (var adapter = new SQLiteDataAdapter(command))
        //            {
        //                table = new DataTable();
        //                adapter.Fill(table);
        //            }
        //        }
        //        finally
        //        {
        //            if (connection != null && connection.State == ConnectionState.Open &&
        //                (transaction == null))
        //            {
        //                connection.Close();
        //            }
        //        }

        //        return table;
        //    }
        //}

        //protected static SQLiteParameter CreateParam(SQLiteCommand cmd, SqlParamValues paramValues)
        //{
        //    return CreateParam(cmd, paramValues.Direction, paramValues.Type, paramValues.Name, paramValues.Value);
        //}
        //protected static SQLiteParameter CreateParam(SQLiteCommand cmd, SqlParamValues paramValues)
        //{
        //    return CreateParam(cmd, paramValues.Direction, paramValues.Type, paramValues.Name, paramValues.Value);
        //}

        //protected static SqlParamValues CreateParamValues(ParameterDirection direction, DbType type, string name, object value)
        //{
        //    return new SqlParamValues { Type = type, Direction = direction, Name = name, Value = value };
        //}

        //protected static SQLiteParameter CreateParam(SQLiteCommand cmd, ParameterDirection direction, DbType type, string name, object value)
        //{
        //    var param = cmd.CreateParameter();

        //    param.DbType = type;
        //    param.Direction = direction;
        //    param.ParameterName = name;
        //    param.Value = value;

        //    return param;
        //}


    }
}
