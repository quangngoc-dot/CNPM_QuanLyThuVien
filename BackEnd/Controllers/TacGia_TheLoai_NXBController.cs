using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers_V2
{
    [Route("api")]
    [ApiController]
    public class TacGia_TheLoai_NXBController : ControllerBase
    {
        private readonly ITacGia_TheLoai_NXB _repo;
        public TacGia_TheLoai_NXBController(ITacGia_TheLoai_NXB repo)
        {
            _repo = repo;
        }
        [HttpGet("theloais")]
        [AllowAnonymous]
        public async Task<IActionResult> Theloais() { 
            List<Theloai> theloais= await _repo.GetTheloais();
            if(theloais.Count == 0)
            {
                return NoContent();
            }
            return Ok(new
            {
                data = theloais
            });
        }
        [HttpGet("tacgias")]
        [AllowAnonymous]
        public async Task<IActionResult> Tacgias()
        {
            List<TacGia> tacgias = await _repo.GetTacGias();
            if (tacgias.Count == 0)
            {
                return NoContent();
            }
            return Ok(new
            {
                data = tacgias
            });
        }
        [HttpGet("nxbs")]
        [AllowAnonymous]
        public async Task<IActionResult> NXBs()
        {
            List<NhaXuatBan> nxbs = await _repo.GetNhaXuatBans();
            if (nxbs.Count == 0)
            {
                return NoContent();
            }
            return Ok(new
            {
                data = nxbs
            });
        }
        [HttpGet("nxbs/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByNXBID(int id)
        {
            NhaXuatBan? nxb = await _repo.GetByIDNXB(id);
            if(nxb == null)
            {
                return NoContent();
            }
            return Ok(new
            {
                data = nxb
            });
        }
        [HttpGet("theloais/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTheLoaiID(int id)
        {
            Theloai? theloai = await _repo.GetByIDTheLoai(id);
            if (theloai == null)
            {
                return NoContent();
            }
            return Ok(new
            {
                data = theloai
            });
        }
        [HttpGet("tacgias/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTacGiaID(int id)
        {
            TacGia? tacgia = await _repo.GetByIDTacGia(id);
            if (tacgia == null)
            {
                return NoContent();
            }
            return Ok(new
            {
                data = tacgia
            });
        }
    }
}
