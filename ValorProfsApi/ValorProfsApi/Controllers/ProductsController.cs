using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ValorProfsApi.Dtos;
using ValorProfsApi.Data.Entities;
using ValorProfsApi.Data.Repositories;
using AutoMapper;
using System;

namespace ValorProfsApi.Controllers
{
    /// <summary>
    /// RESTful  endpoints to handle products.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Creates a ProductsController.
        /// </summary>
        /// <param name="productsRepository"></param>
        /// <param name="mapper"></param>
        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            this._productsRepository = productsRepository;
            this._mapper = mapper;
        }

        /// <summary>
        /// Returns the list of all Products, with the basic information about the products.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductToListDto>), 200)]
        public IActionResult Get()
        {
            List<ProductToListDto> result = new List<ProductToListDto>();

            List<Product> products = this._productsRepository.Select();
            
            foreach (var product in products)
            {
                result.Add(this._mapper.Map<ProductToListDto>(product));
            }

            return Ok(result);
        }

        /// <summary>
        ///  Returns all informations about the product with entered id.
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(typeof(long), 404)]
        public IActionResult Get(long id)
        {
            Product product = this._productsRepository.Select(id);

            if (product == null)
            {
                return NotFound(id);
            }
            return Ok(product);
        }

        /// <summary>
        /// Inserts the entered product in the DB.
        /// </summary>
        /// <param name="productToCreate"></param>
        [HttpPost]
        [Authorize(Roles ="Admin")]
        [ProducesResponseType(typeof(Product), 201)]
        [ProducesResponseType(401)]
        public IActionResult Post(ProductToCreateDto productToCreate)
        {
            var product = this._mapper.Map<Product>(productToCreate);
            product.DateCreated = DateTime.UtcNow;
            long id = this._productsRepository.Insert(product);

            return Created(id.ToString(), product);
        }

        /// <summary>
        ///  Modifies the product with the entered id, after the modification 
        ///  the product will equal to the entered value.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Product), 201)]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(401)]
        public IActionResult Put(long id, ProductToUpdateDto productToUpdate)
        {            
            var product = this._mapper.Map<Product>(productToUpdate);

            Product productFromDb = this._productsRepository.Select(id);
            if (productFromDb == null)
            {
                product.DateCreated = DateTime.UtcNow;
                long newId = this._productsRepository.Insert(product);                
                return Created(newId.ToString(), product);
            }            
            this._productsRepository.Update(productFromDb.Id, product);
            return Ok(product);
        }

        /// <summary>
        /// Deletes the product with the entered id from the DB.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(long), 200)]
        [ProducesResponseType(typeof(long), 404)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            Product productFromDb = this._productsRepository.Select(id);
            if (productFromDb != null)
            {
                this._productsRepository.Delete(id);
                return Ok(id);
            }
            return NotFound(id);
        }
    }
}
