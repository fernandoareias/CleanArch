



using System.Threading.Tasks;
using CleanArch.Application.DTOs;
using CleanArch.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("v1/api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll(){
            var result = await _categoryService.GetCategories();
            if(result == null) return NotFound();
            return Ok(result);
        }


        [HttpGet]
        [Route("{idCategories}")]
        public async Task<IActionResult> GetBuId(int idCategories){
            var result = await  _categoryService.GetById(idCategories);
            if(result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody]CategoryDTO model){
            await _categoryService.Create(model);
            
            return Ok();
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Update([FromBody]CategoryDTO model){
            var result = await _categoryService.Update(model);
            
            return Ok(result);
        }


        [HttpDelete]
        [Route("{idCategory}")]
        public async Task<IActionResult> Delete(int idCategory){
            await _categoryService.Remove(idCategory);
            
            return Ok();
        }
        
    }
}