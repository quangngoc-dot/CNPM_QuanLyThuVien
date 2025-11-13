using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers_V2
{
    [Route("api")]
    [ApiController]
    public class DocGiaController : ControllerBase
    {
        private readonly IDocGia _repo;
        public DocGiaController(IDocGia docgia) { 
            _repo = docgia;
        }
        [HttpGet("docgias")]
        public async Task<IActionResult> GetALl() { 
            var docgias=await _repo.GetDocGias();
            return Ok(new
            {
                data = docgias
            });
        }
        [HttpGet("docgias/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            DocGia docgia = await _repo.GetDocGia(id);
            if (docgia == null)
            {
                return NoContent();
            }
            return Ok(new
            {
                data = docgia
            });
        }
        [HttpPost("docgias")]
        public async Task<IActionResult> Create([FromBody] DocGia docgia)
        {
            if (docgia != null)
            {
                if (docgia.Email != null) {
                    bool existEmail = await _repo.ExistEmail(docgia.Email);
                    if (existEmail) {
                        return BadRequest(new
                        {
                            error = "ishasemail"
                        });
                    }
                }
                await _repo.CreateDocGia(docgia);
                return Created();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
