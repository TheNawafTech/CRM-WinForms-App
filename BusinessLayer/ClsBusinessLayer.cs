using ClsUser_Person;
using nClsDataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ClsUser_Person.ClsUser;
using static System.Net.Mime.MediaTypeNames;

namespace ClsBusinessLayer
{
    public class ClsBusinessLayer
    {
        ClsUser User = new ClsUser();

        static public ClsUser LogInUser(ref string username, ref string password, ref ClsUser user)
        {
            user.UserName = username;
            user.Password = password;

            return ClsDataLayer.GetUser(ref user);
        }

        static public bool GetAllRecords(ref DataTable Dt, string Query)
        {
            return ClsDataLayer.GetAllRecords(ref Dt, Query);
        }

        static public bool AddNewClient(ClsClient.ClsClient newClient)
        {
            return ClsDataLayer.AddNewClient(ref newClient);
        }

        static public bool AddNewUser(ref ClsUser user, string Permissions)
        {
            return ClsDataLayer.AddNewUser(ref user, Permissions);
        }

        static public bool RemoveClient(int ClientID)
        {
            return ClsDataLayer.RemoveClient(ClientID);
        }

        static public bool RemoveUser(int UserID)
        {
            return ClsDataLayer.RemoveUser(UserID);
        }

        static public bool RemoveUser(int UserID, ref ClsUser User)
        {
            return ClsDataLayer.RemoveUser(UserID, User);
        }

        public static bool GetClient(int ID, ref ClsClient.ClsClient client)
        {
            return ClsDataLayer.GetClient(ID, ref client);
        }

        public static bool IsClientExsist(int ClientID)
        {
            return ClsDataLayer.IsClientExsist(ClientID);
        }
        public static bool IsClientExsist(int ClientID, ref ClsClient.ClsClient client)
        {
            return ClsDataLayer.IsClientExsist(ClientID, ref client);
        }

        public static bool IsUserExsist(int UserID, ref ClsUser User)
        {
            return ClsDataLayer.IsUserExsist(UserID, ref User);
        }

        static public bool UpdateClient(ClsClient.ClsClient client)
        {
            return ClsDataLayer.UpdateClient(client);
        }

        static public bool IsUerNameExsist(string UserName, ClsUser user)
        {
            return ClsDataLayer.IsUserNameExsist(UserName, user);
        }

        static public bool IsUerNameExsist(string UserName)
        {
            return ClsDataLayer.IsUserNameExsist(UserName);
        }

        static public bool UpdateUser(ClsUser user, string Permissions)
        {
            return ClsDataLayer.UpdateUser(user, Permissions);
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

        public static bool IsValidDecimal(string input, decimal Value)
        {
            return decimal.TryParse(input, out Value);
        }

        public static bool AreFieldsEmpty0(string Text)
        {
            return string.IsNullOrWhiteSpace(Text);
        }

        public static string txtEnter(string text, string placeholder)
        {
            return text == placeholder ? "" : text;

        }

        public static string txtLeave(string Text, string placeholder)
        {
            return (string.IsNullOrEmpty(Text) ? placeholder : Text);
        }

        static public bool GetUser(int UserID, ref ClsUser user)
        {
            return ClsDataLayer.GetUser(UserID, ref user);
        }

        static public bool IsUserExsist(int UserID)
        {
            return ClsDataLayer.IsUserExsist(UserID);
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

