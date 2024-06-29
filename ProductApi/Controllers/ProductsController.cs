using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Data;
using ProductApi.Models;
using System.Reflection;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
   /*     //need to reach product table from DbContext so i will create constructor 
        ApplicationDbContext context;

        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet] 
        public ActionResult GetAllProduct()
        {
            var products = context.Product;
            return Ok(products);
        }
        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            var products = context.Product.Find(id);
            //find search local in cach memory
            //firstordefualt send req to search in data base
            if (products is null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpPost]
        public ActionResult AddProduct(Products req)
        {
            if (req == null)
            {
                return BadRequest();
            }
           

           context.Product.Add(req);// add locally
            context.SaveChanges();//will be added to database
            //will nt add id value remotlly or will have 500 error response
            return CreatedAtAction(nameof(AddProduct), req);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Products req)
        {
            var updatedProduct =context.Product.Find(id);
            if (updatedProduct is null)
            {
                return BadRequest();
            }
            updatedProduct.Name = req.Name;
            updatedProduct.Description = req.Description;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = context.Product.Find(id);
            if (product is null)
            {
                return NotFound();
            }
            context.Product.Remove(product);
            context.SaveChanges();
            return Ok();
        }*/
         List<Products> products = new List<Products>
         {
             new Products{Id=1,Name="Kids",Description="anything"},
             new Products{Id=2,Name="men",Description="anything"},
              new Products{Id=3,Name="women",Description="anything"},

         };
         //read Data
         [HttpGet("getAll")]
         public IActionResult GetAll()
         {
             return Ok(products);
         }
         //get Data By Id
         [HttpGet("{id}")]
         public IActionResult getById(int Id)
         {
             var products = Products.First(product => product.Id == Id);
             if (products is null)
             {
                 return NotFound();
             }
             return Ok(products);
         }
         [HttpPost]
         public IActionResult AddProduct(Products req)
         {
             if (req == null)
             {
                 return BadRequest();
             }
             var NewProduct = new Products
             {
                 Id = req.Id,
                 Name = req.Name,
                 Description = req.Description,
             };

             products.Add(NewProduct);
             return Ok(products);
         }
         [HttpPut("{Id}")]
         public IActionResult  Update( int id,Products req)
         {
             var updatedProduct = Products.FirstOrDefualt(product => product.Id == id);
             if(updatedProduct is null)
             {
                 return BadRequest();
             }
             updatedProduct.Name = req.Name;
             updatedProduct.Description = req.Description;
             return Ok();
         }
         [HttpDelete("{Id}")]
         public IActionResult Delete(int id)
         {
             var product=Products.FirstOrDefualt(products => products.Id == id);
             if(product is null)
             {
                 return NotFound();
             }
             products.Remove(product);
             return Ok();
         }
 

    }
}
