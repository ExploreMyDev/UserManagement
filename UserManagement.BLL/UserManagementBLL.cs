#region IncludedNamespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain;
#endregion IncludedNamespaces

namespace UserManagement.BLL
{
    #region UserManagementBLL
    /// <summary>
    /// UserManagementBLL
    /// </summary>
    public class UserManagementBLL
    {
        #region AddNewUser
        /// <summary>
        /// AddNewUser
        /// </summary>
        /// <param name="name"></param>
        /// <param name="birthDate"></param>
        /// <returns></returns>
        public bool AddNewUser(string name, string birthDate)
        {
            try
            {
                return new UserManagementDAL.UserManagement().InsertUser(name, birthDate);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion AddNewUser

        #region SelectAllUsers
        /// <summary>
        /// SelectAllUsers
        /// </summary>
        /// <returns></returns>
        public List<User> SelectAllUsers()
        {
            try
            {
                return new UserManagementDAL.UserManagement().SelectUser();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion SelectAllUsers
    }
    #endregion UserManagementBLL
}
