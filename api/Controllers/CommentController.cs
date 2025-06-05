using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommnetRepo _commentrepo;

        public CommentController(ICommnetRepo commentrepo)
        {
            _commentrepo = commentrepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var comments = await _commentrepo.GetAllAsync();
            var commentDto = comments.Select(c => c.ToCommentDto());
            if (comments == null)
                return NotFound("No comments found.");
            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var comment = await _commentrepo.GetByIdAsync(id);
            if (comment == null)
                return NotFound($"Comment with ID {id} not found.");
            return Ok(comment.ToCommentDto());
        }
    }
} 