using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain;

namespace UserManagement.BLL
{
    public class UserManagementBLL
    {
        public bool AddNewUser(string name, string birthDate)
        {
            return new UserManagementDAL.UserManagement().InsertUser(name, birthDate);
        }

        public List<User> SelectAllUsers()
        {
            return new UserManagementDAL.UserManagement().SelectUser();
        }
    }
}
