using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers_V2
{
    [Route("api")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        private readonly INhanVien _nhanvienrepo;
        public NhanVienController(INhanVien repo) { 
            _nhanvienrepo = repo;
        }
        [HttpGet("nhanviens")]
        public async Task<IActionResult> GetALL()
        {
            List<NhanVien> lsnv = await _nhanvienrepo.GetAll();
            if (lsnv.Count == 0) { return NoContent(); }
            return Ok(lsnv);
        }
        [HttpPost("nhanviens")]
        public async Task<IActionResult> CreateNhanVien([FromBody] NhanVien nhanVien)
        {
            if(nhanVien.MaDocGia == 0)
            {
                return BadRequest(new
                {
                    error = "isnulldocgia"
                });
            }
            bool existdocgia = await _nhanvienrepo.ExistDocGia(nhanVien.MaDocGia);
            if (!existdocgia)
            {
                return NotFound(new
                {
                    error = "nothas"
                });
            }
            await _nhanvienrepo.CreateNhanVien(nhanVien);
            return NoContent();
        }
        [HttpGet("nhanviens/{id}")]
        public async Task<IActionResult> GetNhanVien(int id)
        {
            NhanVien? a = await _nhanvienrepo.GetNhanVien(id);
            if(a == null)
            {
                return NoContent();
            }
            return Ok(new
            {
                data = a
            });
        }
    }
}
