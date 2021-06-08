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
    public class ScoresController : ControllerBase
    {
        IScoreService _scoreService;

        public ScoresController(IScoreService _scoreService)
        {
            this._scoreService = _scoreService;
        }

        [HttpGet("GetByPlaceId")]
        public IActionResult GetByPlaceId(string id)
        {
            var result = _scoreService.GetByLocationId(id);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
        [HttpPost("Add")]
        public IActionResult Add(Score score)
        {
            var result = _scoreService.Add(score);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Score score)
        {
            var result = _scoreService.Delete(score);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Score score)
        {
            var result = _scoreService.Update(score);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest(result);
        }
    }
}
