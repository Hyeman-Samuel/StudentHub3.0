using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHubApi1.Models;
using StudentHubApi1.Models.ViewModel;
using StudentHubApi1.Repositories.Interfaces;

namespace StudentHubApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository )
        {
            _categoryRepository = categoryRepository;
        }

        [Route("AddCategory")]
        [HttpPost]
        public IActionResult AddCategory([FromBody]CategoryData value)
        {
            var Category = new Category
            {
              Id=Guid.NewGuid(),
              Name=value.Name
            };
            _categoryRepository.AddEntity(Category);
            return Ok(Category);
        }
        [Route("EditCategory")]
        [HttpPut]
        public IActionResult Edit(Category value)
        {
            _categoryRepository.EditEntity(value.Id, value);
            return Ok();
        }

        [Route("DeleteCategory")]
        [HttpDelete]
        public IActionResult DeleteCategory(Guid CategoryId)
        {
            _categoryRepository.DeleteEntity(CategoryId);
            return Ok();
        }

        // GET: api/<controller>
        [Route("GetAllCategories")]
        [HttpGet]
        public IActionResult GetAllCategories(Guid id)
        {
            if(id != null)
            {
                return  Ok(_categoryRepository.GetWithId(id));
            }
            return Ok(_categoryRepository.GetAll());
        }
    }
}