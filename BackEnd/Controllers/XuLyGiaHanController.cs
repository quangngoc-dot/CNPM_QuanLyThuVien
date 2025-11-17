using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class XuLyGiaHanController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public XuLyGiaHanController(IUnitOfWork unitofwork) { 
            _unitOfWork = unitofwork;
        }
        [HttpPost("xulygiahan")]
        public async Task<IActionResult> CreatXuLyGiaHan([FromBody] XuLyGiaHan xulygiahan)
        {
            if (xulygiahan == null || xulygiahan.MaPhieuMuon == 0 || xulygiahan.MaNvduyet == 0 || xulygiahan.NgayGiaHanMoi == default(DateTime))
            {
                return BadRequest();
            }
            if (!await _unitOfWork.phieumuonRepo.ExistID(xulygiahan.MaPhieuMuon))
            {
                return NotFound(new
                {
                    error = "maphieumuon"
                });
            }
            if (await _unitOfWork.phieumuonRepo.ExistXuLyGiaHanIDPhieuMuon(xulygiahan.MaPhieuMuon))
            {
                return Conflict(new
                {
                    error = "maphieumuon"
                });
            }
            int manv = (int)xulygiahan.MaNvduyet!;
            if (!await _unitOfWork.nhanviensRepo.ExistNhanVien(manv))
            {
                return NotFound(new
                {
                    error = "manvduyet"
                });
            }
            await _unitOfWork.xuLyGiaHanRepo.CreateXuLyGiaHan(xulygiahan);
            return Created();
        }
        [HttpPatch("xulygiahan")]
        public async Task<IActionResult> UpdateXuLyGiaHan([FromBody] XuLyGiaHan xulygiahan)
        {
            if (xulygiahan == null)
            {
                return BadRequest();
            }
            bool ishas = await _unitOfWork.phieumuonRepo.ExistID(xulygiahan.MaPhieuMuon);
            bool ishasxulygiahan = await _unitOfWork.xuLyGiaHanRepo.ExistXuLyGiaHanID(xulygiahan.MaGiaHan);
            if (!ishas)
            {
                return NotFound(new
                {
                    error = "maphieumuon"
                });
            }
            if (!ishasxulygiahan)
            {
                return NotFound(new
                {
                    error = "magiahan"
                });
            }
            bool result = await _unitOfWork.xuLyGiaHanRepo.UpdateXuLyGiaHan(xulygiahan);
            if (result)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpGet("xulygiahans")]
        public async Task<IActionResult> GetAllXuLyGiaHan()
        {
            List<XuLyGiaHan> xulygiahans = await _unitOfWork.xuLyGiaHanRepo.GetXuLyGiaHans();
            return Ok(xulygiahans);
        }
        [HttpGet("xulygiahan/{trangthai}")]
        public async Task<IActionResult> GetByTrangThai(string trangThai)
        {
            if(trangThai == null)
            {
                return BadRequest();
            }
            List<XuLyGiaHan> xulygiahans = await _unitOfWork.xuLyGiaHanRepo.GetByTrangThai(trangThai);
            return Ok(xulygiahans);
        }

    }
}
