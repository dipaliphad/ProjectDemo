using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectDemo.DAL;
using ProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        ProductCURD curd;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
            curd = new ProductCURD(_context);
        }


        // GET: ProductController
        public IActionResult List()
        {
            try
            {
                var products_list = from q in _context.products
                                    join w in _context.categories
                                    on q.category_id equals w.category_id
                                    into Cat
                                    from w in Cat.DefaultIfEmpty()
                                    select new Product
                                    {
                                        product_id = q.product_id,
                                        Name = q.Name,
                                        disc = q.disc,
                                        Price = q.Price,
                                        Product_image = q.Product_image,
                                        category_id = q.category_id,
                                        category_Name = w == null ? "" : w.category_Name,
                                    };
                return View(products_list);
            }
            catch(Exception ex)
            {
                return View();
            }
          
        }
        public void LoadFile()
        {
            try
            {
                List<Product_Category> categories = new List<Product_Category>();
                categories = _context.categories.ToList();
                categories.Insert(0, new Product_Category { category_id = 0, Name = "please Select" });

                ViewBag.categories = categories;
            }
            catch(Exception ex)
            {

            }
        }

        // GET: ProductController/Details/5
       
        public IActionResult Details(int id)
        {
            var model = (curd.GetProductById(id));
            return View(model);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products prod)
        {
            try
            {
                int result = curd.AddProducts(prod);
                if (result == 1)
                    return RedirectToAction(nameof(List));
                else
                    return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(List));
            }
            catch
            {
                return View();
            }
        }
    }
}
