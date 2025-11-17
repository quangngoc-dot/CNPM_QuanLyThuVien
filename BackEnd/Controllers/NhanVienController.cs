using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers_V2
{
    [Route("api")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NhanVienController(IUnitOfWork unitofwork) { 
            _unitOfWork = unitofwork;
        }
        [HttpGet("nhanviens")]
        public async Task<IActionResult> GetALL()
        {
            List<NhanVien> lsnv = await _unitOfWork.nhanviensRepo.GetAll();
            return Ok(lsnv);
        }
        [HttpPost("nhanvien")]
        public async Task<IActionResult> CreateNhanVien([FromBody] NhanVien nhanVien)
        {
            if(nhanVien.MaDocGia == 0)
            {
                return BadRequest(new
                {
                    error = "isnulldocgia"
                });
            }
            bool existdocgia = await _unitOfWork.nhanviensRepo.ExistDocGia(nhanVien.MaDocGia);
            if (!existdocgia)
            {
                return NotFound(new
                {
                    error = "nothas"
                });
            }
            await _unitOfWork.nhanviensRepo.CreateNhanVien(nhanVien);
            return NoContent();
        }
        [HttpGet("nhanvien/{id}")]
        public async Task<IActionResult> GetNhanVien(int id)
        {
            NhanVien? a = await _unitOfWork.nhanviensRepo.GetNhanVien(id);
            if (a==null)
            {
                return NotFound();
            }
            return Ok(a);
        }
    }
}
