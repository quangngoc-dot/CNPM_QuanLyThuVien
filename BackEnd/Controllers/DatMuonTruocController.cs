using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;

namespace API.Controllers
{
    [Route("api")]
    [ApiController]
    public class DatMuonTruocController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DatMuonTruocController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }
        [HttpGet("datmuontruocs")]
        public async Task<IActionResult> GetAll()
        {
            List<DatMuonTruoc> datmuontruoc= await _unitOfWork.datmuontruocRepo.GetAll();
            return Ok(datmuontruoc);
        }
        [HttpGet("datmuontruoc/docgia/{id}/{trangthai?}")]
        public async Task<IActionResult> GetByDocGiaID(int id, string? trangthai)
        {
            bool ishasdocgia = await _unitOfWork.docgiarepo.ExistDocGia(id);
            if (!ishasdocgia)
            {
                return NotFound();
            }
            if (string.IsNullOrEmpty(trangthai)) { 
                trangthai= string.Empty;
            }
            List<DatMuonTruoc> datmuontruoc = await _unitOfWork.datmuontruocRepo.GetByDocGiaID(id, trangthai);
            return Ok(datmuontruoc);
        }
        [HttpPost("datmuontruoc")]
        public async Task<IActionResult> Create(CreateDatMuonTruocDTO datmuontruoc)
        {
            DatMuonTruoc _datmuontruoc = datmuontruoc.DatMuonTruoc;
            if (_datmuontruoc.MaDocGia == 0 || _datmuontruoc.MaNvduyet==0 || datmuontruoc.ChiTietDatTruocs.Count==0 )
            {
                return BadRequest();
            }
            bool ishasmadocgia = await _unitOfWork.docgiarepo.ExistDocGia(_datmuontruoc.MaDocGia);
            if (!ishasmadocgia) { 
                return NotFound();
            }
            if (_datmuontruoc.MaNvduyet.HasValue)
            {
                int manvduyetid = (int)_datmuontruoc.MaNvduyet;
                bool ishasmanv = await _unitOfWork.nhanviensRepo.ExistNhanVien(manvduyetid);
                if (!ishasmanv)
                {
                    return NotFound();
                }
            }
            await _unitOfWork.datmuontruocRepo.Create(_datmuontruoc);
            List<ChiTietDatTruoc> _CTDT = datmuontruoc.ChiTietDatTruocs;
            foreach (ChiTietDatTruoc item in _CTDT)
            {
                bool ishastailieu = await _unitOfWork.tailieuRepo.ExistID(item.MaTaiLieu);
                if (!ishastailieu)
                {
                    return NotFound();
                }
                item.MaDatTruoc = _datmuontruoc.MaDatTruoc;
            }
            await _unitOfWork.datmuontruocRepo.CreateCTDT(_CTDT);
            return Created();
        }
        [HttpDelete("datmuontruoc/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool ishas= await _unitOfWork.datmuontruocRepo.ExistID(id);
            if (!ishas)
            {
                return NotFound();
            }
            bool result =await _unitOfWork.datmuontruocRepo.Delete(id);
            if (result)
            {
                return NoContent();
            }
            return BadRequest();
        }
        [HttpGet("datmuontruoc/{trangthai}")]
        public async Task<IActionResult> GetByTrangThai(string trangthai)
        {
            if(trangthai == null)
            {
                return BadRequest();
            }
            List<DatMuonTruoc> datmuontruocs = await _unitOfWork.datmuontruocRepo.GetByTrangThai(trangthai);
            return Ok(datmuontruocs);
        }
    }
}
