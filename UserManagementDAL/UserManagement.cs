#region IncludedNamespaces
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain;
#endregion IncludedNamespaces

namespace UserManagementDAL
{
    #region UserManagement
    /// <summary>
    /// UserManagement
    /// </summary>
    public class UserManagement
    {
        #region DBcon
        /// <summary>
        /// DBcon
        /// </summary>
        private string DBcon = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=UserManagement; Integrated Security=true;";
        #endregion DBcon

        #region InsertUser
        public bool InsertUser(string name, string birthDate)
        {
            bool status = false;
            try
            {
                
                using (SqlConnection con = new SqlConnection(DBcon))
                {
                    using (SqlCommand cmd = new SqlCommand("UserAddDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                        cmd.Parameters.Add("@dateOfBirth", SqlDbType.VarChar).Value = birthDate;

                        con.Open();
                        cmd.ExecuteNonQuery();
                        status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return status;
        }
        #endregion InsertUser

        #region SelectUser
        /// <summary>
        /// SelectUser
        /// </summary>
        /// <returns></returns>
        public List<User> SelectUser()
        {
            SqlDataReader rd;
            List<User> userList = new List<User>();

            try
            {
                using (SqlConnection con = new SqlConnection(DBcon))
                {
                    using (SqlCommand cmd = new SqlCommand("UserGetAllDetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        con.Open();
                        rd = cmd.ExecuteReader();

                        while (rd.Read())
                        {
                            User obj = new User();
                            obj.Name = rd[1].ToString();
                            obj.DateOfBirth = DateTime.Parse(rd[2].ToString()).ToString("MM/dd/yyyy");
                            userList.Add(obj);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return userList;
        }
        #endregion SelectUser
    }
    #endregion UserManagement
}
