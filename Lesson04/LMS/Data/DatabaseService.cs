using LMS.Constants;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LMS.Data
{
    internal class DatabaseService
    {
        private readonly SqlConnection _connection;

        public DatabaseService()
        {
            _connection = new SqlConnection(DatabaseConstants.CONNECTION_STRING);
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            int affectedRows = 0;

            try
            {
                _connection.Open();

                command.Connection = _connection;

                affectedRows = command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }

            return affectedRows;
        }

        public List<T> ExecuteQuery<T>(SqlCommand command, Func<SqlDataReader, List<T>> converter)
        {
            List<T> values = new();

            try
            {
                _connection.Open();
                command.Connection = _connection;
                
                var reader = command.ExecuteReader();

                values = converter(reader);
            }
            finally
            {
                _connection.Close();
            }

            return values;
        }
    }
}
