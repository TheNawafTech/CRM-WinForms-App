using ClsUser_Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClsUser_Person.ClsUser;
using System.Data.SqlClient; // Assuming SQL Server is used for database connection
using System.Data;
using System.Runtime.InteropServices;
using ClsDataAccessSettings;

namespace nClsDataLayer
{
    public class ClsDataLayer
    {
        ClsUser _User = new ClsUser();

        string ConnectionString = "Server=.;Database=CRMproject;Integrated Security=True;";

        public static int ConnectDatabaseExcuteNonQuery(string Connection, string Query, Dictionary<string, object> parameters = null)
        {
            SqlConnection connection = new SqlConnection(Connection);
            SqlCommand command = new SqlCommand(Query, connection);

            int RowsEffcted = 0;

            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            try
            {
                connection.Open();

                RowsEffcted = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                // Handle exception (log it, rethrow it, etc.)
                Console.WriteLine("Error executing non-query: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return RowsEffcted;
        }

        public static SqlDataReader ConnectDatabaseExecuteReader(string connectionString, string query, Dictionary<string, object> parameters = null)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            // إضافة الـ parameters (إن وجد)
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            try
            {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection); // يغلق الاتصال عند إغلاق reader
            }
            catch
            {
                // The caller never gets a reader, so release the connection here and let the
                // error reach the business layer. Returning null made a failure look like "not found".
                conn.Dispose();
                throw;
            }
        }

        public static int ConnectDataExcuteScalar(string connectionString, string query, Dictionary<string, object> parameters = null)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(query, conn);

            // Adding parametrs (if found)
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            try
            {
                conn.Open();

                object Result = cmd.ExecuteScalar();

                return Convert.ToInt32(Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing reader: " + ex.Message);
                return -1;
            }
            finally
            {
                conn.Close();
            }
        }

        public static bool GetClient(int ClientID, ref ClsClient.ClsClient client)
        {
            var Parameter = new Dictionary<string, object>()
            {
                {"@ClientID", ClientID}
            };

            SqlDataReader reader = ConnectDatabaseExecuteReader(ClsDataAcessSettings.ConnectingCRMproject, "select * from Clients where ClientID = @ClientID", Parameter);

            // A null reader means the query itself failed (e.g. database unavailable).
            // It is reported as false like "not found"; telling the two apart belongs to the error-handling work.
            if (reader == null)
            {
                return false;
            }

            using (reader)
            {
                if (reader.Read())
                {
                    client.ClientID = (int)reader["ClientID"];
                    client.ClientName = reader["ClientName"].ToString();
                    client.Phone = reader["Phone"].ToString();
                    client.Email = reader["Email"].ToString();
                    client.TotalOrders = (int)reader["TotalOrders"];
                    client.TotalPurchaseValue = (decimal)reader["TotalPurchaseValue"];
                    return true;
                }
            }

            return false;
        }

        // Always loads the result, so an empty table still carries its columns. Returns whether any row was found.
        public static bool GetAllRecords(ref DataTable Dt, string Query)
        {
            using (SqlDataReader reader = ConnectDatabaseExecuteReader(ClsDataAcessSettings.ConnectingCRMproject, Query))
            {
                Dt.Load(reader);
            }

            return Dt.Rows.Count > 0;
        }

        public static bool IsClientExsist(ClsClient.ClsClient client)
        {
            string Query = "SELECT * FROM Clients where Phone =@Phone OR Email = @Email";

            var parameters = new Dictionary<string, object>
            {
                { "@Phone", client.Phone },{"@Email",client.Email}
            };

            SqlDataReader reader = ConnectDatabaseExecuteReader(ClsDataAccessSettings.ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);

            if (reader == null)
            {
                return false;
            }

            using (reader)
            {
                return reader.Read();
            }
        }

        public static bool IsUserExsist(int UserID)
        {
            // We will do it here also :

            string Query = "SELECT * FROM Users where UserID =@UserID";

            var parameters = new Dictionary<string, object>
            {
                { "@UserID", UserID }
            };

            SqlDataReader reader = ConnectDatabaseExecuteReader(ClsDataAccessSettings.ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);

            if (reader.Read() && reader != null)
            {
                return true;
            }

            return false;
        }

        public static bool IsUserNameExsist(string UserName,ClsUser user)
        {
            // We will do it here also :
            string Query = "SELECT * FROM Users WHERE UserName = @UserName AND UserID != @UserID";
            var parameters = new Dictionary<string, object>
            {
                { "@UserName", UserName } , { "@UserID",user.UserID}
            };

            SqlDataReader reader = ConnectDatabaseExecuteReader(ClsDataAccessSettings.ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);
            if (reader.Read() && reader != null)
            {
                return true;
            }
            return false;
        }


        public static bool IsUserNameExsist(string UserName)
        {
            // We will do it here also :
            string Query = "SELECT * FROM Users WHERE UserName = @UserName";

            var parameters = new Dictionary<string, object>
            {
                { "@UserName", UserName }
            };

            SqlDataReader reader = ConnectDatabaseExecuteReader(ClsDataAccessSettings.ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);
            if (reader.Read() && reader != null)
            {
                return true;
            }
            return false;
        }

        // Loads a user by name together with the stored password hash, for login verification.
        // The hash is returned separately so it never ends up on the ClsUser object.
        public static bool GetUserByUserName(string UserName, ref ClsUser User, ref string PasswordHash)
        {
            string Query = "SELECT UserID, UserName, FullName, Email, Password, Permissions FROM Users WHERE UserName = @UserName";

            var parameters = new Dictionary<string, object>
            {
                { "@UserName", UserName }
            };

            SqlDataReader reader = ConnectDatabaseExecuteReader(ClsDataAccessSettings.ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);

            if (reader == null)
            {
                return false;
            }

            using (reader)
            {
                if (!reader.Read())
                {
                    return false;
                }

                User.UserID = (int)reader["UserID"];
                User.UserName = reader["UserName"].ToString();
                User.FullName = reader["FullName"].ToString();
                User.Email = reader["Email"].ToString();
                User.Permissions = (enPermissions)Enum.Parse(typeof(enPermissions), reader["Permissions"].ToString());
                PasswordHash = reader["Password"].ToString();
                return true;
            }
        }
        public static bool AddNewClient(ref ClsClient.ClsClient newClient)
        {
            if (IsClientExsist(newClient))
            {
                return false;
            }

            string Query = "INSERT INTO Clients (ClientName, Phone, Email, TotalOrders, TotalPurchaseValue) " +
                "VALUES (@ClientName, @Phone, @Email, @TotalOrders, @TotalPurchaseValue); "
                + "SELECT SCOPE_IDENTITY();";

            var parameters = new Dictionary<string, object>()
            {
                {"@ClientName",newClient.ClientName },{"@Phone",newClient.Phone }
                ,{"@Email",newClient.Email },{"@TotalOrders",newClient.TotalOrders }
                ,{"@TotalPurchaseValue",newClient.TotalPurchaseValue }


            };

            // ConnectDataExcuteScalar returns -1 on a failed INSERT (and 0 for no result),
            // so only a positive identity means the row was actually created.
            int NewClientID = ConnectDataExcuteScalar(ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);

            if (NewClientID <= 0)
            {
                return false;
            }

            newClient.ClientID = NewClientID;

            return true;
        }

        public static bool AddNewUser(ref ClsUser newUser, string PasswordHash, string Permissions)
        {
            if (IsUserExsist(newUser.UserID))
            {
                return false; // User already exists
            }

            string Query = "INSERT INTO Users (UserName, FullName, Email, Password, Permissions) " +
                "VALUES (@UserName, @FullName, @Email, @Password, @Permissions); "
                + "SELECT SCOPE_IDENTITY();";
            var parameters = new Dictionary<string, object>()
            {
                {"@UserName",newUser.UserName},{"@FullName",newUser.FullName }
                ,{"@Email",newUser.Email },{"@Password",PasswordHash }
                ,{"@Permissions",Permissions }
            };

            // Same contract as AddNewClient: only a positive identity is a successful INSERT.
            int NewUserID = ConnectDataExcuteScalar(ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);

            if (NewUserID <= 0)
            {
                return false;
            }

            newUser.UserID = NewUserID;

            return true;
        }
       
        public static bool RemoveClient(int ClientID)
        {
            string Query = "DELETE FROM Clients WHERE ClientID = @ClientID";
            var parameters = new Dictionary<string, object>
            {
                { "@ClientID", ClientID }
            };
            int rowsAffected = ConnectDatabaseExcuteNonQuery(ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);
            return rowsAffected > 0; // Return true if at least one row was affected
        }
      
        public static bool RemoveUser(int UserID)
        {
            string Query = "DELETE FROM Users WHERE UserID = @UserID";
           
            var parameters = new Dictionary<string, object>
            {
                { "@UserID", UserID }
            };

            int rowsAffected = ConnectDatabaseExcuteNonQuery(ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);
            return rowsAffected > 0; // Return true if at least one row was affected
        }

        public static bool RemoveUser(int UserID, ClsUser User)
        {
            string Query = "DELETE FROM Users WHERE UserID = @UserID";

            var parameters = new Dictionary<string, object>
            {
                { "@UserID", UserID }
            };

            int rowsAffected = ConnectDatabaseExcuteNonQuery(ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);
            return rowsAffected > 0; // Return true if at least one row was affected
        }

        public static bool UpdateClient(ClsClient.ClsClient UpdatedClient)
        {
            string Query = "UPDATE Clients SET ClientName = @ClientName, Phone =@Phone, Email =@Email ,TotalOrders = @TotalOrders ,TotalPurchaseValue=@TotalPurchaseValue WHERE ClientID = @ClientID";

            var parameters = new Dictionary<string, object>()
            {
                {"@ClientName",UpdatedClient.ClientName}, {"@Phone",UpdatedClient.Phone },
                { "@Email",UpdatedClient.Email} , {"@TotalOrders",UpdatedClient.TotalOrders },
                { "@TotalPurchaseValue",UpdatedClient.TotalPurchaseValue} , {"@ClientID" ,UpdatedClient.ClientID}
            };

            int EffctedRows = ConnectDatabaseExcuteNonQuery(ClsDataAccessSettings.ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);

            return EffctedRows > 0;
        }

        // A null PasswordHash leaves the stored password untouched.
        public static bool UpdateUser(ClsUser UpdatedUser, string Permissions, string PasswordHash)
        {
            string Query = PasswordHash == null
                ? "UPDATE Users SET UserName = @UserName, FullName=@FullName, Email=@Email ,Permissions=@Permissions WHERE UserID = @UserID"
                : "UPDATE Users SET UserName = @UserName, FullName=@FullName, Email=@Email ,Password=@Password ,Permissions=@Permissions WHERE UserID = @UserID";

            var parameters = new Dictionary<string, object>()
            {
                {"@UserName",UpdatedUser.UserName },{ "@FullName",UpdatedUser.FullName},
                { "@Email",UpdatedUser.Email},
                { "@Permissions", Permissions} , {"@UserID",UpdatedUser.UserID}
            };

            if (PasswordHash != null)
            {
                parameters.Add("@Password", PasswordHash);
            }

            int EffctedRows = ConnectDatabaseExcuteNonQuery(ClsDataAccessSettings.ClsDataAcessSettings.ConnectingCRMproject, Query, parameters);

            return EffctedRows > 0;
        }

        public static bool GetUser(int UserID, ref ClsUser user)
        {
            var Parameter = new Dictionary<string, object>()
            {
                {"@UserID", UserID}
            };

            SqlDataReader reader = ConnectDatabaseExecuteReader(ClsDataAcessSettings.ConnectingCRMproject, "select UserID, UserName, FullName, Email, Permissions from Users where UserID = @UserID", Parameter);

            if (reader.Read() && reader != null)
            {
                user.UserID = (int)reader["UserID"];
                user.UserName = reader["UserName"].ToString();
                user.FullName = reader["FullName"].ToString();
                user.Email = reader["Email"].ToString();
                user.Permissions = (enPermissions)Enum.Parse(typeof(enPermissions), reader["Permissions"].ToString());
                return true;
            }

            return false;
        }
    }
}