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
    public class SolutionController : ControllerBase
    {

        private readonly ISolutionRepository _solutionRepository;
        private readonly IImageRepository _imageRepository;
        public SolutionController(ISolutionRepository solutionRepository, IImageRepository imageRepository)
        {
            _solutionRepository = solutionRepository;
            _imageRepository = imageRepository;
        }
        [Route("AddSolution")]
        [HttpPost]
        public IActionResult AddQuestion(SolutionData value)
        {
            var NewSolution = new Solution
            {
                Id = Guid.NewGuid(),
                DateAdded = value.DateAdded,
                Description = value.Description,
                QuestionId= value.QuestionId
            };
            _solutionRepository.AddEntity(NewSolution);
            if (value.Images != null)
            {
                _imageRepository.AddImageToSolution(value.Images, NewSolution.Id);
            }
            return Ok(new
            {
                QuestionId = value.QuestionId,
                SolutionId= NewSolution.Id
            });
        }

        [Route("EditSolution")]
        [HttpPut]
        public IActionResult Edit(Guid id, Solution value, List<Guid> ToBeDeletedImageIds)
        {
            try
            {
                _solutionRepository.EditEntity(id, value);
                if (ToBeDeletedImageIds != null)
                {
                    foreach (var item in ToBeDeletedImageIds)
                    {
                        _imageRepository.DeleteEntity(item);
                    }
                }
            }
            catch { return NoContent(); }
            return Ok(new
            {
                QuestionId = value.Id
            });
        }

        [Route("DeleteSolution")]
        [HttpDelete]
        public IActionResult DeleteQuestion(Guid id, Question value)
        {
            _solutionRepository.DeleteEntity(id);
            return Ok();
        }

        // GET: api/<controller>
        [Route("GetAllSolutions")]
        [HttpGet]
        public IActionResult GetAllQuestion(Guid id)
        {
            if(id != null)
            {
                return Ok(new { solution = _solutionRepository.GetWithId(id) });
            }
            return Ok(new { solutions = _solutionRepository.GetAll() });
        }

        [Route("GetAllSolutionsForQuestion")]
        [HttpGet]
        public IActionResult GetAllSolutionsForQuestion(Guid QuestionId)
        {
            return Ok(new { solutions = _solutionRepository.FindWhere(x=>x.Id==QuestionId) });
        }

        [Route("GetAllSolutionWithImages")]
        [HttpGet]
        public IActionResult GetAllQuestionsWithImages()
        {
            return Ok(new { solutions = _solutionRepository.GetSolutionsWithImages()});
        }

    }
}