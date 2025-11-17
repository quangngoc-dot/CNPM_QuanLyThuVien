using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class PhieuPhatController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public PhieuPhatController(IUnitOfWork unitOfWork) {
            _unitofwork = unitOfWork;
        }
        [HttpGet("phieuphats")]
        public async Task<IActionResult> GetPhieuPhats()
        {
            List<PhieuPhat> phieuphats = await _unitofwork.phieuPhatRepo.GetPhieuPhats();
            return Ok(phieuphats);
        }
        [HttpGet("phieuphat/{id}")]
        public async Task<IActionResult> GetByPhieuPhatID(int id)
        {
            PhieuPhat? phieuphat = await _unitofwork.phieuPhatRepo.GetPhieuPhatByID(id);
            if (phieuphat == null)
            {
                return NotFound();
            }
            return Ok(phieuphat);
        }
        [HttpPost("phieuphat")]
        public async Task<IActionResult> CreatePhieuPhat(PhieuPhat phieuphat)
        {
            if (phieuphat == null)
            {
                return BadRequest();
            }
            if (phieuphat.MaPhieuMuon == 0 || phieuphat.MaNv == 0)
            {
                return BadRequest();
            }
            bool ishas = await _unitofwork.phieumuonRepo.ExistID(phieuphat.MaPhieuMuon);
            bool ishasnv = await _unitofwork.nhanviensRepo.ExistNhanVien(phieuphat.MaNv);
            if (!ishas || !ishasnv)
            {
                return NotFound();
            }
            await _unitofwork.phieuPhatRepo.CreatePhieuPhat(phieuphat);
            return Created();

        }
        [HttpPatch("phieuphat")]
        public async Task<IActionResult> UpdatePhieuphat(PhieuPhat phieuphat)
        {
            if (phieuphat.MaPhieuPhat == 0 || phieuphat.MaPhieuMuon == 0)
            {
                return BadRequest();
            }
            bool ishasphieuphat = await _unitofwork.phieuPhatRepo.ExistPhieuPhat(phieuphat.MaPhieuPhat);
            bool ishasphieumuon = await _unitofwork.phieumuonRepo.ExistID(phieuphat.MaPhieuMuon);
            if (!ishasphieuphat || !ishasphieumuon)
            {
                return NotFound();
            }
            bool result = await _unitofwork.phieuPhatRepo.UpdatePhieuPhat(phieuphat);
            if (result)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpGet("phieuphat/thebandoc/{id}/{trangthai=-9}")]
        public async Task<IActionResult> GetPhieuPhatByTheBanDoc(int id,int trangthai)
        {
            bool ishasthebandoc = await _unitofwork.thebandocRepo.ExistID(id);
            if (!ishasthebandoc)
            {
                return NotFound();
            }
            List<PhieuPhat> phieuphat = await _unitofwork.phieuPhatRepo.GetPhieuPhatByTheBanDocId(id,trangthai);
            return Ok(phieuphat);
        }

    }
}
