using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.VisualBasic;
namespace API.Controllers_V2
{
    [Route("api")]
    [ApiController]
    public class TaiLieuController : ControllerBase
    {
        private readonly ITaiLieuRepo _repo;
        public TaiLieuController(ITaiLieuRepo repo) { 
            _repo = repo;
        }
        [HttpGet("tailieus")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() 
        { 
            List<TaiLieu> taiLieus = await _repo.GetTaiLieus();
            return Ok(new
            {
                data = taiLieus
            });
        }
        [HttpGet("tailieus/NXB/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByNXB(int id) { 
            List<TaiLieu> taiLieus=await _repo.GetByNXB(id);
            if(taiLieus.Count == 0) return NoContent();
            return Ok(new
            {
                data = taiLieus
            });
        }
        [HttpGet("tailieus/tacgias/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTacGia(int id)
        {
            List<TaiLieu> taiLieus =await _repo.GetByTacGia(id);
            if(taiLieus?.Count == 0) return NoContent();
            return Ok(new
            {
                data = taiLieus
            });
        }

        [HttpGet("tailieus/theloais/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTheLoai(int id)
        {
            List<TaiLieu> taiLieus = await _repo.GetByTheLoai(id);
            if (taiLieus?.Count == 0) return NoContent();
            return Ok(new
            {
                data = taiLieus
            });
        }
    }
}
