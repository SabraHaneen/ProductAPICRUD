using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using System.Reflection;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
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
    }
}
