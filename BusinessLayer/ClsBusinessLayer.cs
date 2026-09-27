using ClsUser_Person;
using nClsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ClsUser_Person.ClsUser;
using static System.Net.Mime.MediaTypeNames;

namespace ClsBusinessLayer
{
    // Outcome of a read. NotFound means the query ran and found nothing;
    // Failure means the database could not be read at all.
    public enum enOperationStatus
    {
        Success,
        NotFound,
        Failure
    }

    public class ClsBusinessLayer
    {
        // Shown by the UI for enOperationStatus.Failure. Technical details only go to Trace.
        public const string SystemErrorMessage = "A system error occurred while accessing the database. Please try again.";

        // The data layer lets technical exceptions propagate; this layer is where they are
        // recorded and turned into a Failure result, so they never reach the UI.
        static void _TraceFailure(string Operation, Exception ex)
        {
            Trace.TraceError("{0} failed: {1}", Operation, ex);
        }

        // The DAL only looks the user up by name; the password is verified here, never in SQL.
        // NotFound = unknown user name or wrong password; Failure = the check could not run.
        static public enOperationStatus LogInUser(string UserName, string Password, ref ClsUser User)
        {
            ClsUser candidate = new ClsUser();
            string PasswordHash = null;

            try
            {
                if (!ClsDataLayer.GetUserByUserName(UserName?.Trim(), ref candidate, ref PasswordHash))
                {
                    return enOperationStatus.NotFound;
                }
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(LogInUser), ex);
                return enOperationStatus.Failure;
            }

            if (!PasswordHasher.VerifyPassword(Password, PasswordHash))
            {
                return enOperationStatus.NotFound;
            }

            User = candidate;
            return enOperationStatus.Success;
        }

        // Success = rows loaded; NotFound = no clients (Dt still has the columns).
        static public enOperationStatus GetAllClients(ref DataTable Dt)
        {
            try
            {
                return ClsDataLayer.GetAllClients(ref Dt) ? enOperationStatus.Success : enOperationStatus.NotFound;
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(GetAllClients), ex);
                return enOperationStatus.Failure;
            }
        }

        // Success = rows loaded; NotFound = no users (Dt still has the columns).
        static public enOperationStatus GetAllUsers(ref DataTable Dt)
        {
            try
            {
                return ClsDataLayer.GetAllUsers(ref Dt) ? enOperationStatus.Success : enOperationStatus.NotFound;
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(GetAllUsers), ex);
                return enOperationStatus.Failure;
            }
        }

        static public bool AddNewClient(ClsClient.ClsClient newClient)
        {
            try
            {
                return ClsDataLayer.AddNewClient(ref newClient);
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(AddNewClient), ex);
                return false;
            }
        }

        // User names are unique, compared case-insensitively like the database collation.
        // The UNIQUE constraint on Users.UserName is the final guard against concurrent inserts.
        static public bool AddNewUser(ref ClsUser user, string Permissions)
        {
            user.UserName = user.UserName?.Trim();
            string Password = user.Password;
            user.Password = null;

            try
            {
                if (ClsDataLayer.IsUserNameExsist(user.UserName))
                {
                    return false;
                }

                return ClsDataLayer.AddNewUser(ref user, PasswordHasher.HashPassword(Password), Permissions);
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(AddNewUser), ex);
                return false;
            }
        }

        static public bool RemoveClient(int ClientID)
        {
            try
            {
                return ClsDataLayer.RemoveClient(ClientID);
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(RemoveClient), ex);
                return false;
            }
        }

        static public bool RemoveUser(int UserID)
        {
            try
            {
                return ClsDataLayer.RemoveUser(UserID);
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(RemoveUser), ex);
                return false;
            }
        }

        public static enOperationStatus GetClient(int ID, ref ClsClient.ClsClient client)
        {
            try
            {
                return ClsDataLayer.GetClient(ID, ref client) ? enOperationStatus.Success : enOperationStatus.NotFound;
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(GetClient), ex);
                return enOperationStatus.Failure;
            }
        }

        static public bool UpdateClient(ClsClient.ClsClient client)
        {
            try
            {
                return ClsDataLayer.UpdateClient(client);
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(UpdateClient), ex);
                return false;
            }
        }

        // Success = the user name is already taken by another user; NotFound = it is free.
        static public enOperationStatus IsUerNameExsist(string UserName, ClsUser user)
        {
            try
            {
                return ClsDataLayer.IsUserNameExsist(UserName?.Trim(), user) ? enOperationStatus.Success : enOperationStatus.NotFound;
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(IsUerNameExsist), ex);
                return enOperationStatus.Failure;
            }
        }

        // Success = the user name is already taken; NotFound = it is free.
        static public enOperationStatus IsUerNameExsist(string UserName)
        {
            try
            {
                return ClsDataLayer.IsUserNameExsist(UserName?.Trim()) ? enOperationStatus.Success : enOperationStatus.NotFound;
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(IsUerNameExsist), ex);
                return enOperationStatus.Failure;
            }
        }

        // An empty user.Password keeps the current password unchanged.
        // The user name may stay the same, but must not belong to another user.
        static public bool UpdateUser(ClsUser user, string Permissions)
        {
            user.UserName = user.UserName?.Trim();
            string PasswordHash = string.IsNullOrEmpty(user.Password) ? null : PasswordHasher.HashPassword(user.Password);
            user.Password = null;

            try
            {
                if (ClsDataLayer.IsUserNameExsist(user.UserName, user))
                {
                    return false;
                }

                return ClsDataLayer.UpdateUser(user, Permissions, PasswordHash);
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(UpdateUser), ex);
                return false;
            }
        }

        // Validation :

        public static bool IsValidPhone(string Phone)
        {
            return (Regex.IsMatch(Phone, @"^[0-9+\-() ]+$"));
        }

        public static bool IsValidEmail(string Email)
        {
            return (Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"));
        }

        public static bool IsValidInt(string input, int Value)
        {
            return int.TryParse(input, out Value);
        }

        // Largest value that fits Clients.TotalPurchaseValue DECIMAL(10,2).
        public const decimal MaxPurchaseValue = 99999999.99m;

        // Purchase values are always entered as 1234.56 (dot decimal separator, no thousands
        // separator, no sign), regardless of the machine's regional settings. Ambiguous input
        // such as "700,50" is rejected instead of being read as 70050.
        public static bool TryParsePurchaseValue(string Text, out decimal Value)
        {
            if (!decimal.TryParse(Text?.Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out Value))
            {
                return false;
            }

            // At most 2 decimal places (no silent rounding) and within the column range.
            return decimal.Round(Value, 2) == Value && Value <= MaxPurchaseValue;
        }

        public static string txtEnter(string text, string placeholder)
        {
            return text == placeholder ? "" : text;

        }

        public static string txtLeave(string Text, string placeholder)
        {
            return (string.IsNullOrEmpty(Text) ? placeholder : Text);
        }

        static public enOperationStatus GetUser(int UserID, ref ClsUser user)
        {
            try
            {
                return ClsDataLayer.GetUser(UserID, ref user) ? enOperationStatus.Success : enOperationStatus.NotFound;
            }
            catch (Exception ex)
            {
                _TraceFailure(nameof(GetUser), ex);
                return enOperationStatus.Failure;
            }
        }

        public static bool AreFildsEmpty(params string[] Filds)
        {
            foreach (var Text in Filds)
            {
                if (Text.StartsWith("Enter") || Text.StartsWith("Start") || string.IsNullOrWhiteSpace(Text))
                {
                    return false;
                }
            }

            return true;
        }


        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Regular expression to match phone numbers in the format +XXX-XXXX-XXXX
            string pattern = @"^\+\d{12}$";
            return Regex.IsMatch(phoneNumber, pattern);

        }


    }
}

