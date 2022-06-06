using AutoMapper;
using Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ServerNet.Dtos;
using ServerNet.Models;
using Newtonsoft.Json;
using ServerNet.Repository;

namespace ServerNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper _mapper;


        public ProductsController(IMapper mapper,IProductRepository productRepository)
        {
            _mapper = mapper;
            this.productRepository = productRepository;
        }

        [HttpGet(Name = "get-all-products")]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductParametersInfo productParameters)
        {
            var productParametersEntity = _mapper.Map<ProductParameters>(productParameters);
            var products = await productRepository.GetProductsAsync(productParametersEntity);

            var metadata = new
            {
                products.TotalCount,
                products.PageSize,
                products.CurrentPage,
                products.TotalPages,
                products.HasNext,
                products.HasPrevious
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            var productsResult = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productsResult);
        }
    }
}