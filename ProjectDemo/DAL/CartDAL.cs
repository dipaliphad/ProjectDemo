using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ProjectDemo.DAL
{
    public class CartDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        public CartDAL()
        {
            con = new SqlConnection(Startup.ConnectionString);
        }
        private bool CheckCartData(Cart cart)
        {

            return true;
        }
        public int AddToCart(Cart cart)
        {
            bool result = CheckCartData(cart);
            if (result == true)
            {
                string qry = "insert into Cart values(@user_id,@product_id)";
                cmd = new SqlCommand(qry, con);
                cmd.Parameters.AddWithValue("@user_id", cart.user_id);
                cmd.Parameters.AddWithValue("@product_id", cart.product_id);
                con.Open();
                int res = cmd.ExecuteNonQuery();
                con.Close();
                return res;
            }
            else
            {
                return 2;
            }
        }

        public List<Product> ViewProductsFromCart(string user_id)
        {
            List<Product> plist = new List<Product>();
            string qry = "select p.product_id,p.Name,p.Price,p.category_id, c. cart_id,c.user_id from Product p " +
                        " inner join Cart c on c. cart_id = p.product_id " +
                        " where c.user_id = @id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(user_id));
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.product_id = Convert.ToInt32(dr["product_id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToInt32(dr["Price"]);
                    p.category_id = Convert.ToInt32(dr["category_id"]);
                    plist.Add(p);
                }
                con.Close();
                return plist;
            }
            else
            {
                return plist;
            }
        }
        public int RemoveFromCart(int id)
        {

            string qry = "delete from Cart where  cart_id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
