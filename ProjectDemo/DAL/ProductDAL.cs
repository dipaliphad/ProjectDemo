using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ProjectDemo.DAL
{
    public class ProductDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public ProductDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> list = new List<Product>();
            string str = "select * from Product";
            cmd = new SqlCommand(str, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Product p = new Product();
                    p.product_id = Convert.ToInt32(dr[" product_id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToInt32(dr["Price"]);
                    p.category_id = Convert.ToInt32(dr["category_id"]);
                    list.Add(p);
                }
                con.Close();
                return list;
            }
            else
            {
                con.Close();
                return list;
            }

        }
        public Product GetProductById(int id)
        {
            Product p = new Product();
            string str = "select * from Product where  product_id=@id";
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {

                    p.product_id = Convert.ToInt32(dr[" product_id"]);
                    p.Name = dr["Name"].ToString();
                    p.Price = Convert.ToInt32(dr["Price"]);
                    p.category_id = Convert.ToInt32(dr["category_id"]);

                }
                con.Close();
                return p;
            }
            else
            {
                con.Close();
                return p;
            }

        }
    }
}
