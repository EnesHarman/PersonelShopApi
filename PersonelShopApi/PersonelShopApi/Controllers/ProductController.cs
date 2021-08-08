using Business.Abstract;
using Business.Utilities.Abstract;
using Core.Utilities.Mail.Abstract;
using Entity.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonelShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductService _productService;
        IMailService _mailService;

        public ProductController(IProductService productService, IParser jwtParser,IMailService mailService)
        {
            _productService = productService;
            _mailService = mailService;
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetProducts()
        {
            //var re = Request;
            //var headers = re.Headers;
            //var token = headers.GetCommaSeparatedValues("Authorization").First().Split(" ")[1];
            ////var handler = new JwtSecurityTokenHandler();
            ////var data = handler.ReadJwtToken(token);
            var result = _productService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet]
        public IActionResult GetProduct(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public IActionResult AddProduct([FromBody] ProductDto product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("category/{categoryId}")]
        public IActionResult GetProductByCategory(int categoryId)
        {
            var result = _productService.GetListByCategoryId(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult UpdateProduct(ProductDto product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(ProductDto product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        

    }
}
