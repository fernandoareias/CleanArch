



using System.Threading.Tasks;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("v1/api/products")]
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll(){
            var result = await _productService.GetProducts();
            if(result == null) return NotFound();
            return Ok(result);
        }


        [HttpGet]
        [Route("{idProduct}")]
        public async Task<IActionResult> GetById(int idProduct){
            var result = await  _productService.GetById(idProduct);
            if(result == null) return NotFound();
            return Ok(result);
        }

       /* [HttpGet]
        [Route("{idProduct}/categories")]
        public async Task<IActionResult> GetByIdWithCategory(int idProduct){
            var result = await  _productService.GetProductCategory(idProduct);
            if(result == null) return NotFound();
            return Ok(result);
        }*/


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody]ProductDTO model){
            await _productService.Create(model);
            
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody]ProductDTO model){
            await _productService.Update(model);
            
            return Ok();
        }


        [HttpDelete]
        [Route("{idCategory}")]
        public async Task<IActionResult> Delete(int idCategory){
            await _productService.Remove(idCategory);
            
            return Ok();
        }
        
    }
}