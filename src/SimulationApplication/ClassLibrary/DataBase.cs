using System;
using MySql.Data.MySqlClient;

namespace ClassLibrary
{
    /// <summary>
    /// Building this project will update changes made to the library.
    /// 
    /// Method calls can be made to this static class by DataBase.SomeMethod();
    /// 
    /// Class libraries have to be imported, by first clicking references in the solution
    /// explorer -> right click on references -> add references -> browse for the dll
    /// -> add and select.
    /// 
    /// After adding the reference, you import it by making use of a using statement, as
    /// using DataBaseMethods
    /// </summary>
    public class DataBase
    {
        // Is the key in the config file.
        private const string CONFIG_KEY = "envVariableName";
        // Will get the value corresponding to the config key from the app.config file.
        // The value returned should be the name of your environment variable to which you linked your db connection info.
        private static string environmentVariable = System.Configuration.ConfigurationManager.AppSettings[CONFIG_KEY];
        public static string ConnectionInfo
        {
            get
            {
                // Will thus return the connection string.
                return Environment.GetEnvironmentVariable(environmentVariable);
            }
        }

        private static MySqlConnection connection = new MySqlConnection(ConnectionInfo);

        /// <summary>
        /// Standard method to open a connection to the database
        /// in a safe manner.
        /// </summary>
        /// 
        /// <returns>
        /// Returns true of a connection has been 
        /// successfully established and false if not.
        /// </returns>
        public static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException)
            {
                return false;
            }
        }

        /// <summary>
        /// Closes the database connection in a safe manner.
        ///  
        ///  Ensures the connection is always closed whatever happens.
        /// </summary>
        /// <returns>
        /// Returns true if the connection to the database was successfully closed.
        /// Returns false if an Exception is thrown (which is not an indication that
        /// the connection was not closed, as it will always close (see finally)).
        /// </returns>
        public static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Calls the method to open up the connection to the database
        /// as specified in the connectionInfo string.
        /// 
        /// Accepts a sql query string as input to count records
        /// or to obtain return values as surrogate keys when inserting data.
        /// Processes input sql string onto the database, and safely
        /// closes the connection.
        /// </summary>
        /// <param name="sql">
        /// A simple sql query for example "SELECT COUNT(*) FROM stand;"
        /// </param>
        /// <returns>
        /// Returns an integer that represents the number of affected rows/records.
        /// </returns>
        public static int ExecuteScalar(string sql)
        {
            int returnValue = 0;
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                try
                {
                    returnValue = int.Parse(cmd.ExecuteScalar().ToString()); // ExecuteScalar returns an object (parsed into an int for number of affected records).
                }
                catch (Exception)
                {
                }
                finally
                {
                    CloseConnection();
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Calls the method to open up the connection to the database
        /// as specified in the connectionInfo string.
        /// 
        /// Accepts a sql query string as input to retrieve data.
        /// Processes input sql string onto the database, and returns
        /// a mysqlDataReader object that the user has to use to
        /// obtain records/attributes/fields.
        /// 
        /// IMPORTANT THAT THE USER CALLS THE CLOSECONNECTION
        /// METHOD AFTER USING THIS METHOD AND ITERATING OVER
        /// ALL THE READER ITEMS.
        /// </summary>
        /// <param name="sql">
        /// A simple sql query for example "SELECT * FROM Stand;"
        /// </param>
        /// <returns>
        /// A reader object that the user will have to iterate through
        /// to obtain his/her records.
        /// </returns>
        public static MySqlDataReader ExecuteReader(string sql)
        {
            MySqlDataReader reader = null;
            if (OpenConnection() == true)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    reader = cmd.ExecuteReader();
                }
                catch(MySqlException ex)
                {
                    Console.WriteLine(ex.Code);
                }
                finally
                {
                    CloseConnection();
                }
            }
            return reader;
        }

        /// <summary>
        /// Calls the method to open up the connection to the database
        /// as specified in the connectionInfo string.
        /// 
        /// Accepts a sql query string as input to change data.
        /// Processes input sql string onto the database, and safely
        /// closes the connection.
        /// </summary>
        /// <param name="sql">
        /// A simple sql query for example "INSERT INTO Stand (Name) VALUES ('KAPSALONSTAND');"
        /// </param>
        public static void ExecuteNonQuery(string sql)
        {
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }
        }
    }
}
