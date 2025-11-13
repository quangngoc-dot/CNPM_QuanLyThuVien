using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Formats.Asn1;
namespace Infrastructure.Repositories
{
    public class TaiLieuRepo : ITaiLieuRepo
    {
        private readonly QuanlythuvienContext _context;
        public TaiLieuRepo(QuanlythuvienContext context) { 
            _context = context;
        }

        public async Task<List<TaiLieu>> GetByNXB(int id)
        {
            var nxb = await _context.NhaXuatBans
                .AsNoTracking()
                .Include(e => e.TaiLieus)
                .Select(e=>new NhaXuatBan
                {
                    MaNxb = e.MaNxb,
                    TenNxb = e.TenNxb,
                    DiaChi = e.DiaChi,
                    SoDienThoai = e.SoDienThoai,
                    TaiLieus =e.TaiLieus.Select(y=>new TaiLieu
                    {
                        MaTaiLieu = y.MaTaiLieu,
                        TenSach = y.TenSach,
                        TomTat = y.TomTat,
                        NgonNgu = y.NgonNgu,
                        GiaBan = y.GiaBan,
                        PhiMuon = y.PhiMuon,
                        NamXuatBan = y.NamXuatBan,
                        MaNxb = y.MaNxb,
                        SoLuong = y.SoLuong,
                    }).ToList()
                })
                .Where(e => e.MaNxb == id)
                .ToListAsync();
            return nxb.SelectMany(e => e.TaiLieus).ToList();
        }

        public async Task<List<TaiLieu>> GetByTacGia(int id)
        {
            var tacgias = await _context.TacGia.AsNoTracking()
                .Include(e => e.MaTaiLieus)
                .Select(e=>new TacGia
                {
                    TenTacGia=e.TenTacGia,
                    MaTacGia = e.MaTacGia,
                    MaTaiLieus = e.MaTaiLieus.Select(y => new TaiLieu
                    {
                        MaTaiLieu = y.MaTaiLieu,
                        TenSach = y.TenSach,
                        TomTat = y.TomTat,
                        NgonNgu = y.NgonNgu,
                        GiaBan = y.GiaBan,
                        PhiMuon = y.PhiMuon,
                        NamXuatBan = y.NamXuatBan,
                        MaNxb = y.MaNxb,
                        SoLuong = y.SoLuong,
                    }).ToList()
                })
                .Where(e => e.MaTacGia == id)
                .ToListAsync();
            return tacgias.SelectMany(e => e.MaTaiLieus).ToList();
        }

        public async Task<List<TaiLieu>> GetByTheLoai(int id)
        {
            var tailieus = await _context.Theloais.AsNoTracking()
                .Include(e => e.MaTaiLieus)
                .Select(e=>new Theloai
                {
                    TenTheLoai=e.TenTheLoai,
                    MaTheLoai=e.MaTheLoai,
                    MaTaiLieus=e.MaTaiLieus.Select(y=>new TaiLieu
                    {
                        MaTaiLieu=y.MaTaiLieu,
                        TenSach=y.TenSach,
                        TomTat=y.TomTat,
                        NgonNgu=y.NgonNgu,
                        GiaBan=y.GiaBan,
                        PhiMuon=y.PhiMuon,
                        NamXuatBan=y.NamXuatBan,
                        MaNxb=y.MaNxb,
                        SoLuong=y.SoLuong,
                    }).ToList()
                })
                .Where(e => e.MaTheLoai == id)
                .ToListAsync();
            return tailieus.SelectMany(e => e.MaTaiLieus).ToList();
        }

        public async Task<List<TaiLieu>> GetTaiLieus()
        {
            return await _context.TaiLieus.AsNoTracking().ToListAsync();
        }
    }
}
