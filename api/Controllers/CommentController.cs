using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace api.Controllers
{
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommnetRepo _commentrepo;
        private readonly IStockRepo _stockrepo;

        public CommentController(ICommnetRepo commentrepo, IStockRepo stockRepo)
        {
            _commentrepo = commentrepo;
            _stockrepo = stockRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comments = await _commentrepo.GetAllAsync();
            var commentDto = comments.Select(c => c.ToCommentDto());
            if (comments == null)
                return NotFound("No comments found.");
            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comment = await _commentrepo.GetByIdAsync(id);
            if (comment == null)
                return NotFound($"Comment with ID {id} not found.");
            return Ok(comment.ToCommentDto());
        }

        //create
        [HttpPost("{stockid:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockid, CreateCommentDto commentDto)

        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!await _stockrepo.StockExists(stockid))
            {
                return NotFound(" StockId dont Exist");
            }
            var commentModel = commentDto.ToCommentFromCreate(stockid);
            await _commentrepo.CreateAsync(commentModel);
            return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody] UpdateCommentDto updateCommentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comment = await _commentrepo.UpdateAsync(id, updateCommentDto.ToCommentFromUpdate());
            if (comment == null)
            {
                NotFound("Comment not found");
            }
            return Ok(comment.ToCommentDto());

        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var comment=await _commentrepo.DeleteAsync(id);
            if (comment == null)
            {
                NotFound("Comment not found");
            }
            return Ok(comment);
        }
        
    }
} 