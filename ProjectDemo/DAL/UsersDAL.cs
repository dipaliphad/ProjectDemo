using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace ProjectDemo.DAL
{
    public class UsersDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public UsersDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public int UsersRegister(Users user)
        {

            string qry = "insert into UsersData values(@name,@email,@Contact_no,@pass,@role)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", user.Name);
            cmd.Parameters.AddWithValue("@email", user.Email);
            cmd.Parameters.AddWithValue("@contact", user.Contact_no);
            cmd.Parameters.AddWithValue("@pass", user.Password);
            cmd.Parameters.AddWithValue("@role", 2);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public Users UsersLogin(Users user)
        {
            Users users = new Users();
            string qry = "select * from UserData where Email=@email and Password=@Password";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("email", users.Email);
            cmd.Parameters.AddWithValue("@password", users.Password);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    users.user_id = Convert.ToInt32(dr["user_id"]);
                    users.Name = dr["Name"].ToString();
                    users.Email = dr["Email"].ToString();
                    users.role_id = Convert.ToInt32(dr["role_id"]);
                    
                }
                con.Close();
                return user;

            }
            else
            {
                return user;
            }
        }
    }
}
