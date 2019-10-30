using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain;

namespace UserManagementDAL
{
    public class UserManagement
    {
        public bool InsertUser(string name, string birthDate)
        {
            string DBcon = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=UserManagement; Integrated Security=true;";
            using (SqlConnection con = new SqlConnection(DBcon))
            {
                using (SqlCommand cmd = new SqlCommand("UserAddDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    cmd.Parameters.Add("@dateOfBirth", SqlDbType.VarChar).Value = birthDate;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            return true;
        }

        public List<User> SelectUser()
        {
            string DBcon = "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=UserManagement; Integrated Security=true;";
            SqlDataReader rd;
            List<User> userList = new List<User>();
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

            return userList;
        }
    }
}
