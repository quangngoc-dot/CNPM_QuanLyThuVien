using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class TheBanDocController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TheBanDocController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("thebandocs")]
        public async Task<IActionResult> Getall()
        {
            List<TheBanDoc> theBanDocs = await _unitOfWork.thebandocRepo.GetTheBanDocs();
            return Ok(theBanDocs);
        }
        [HttpGet("thebandoc/docgia/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            TheBanDoc? thebandoc = await _unitOfWork.thebandocRepo.GetTheBanDocByDocGiaID(id);
            if (thebandoc==null)
            {
                return NotFound();
            }
            return Ok(thebandoc);
        }
        [HttpPost("thebandoc")]
        public async Task<IActionResult> CreateThe([FromBody] TheBanDoc theBanDoc)
        {
            bool docgia=await _unitOfWork.docgiarepo.ExistDocGia(theBanDoc.MaDocGia);
            if (!docgia)
            {
                return BadRequest();
            }
            if (theBanDoc == null)
            {
                return NotFound();
            }
            if (theBanDoc.TinhTrangThe != null)
            {
                if (theBanDoc.TinhTrangThe != "Hoạt động" || theBanDoc.TinhTrangThe != "Hết hạn"
                    || theBanDoc.TinhTrangThe != "Bị khóa")
                {
                    return BadRequest();
                }
            }
            if (theBanDoc.NgayCap != null)
            {
                if(theBanDoc.NgayCap >= theBanDoc.NgayHetHan)
                {
                    return BadRequest();
                }
            }
            if (theBanDoc.NgayHetHan >= DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest();
            }
            await _unitOfWork.thebandocRepo.Create(theBanDoc);
            return Created();
        }

    }
}
