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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IImageRepository _imageRepository;
        public QuestionController(IQuestionRepository questionRepository,IImageRepository imageRepository)
        {
            _questionRepository = questionRepository;
            _imageRepository = imageRepository;
        }
        [Route("AddQuestion")]
        [HttpPost]
        public IActionResult AddQuestion(QuestionData value)
        {
            var NewQuestion = new Question
            {
                Id = Guid.NewGuid(),
                Title = value.Title,
                DateAdded = value.DateAdded,
                Description = value.Description,
                CategoryId = value.CategoryId
            };
            _questionRepository.AddEntity(NewQuestion);
            if(value.Images != null)
            {
                _imageRepository.AddImageToQuestion(value.Images,NewQuestion.Id);
            }
            return Ok(new {
                QuestionId=NewQuestion.Id
            });
        }

        [Route("EditQuestions")]
        [HttpPut]
        public IActionResult Edit(Guid id, Question value, List<Guid> ToBeDeletedImageIds)
        {
            try { 
            _questionRepository.EditEntity(id, value);
                if(ToBeDeletedImageIds != null)
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

        [Route("DeleteQuestions")]
        [HttpDelete]
        public IActionResult DeleteQuestion(Guid id, Question value)
        {
            _questionRepository.DeleteEntity(id);
             return  Ok();
        }

        // GET: api/<controller>
        [Route("GetQuestions")]
        [HttpGet]
        public IActionResult GetQuestion(Guid id)
        {
            if(id != null)
            {
                return Ok(new { question = _questionRepository.GetWithId(id) });
            }
            return Ok(new { questions = _questionRepository.GetAll() });
        }


        [Route("GetAllQuestionsWithImages")]
        [HttpGet]
        public IActionResult GetAllQuestionsWithImages()
        {
            return Ok(new {questions= _questionRepository.GetAllQuestionsWithImages() });
        }
    }
}