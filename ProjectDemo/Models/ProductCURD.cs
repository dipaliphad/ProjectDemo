using ProjectDemo.DAL;
using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDemo.Controllers
{
    public class ProductCURD
    {
        private readonly ApplicationDbContext _context;

        public ProductCURD(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            var Product = _context.Products.Where(x => x.product_id == id).FirstOrDefault();
            if (Product != null)
                return Product;
            else
                return null;
        }
        public int AddProduct(Product prod)
        {
            _context.Products.Add(prod);
            int res = _context.SaveChanges();
            return res;

        }
        public int UpdateProduct(Product prod)
        {
            _context.Products.Update(prod);
            int res = _context.SaveChanges();
            return res;
        }

        internal int AddProducts(Products prod)
        {
            throw new NotImplementedException();
        }

        public int DeleteProduct(int id)
        {
            int res = 0;
            var product = _context.Products.Where(x => x.category_id == id).FirstOrDefault();
            if (product != null)
            {
                _context.Products.Remove(product);
                res = _context.SaveChanges();

            }
            return res;

        }
    }
}
