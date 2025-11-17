using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers_V2
{
    [Route("api")]
    [ApiController]
    public class TacGia_TheLoai_NXBController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TacGia_TheLoai_NXBController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("theloais")]
        [AllowAnonymous]
        public async Task<IActionResult> Theloais() { 
            List<Theloai> theloais= await _unitOfWork.tacgia_theloai_NXBRepo.GetTheloais();
            return Ok(theloais);
        }
        [HttpGet("tacgias")]
        [AllowAnonymous]
        public async Task<IActionResult> Tacgias()
        {
            List<TacGia> tacgias = await _unitOfWork.tacgia_theloai_NXBRepo.GetTacGias();
            return Ok(tacgias);
        }
        [HttpGet("nxbs")]
        [AllowAnonymous]
        public async Task<IActionResult> NXBs()
        {
            List<NhaXuatBan> nxbs = await _unitOfWork.tacgia_theloai_NXBRepo.GetNhaXuatBans();
            return Ok(nxbs);
        }
        [HttpGet("nxb/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByNXBID(int id)
        {
            NhaXuatBan? nxb = await _unitOfWork.tacgia_theloai_NXBRepo.GetByIDNXB(id);
            return Ok(nxb);
        }
        [HttpGet("theloai/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTheLoaiID(int id)
        {
            Theloai? theloai = await _unitOfWork.tacgia_theloai_NXBRepo.GetByIDTheLoai(id);
            return Ok(theloai);
        }
        [HttpGet("tacgia/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTacGiaID(int id)
        {
            TacGia? tacgia = await _unitOfWork.tacgia_theloai_NXBRepo.GetByIDTacGia(id);
            return Ok(tacgia);
        }
        [HttpPost("tacgia")]
        public async Task<IActionResult> CreateTacGia([FromBody] TacGia tacgia)
        {
            if (tacgia == null)
            {
                return BadRequest();
            }
            await _unitOfWork.tacgia_theloai_NXBRepo.CreateTacGia(tacgia);
            return Created();
        }
        [HttpPost("nxb")]
        public async Task<IActionResult> CreateNXB([FromBody] NhaXuatBan nxb)
        {
            if (nxb == null)
            {
                return BadRequest();
            }
            if (!string.IsNullOrEmpty(nxb.TenNxb))
            {
                return BadRequest();
            }
            await _unitOfWork.tacgia_theloai_NXBRepo.CreateNXB(nxb);
            return Created();
        }
        [HttpPost("theloai")]
        public async Task<IActionResult> CreateTheLoai([FromBody] Theloai theloai)
        {
            if(theloai == null)
            {
                return BadRequest();
            }
            await _unitOfWork.tacgia_theloai_NXBRepo.CreateTheLoai(theloai);
            return Created();
        }
    }
}
