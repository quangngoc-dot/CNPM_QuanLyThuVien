using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;
namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class TaiLieuController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaiLieuController(IUnitOfWork unitofwork) { 
            _unitOfWork = unitofwork;
        }
        [HttpGet("tailieus")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() 
        { 
            List<TaiLieu> taiLieus = await _unitOfWork.tailieuRepo.GetTaiLieus();
            return Ok(taiLieus);
        }
        [HttpGet("tailieu/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            bool ishas = await _unitOfWork.tailieuRepo.ExistID(id);
            if (!ishas)
            {
                return NotFound();
            }
            TaiLieu? taiLieu = await _unitOfWork.tailieuRepo.GetByID(id);
            return Ok(taiLieu);
        }
        [HttpGet("tailieu")]
        public async Task<IActionResult> GetByName([FromBody] string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            List<TaiLieu> tailieus = await _unitOfWork.tailieuRepo.GetByName(name);
            return Ok(tailieus);
        }
        [HttpGet("tailieu/advanced")]
        public async Task<IActionResult> GetAdvanced([FromBody]TaiLieu tailieu)
        {
            List<TaiLieu> tailieus= await _unitOfWork.tailieuRepo.GetAdvanced(tailieu);
            return Ok(tailieus);
        }
        [HttpGet("tailieu/NXB/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByNXB(int id) { 
            List<TaiLieu> taiLieus=await _unitOfWork.tailieuRepo.GetByNXB(id);
            if(taiLieus.Count == 0) return NoContent();
            return Ok(taiLieus);
        }
        [HttpGet("tailieu/tacgia/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTacGia(int id)
        {
            List<TaiLieu> taiLieus =await _unitOfWork.tailieuRepo.GetByTacGia(id);
            if(taiLieus?.Count == 0) return NoContent();
            return Ok(taiLieus);
        }

        [HttpGet("tailieu/theloai/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTheLoai(int id)
        {
            List<TaiLieu> taiLieus = await _unitOfWork.tailieuRepo.GetByTheLoai(id);
            if (taiLieus?.Count == 0) return NoContent();
            return Ok(taiLieus);
        }
        [HttpPost("tailieu")]
        public async Task<IActionResult> Create(CreateTaiLieuDTO tailieudto)
        {
            if(tailieudto == null)
            {
                return BadRequest();
            }
            if (tailieudto.tailieu.MaNxb != null)
            {
                bool ishasnxb = await _unitOfWork.tailieuRepo.ExistNXB((int)tailieudto.tailieu.MaNxb);
                if (!ishasnxb)
                {
                    return NotFound();
                }
            }
            if (tailieudto.theloais.Count == 0 || tailieudto.theloais == null
                || tailieudto.tacgias.Count == 0 || tailieudto.tacgias == null)
            {
                return BadRequest();
            }
            foreach(int item in tailieudto.tacgias)
            {
                bool ishastacgia = await _unitOfWork.tailieuRepo.ExistTacGia(item);
                if (!ishastacgia)
                {
                    return NotFound();
                }
            }
            foreach (int item in tailieudto.theloais)
            {
                bool ishastheloai = await _unitOfWork.tailieuRepo.ExistTheLoai(item);
                if (!ishastheloai)
                {
                    return NotFound();
                }
            }
            await _unitOfWork.tailieuRepo.Create(tailieudto.tailieu, tailieudto.tacgias, tailieudto.theloais);
            return Created();

        }
    }
}
