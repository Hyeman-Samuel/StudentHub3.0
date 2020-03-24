using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentHubApi1.Repositories.Interfaces;

namespace StudentHubApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReactionController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly ISolutionRepository _solutionRepository;
        public ReactionController(ICommentRepository commentRepository,IQuestionRepository questionRepository,ISolutionRepository solutionRepository)
        {
            _commentRepository = commentRepository;
            _questionRepository = questionRepository;
            _solutionRepository = solutionRepository;
        }
        [Route("AddUpVoteToSolution")]
        [HttpPost]
        public IActionResult AddUpVote(Guid SolutionId)
        {
            var solution = _solutionRepository.GetWithId(SolutionId);
            solution.Upvotes += 1;
            _solutionRepository.EditEntity(SolutionId, solution);
            return Ok(solution);
        }



        [Route("RemoveUpVoteToSolution")]
        [HttpPost]
        public IActionResult AddDownVote(Guid SolutionId)
        {
            var solution = _solutionRepository.GetWithId(SolutionId);
            solution.Upvotes -= 1;
            _solutionRepository.EditEntity(SolutionId, solution);
            return Ok(solution);
        }

        [Route("FlagQuestion")]
        [HttpPost]
        public IActionResult FlagQuestion(Guid QuestionId)
        {
            var Question = _questionRepository.GetWithId(QuestionId);
            Question.Flags += 1;
            _questionRepository.EditEntity(QuestionId, Question);
            return Ok(Question);
        }

        [Route("FlagSolution")]
        [HttpPost]
        public IActionResult FlagSolution(Guid SolutionId)
        {
            var Solution = _solutionRepository.GetWithId(SolutionId);
            Solution.Flags += 1;
            _solutionRepository.EditEntity(SolutionId, Solution);
            return Ok(Solution);
        }

        [Route("FlagComment")]
        [HttpPost]
        public IActionResult FlagComment(Guid CommentId)
        {
            var Comment = _commentRepository.GetWithId(CommentId);
            Comment.Flags += 1;
            _commentRepository.EditEntity(CommentId, Comment);
            return Ok(Comment);
        }
    }
}