using API.DTOs;
using Application.Interfaces;
using Azure.Core;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class PhieuMuonController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public PhieuMuonController( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet("phieumuons")]
        public async Task<IActionResult> GetAll()
        {
            List<PhieuMuon> phieumuons = await _unitOfWork.phieumuonRepo.PhieuMuons();
            return Ok(phieumuons);
        }
        [HttpGet("phieumuon/{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            PhieuMuon? phieumuon = await _unitOfWork.phieumuonRepo.GetByID(id);
            if (phieumuon == null) {
                return NotFound();
            }
            return Ok(phieumuon);
        }
        [HttpPost("phieumuon")]
        public async Task<IActionResult> Create([FromBody] CreatePhieuMuonDTO CTPMDTO)
        {
            if (CTPMDTO.MaSoThe == 0 || CTPMDTO.MaNV == 0 || CTPMDTO.ChiTietPhieuMuons.Count == 0)
            {
                return BadRequest();
            }

            bool hasthe = await _unitOfWork.thebandocRepo.ExistID(CTPMDTO.MaSoThe);
            bool hasnv = await _unitOfWork.nhanviensRepo.ExistNhanVien(CTPMDTO.MaNV);
            if (!hasthe && !hasnv)
            {
                return NotFound();
            }
            if (CTPMDTO.phieumuon == null)
            {
                return BadRequest();
            }
            CTPMDTO.phieumuon.MaNv = CTPMDTO.MaNV;
            CTPMDTO.phieumuon.MaSoThe = CTPMDTO.MaSoThe;
            await _unitOfWork.phieumuonRepo.Create(CTPMDTO.phieumuon);

            int idphieumuon = CTPMDTO.phieumuon.MaPhieuMuon;

            List<ChiTietPhieuMuon> CTPMs = CTPMDTO.ChiTietPhieuMuons.Select(x => new ChiTietPhieuMuon
            {
                MaPhieuMuon = idphieumuon,
                MaTaiLieu = x.MaTaiLieu,
                SoLuong = x.SoLuong,
                PhiMuonTaiThoiDiem = x.PhiMuonTaiThoiDiem
            }).ToList();
            float tongtien = (float)CTPMs.Sum(e => e.SoLuong * e.PhiMuonTaiThoiDiem);
            CTPMDTO.phieumuon.TongTien = (int)tongtien;
            await _unitOfWork.phieumuonRepo.CreateCTPM(CTPMs);
            return Created();

        }
        [HttpGet("phieumuon/thebandoc/{id}/{trangthai?}")]
        public async Task<IActionResult> GetByTheBanDocID(int id, string? trangthai)
        {
            if (trangthai == null)
            {
                trangthai = string.Empty;
            }
            List<PhieuMuon> phieumuons = await _unitOfWork.phieumuonRepo.GetPhieuMuonTheBanDocID(id, trangthai);
            return Ok(phieumuons);
        }
        [HttpPatch("phieumuon")]
        public async Task<IActionResult> Update([FromBody] PhieuMuon phieumuon)
        {
            if (phieumuon.MaPhieuMuon == 0)
            {
                return BadRequest(new
                {
                    error = "maphieumuon"
                });
            }
            bool ishas = await _unitOfWork.phieumuonRepo.ExistID(phieumuon.MaPhieuMuon);
            if (!ishas)
            {
                return NotFound();
            }
            bool result = await _unitOfWork.phieumuonRepo.Update(phieumuon);
            if (result)
            {
                return NoContent();
            }
            return BadRequest();
        }
    }

}
