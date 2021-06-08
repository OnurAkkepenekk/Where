using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        ICommentService _commentService;

        public CommentsController(ICommentService _commentService)
        {
            this._commentService = _commentService;
        }

        [HttpGet("GetByPlaceId")]
        public IActionResult GetByPlaceId(string id)
        {
            var result = _commentService.GetByLocationId(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(Comment comment)
        {
            var result = _commentService.Add(comment);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Comment comment)
        {
            var result = _commentService.Delete(comment);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Comment comment)
        {
            var result = _commentService.Update(comment);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
