using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ValorProfsApi.Data.Entities;

namespace ValorProfsApi.Controllers
{
    /// <summary>
    /// RESTful  endpoints to handle products resource
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Return the list of all Products, with the basic information about the products.
        /// </summary>
        [HttpGet]
        public ActionResult<IEnumerable<ProductToListDto>> Get()
        {
            return Ok(new List<ProductToListDto>());
        }

        /// <summary>
        ///  Return all informations about the product with entered id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return Ok(new Product());
        }

        /// <summary>
        /// Insert the entered product in the DB
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Authorize(Roles ="Admin")]
        public void Post(Product value)
        {
        }

        /// <summary>
        ///  Modify the product with the entered id, after the modification 
        ///  the product will equal to the entered value.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void Put(int id, Product value)
        {
        }

        /// <summary>
        /// Delete the product with the entered id from the DB
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void Delete(int id)
        {
        }
    }
}
