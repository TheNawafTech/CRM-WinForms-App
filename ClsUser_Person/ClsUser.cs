using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsUser_Person
{
    public class ClsUser
    {
        [Flags]
        public enum enPermissions
        {
            All = -1, ListClients = 1, AddNewClient = 2, DeleteClient = 4,
            UpdateClients = 8, FindClient = 16, Tranactions = 32, ManageUsers = 64, LoginRegister = 128
        };

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public enPermissions Permissions { get; set; }

        public ClsUser(string userName, string fullName, string email, string password, int permissions)
        {
            UserName = userName;
            FullName = fullName;
            Email = email;
            Password = password;
            Permissions = (enPermissions)permissions;
        }

        public ClsUser(string userName, string fullName, string email, string password)
        {
            UserName = userName;
            FullName = fullName;
            Email = email;
            Password = password;
        }

        public ClsUser()
        {

        }

    }

} 
     
