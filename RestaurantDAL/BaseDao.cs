using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace RestaurantDAL
{
    public abstract class BaseDao
    {
        private SqlDataAdapter adapter;
        private SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChapeauDatabase"].ConnectionString);

        public BaseDao()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ChapeauDatabase"].ConnectionString);
            adapter = new SqlDataAdapter();
        }

        protected SqlConnection OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
                {
                    connection.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return connection;
        }

        private void CloseConnection()
        {
            connection.Close();
        }

        /// <summary>
        /// For Insert/Update/Delete Queries
        /// </summary>
        /// <param name="query">Query to execute.</param>
        /// <param name="sqlParameters">Parameters.</param>
        protected void ExecuteEditQuery(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// For Select Queries
        /// </summary>
        /// <param name="query">Query to execute.</param>
        /// <param name="sqlParameters">Parameters</param>
        /// <returns></returns>
        protected DataTable ExecuteSelectQuery(string query, params SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                command.ExecuteNonQuery();
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);
                dataTable = dataSet.Tables[0];
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                CloseConnection();
            }
            return dataTable;
        }

        /// <summary>
        /// For SELECT queries
        /// </summary>
        /// <param name="query">Query to execute</param>
        protected DataTable ExecuteSelectQuery(string query)
        {
            return ExecuteSelectQuery(query, new SqlParameter[0]);
        }

        /// <summary>
        /// For INSERT with OUTPUT.
        /// </summary>
        /// <param name="query">Query to execute</param>
        /// <param name="sqlParameters">Parameters</param>
        /// <returns></returns>
        protected DataTable ExecuteEditAndSelectQuery(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand command = new SqlCommand();
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                command.Parameters.AddRange(sqlParameters);
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);

                dataTable = dataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return dataTable;
        }
        protected DataTable ExecuteEditAndSelectQuery(string query)
        {
            SqlCommand command = new SqlCommand();
            DataTable dataTable;
            DataSet dataSet = new DataSet();

            try
            {
                command.Connection = OpenConnection();
                command.CommandText = query;
                adapter.SelectCommand = command;
                adapter.Fill(dataSet);

                dataTable = dataSet.Tables[0];
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }

            return dataTable;
        }
    }
}
