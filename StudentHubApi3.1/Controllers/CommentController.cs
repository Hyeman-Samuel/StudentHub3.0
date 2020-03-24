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
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IImageRepository _imageRepository;
        public CommentController(ICommentRepository commentRepository, IImageRepository imageRepository)
        {
            _commentRepository = commentRepository;
            _imageRepository = imageRepository;
        }
        [Route("AddCommentToQuestion")]
        [HttpPost]
        public IActionResult AddCommentToQuestion(CommentData value)
        {
            var NewComment = new Comment
            {
                Id = Guid.NewGuid(),
                DateAdded = value.DateAdded,
                Description = value.Description,
                QuestionId = value.QuestionId
            };
            _commentRepository.AddEntity(NewComment);
            return Ok(NewComment);
        }



        [Route("AddCommentToSolution")]
        [HttpPost]
        public IActionResult AddCommentToSolution(CommentData value)
        {
            var NewComment = new Comment
            {
                Id = Guid.NewGuid(),
                DateAdded = value.DateAdded,
                Description = value.Description,
                SolutionId = value.SolutionId
            };
            _commentRepository.AddEntity(NewComment);
            return Ok(NewComment);
        }


        [Route("EditComment")]
        [HttpPut]
        public IActionResult Edit(Comment value)
        {
            try
            {
                _commentRepository.EditEntity(value.Id, value);
            }
            catch { return NoContent(); }
            return Ok(new
            {
                QuestionId = value.Id
            });
        }

        [Route("DeleteComment")]
        [HttpDelete]
        public IActionResult DeleteComment(Guid CommentId )
        {
            _commentRepository.DeleteEntity(CommentId);
            return Ok();
        }

        // GET: api/<controller>
        [Route("GetAllComments")]
        [HttpGet]
        public IActionResult GetAllComment()
        {
            return Ok(new {comments = _commentRepository.GetAll() });
        }

        [Route("GetAllCommentsForQuestion")]
        [HttpGet]
        public IActionResult GetAllComment(Guid QuestionId)
        {
            return Ok(new { comments = _commentRepository.FindWhere(x => x.Id == QuestionId) });
        }

        // GET api/<controller>/5
        [Route("GetCommentById")]
        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return Ok(new { comment = _commentRepository.GetWithId(id) });
        }
    }
}