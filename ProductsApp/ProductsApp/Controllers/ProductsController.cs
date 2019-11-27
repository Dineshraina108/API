using System;
using ProductsApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        ProductEntities pdb = new ProductEntities();
        List<Product> products;
     /*   Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };*/

        public IEnumerable<Product> GetAllProducts()
        {
             products = pdb.Products.ToList();
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = pdb.Products.Where(x => x.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}
