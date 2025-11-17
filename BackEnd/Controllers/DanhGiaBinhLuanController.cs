using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class DanhGiaBinhLuanController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public  DanhGiaBinhLuanController(IUnitOfWork unitofwork) { 
            _unitOfWork = unitofwork;
        }
        [HttpGet("danhgiabinhluans")]
        public async Task<IActionResult> GetALL() { 
            List<DanhGiaBinhLuan> dgbl =await _unitOfWork.danhgiabinhluanRepo.GetAll();
            return Ok(dgbl);
        }
        [HttpGet("danhgiabinhluan/docgia/{id}")]
        public async Task<IActionResult> GetByDocGiaID(int id)
        {
            bool ishas = await _unitOfWork.docgiarepo.ExistDocGia(id);
            if (!ishas)
            {
                return NotFound();
            }
            List<DanhGiaBinhLuan> dgbl = await _unitOfWork.danhgiabinhluanRepo.GetByDocGiaId(id);
            return Ok(dgbl);
        }
        [HttpGet("danhgiabinhluan/tailieu/{id}")]
        public async Task<IActionResult> GetByTaiLieuID(int id)
        {
            bool ishas = await _unitOfWork.tailieuRepo.ExistID(id);
            if (!ishas)
            {
                return NotFound();
            }
            List<DanhGiaBinhLuan> dgbl = await _unitOfWork.danhgiabinhluanRepo.GetByTaiLieuID(id);
            return Ok(dgbl);
        }
        [HttpGet("danhgiabinhluan/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            DanhGiaBinhLuan? dgbl=await _unitOfWork.danhgiabinhluanRepo.GetById(id);
            if (dgbl == null)
            {
                return NotFound();
            }
            return Ok(dgbl);
        }
        [HttpPost("danhgiabinhluan")]
        public async Task<IActionResult> Create([FromBody] DanhGiaBinhLuan dgbl)
        {
            if(dgbl.MaDocGia==0 || dgbl.MaTaiLieu == 0 ||
                dgbl.DiemDanhGia > 5 || dgbl.DiemDanhGia <= 0
                || string.IsNullOrEmpty(dgbl.BinhLuan))
            {
                return BadRequest();
            }
            bool ishasdocgia = await _unitOfWork.docgiarepo.ExistDocGia(dgbl.MaDocGia);
            bool ishastailieu = await _unitOfWork.tailieuRepo.ExistID(dgbl.MaTaiLieu);
            if (!ishasdocgia || !ishastailieu)
            {
                return NotFound();
            }
            await _unitOfWork.danhgiabinhluanRepo.Create(dgbl);
            return Created();
        }
    }
}
