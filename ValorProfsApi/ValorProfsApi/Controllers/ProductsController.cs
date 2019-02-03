using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ValorProfsApi.Dtos;
using ValorProfsApi.Data.Entities;
using ValorProfsApi.Data.Repositories;
using AutoMapper;
using System;
using System.Threading.Tasks;

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
        [ProducesResponseType(401)]
        public async Task<IActionResult> Get()
        {
            List<ProductToListDto> result = new List<ProductToListDto>();

            IEnumerable<Product> products = await this._productsRepository.SelectAsync();
            
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
        [ProducesResponseType(401)]
        public async Task<IActionResult> Get(long id)
        {
            Product product = await this._productsRepository.SelectAsync(id);

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
        [ProducesResponseType(403)]
        public async Task<IActionResult> Post(ProductToCreateDto productToCreate)
        {
            var product = this._mapper.Map<Product>(productToCreate);
            long id = await this._productsRepository.InsertAsync(product);
            return Created(id.ToString(), product);
        }

        /// <summary>
        ///  Modifies the product with the entered id, after the modification 
        ///  the product will equal to the entered value.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productToUpdate"></param>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(Product), 201)]
        [ProducesResponseType(typeof(Product), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Put(long id, ProductToUpdateDto productToUpdate)
        {
            Product productFromDb = await this._productsRepository.SelectAsync(id);
            if (productFromDb == null)
            {
                var product = this._mapper.Map<Product>(productToUpdate);
                long newId = await this._productsRepository.InsertAsync(product);   
                return Created(newId.ToString(), product);
            }      
            UpdateProduct(productToUpdate, productFromDb);
            await this._productsRepository.UpdateAsync(productFromDb.Id, productFromDb);
            return Ok(productFromDb);
        }

        private void UpdateProduct(ProductToUpdateDto src, Product dest)
        {
            if (src.Name != null)
            {
                dest.Name = src.Name;
            }
            if (src.Price != null)
            {
                dest.Price = src.Price.Value;
            }
            if (src.Available != null)
            {
                dest.Available = src.Available.Value;
            }
            if (src.Description != null)
            {
                dest.Description = src.Description;
            }
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
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete(long id)
        {
            Product productFromDb = await this._productsRepository.SelectAsync(id);
            if (productFromDb != null)
            {
                long deletedId = await this._productsRepository.DeleteAsync(productFromDb);
                return Ok(deletedId);
            }
            return NotFound(id);
        }
    }
}
