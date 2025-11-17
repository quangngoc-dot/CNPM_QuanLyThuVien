using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class XuLyGiaHanRepo : IXuLyGiaHanRepo
    {
        private readonly QuanlythuvienContext _context;
        public XuLyGiaHanRepo(QuanlythuvienContext context)
        {
            _context = context;
        }
        public async Task<bool> ExistXuLyGiaHanID(int id)
        {
            return await _context.XuLyGiaHans.AnyAsync(e => e.MaGiaHan == id);
        }
        public async Task CreateXuLyGiaHan(XuLyGiaHan xulygiahan)
        {
            await _context.XuLyGiaHans.AddAsync(xulygiahan);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateXuLyGiaHan(XuLyGiaHan xulygiahan)
        {
            XuLyGiaHan? ishas = await _context.XuLyGiaHans.FirstOrDefaultAsync(e => e.MaGiaHan == xulygiahan.MaGiaHan);
            if (ishas == null) return false;

            if (xulygiahan.MaPhieuMuon != 0)
                ishas.MaPhieuMuon = xulygiahan.MaPhieuMuon;

            if (xulygiahan.NgayYeuCau.HasValue)
                ishas.NgayYeuCau = xulygiahan.NgayYeuCau;

            if (xulygiahan.NgayGiaHanMoi != default(DateTime))
                ishas.NgayGiaHanMoi = xulygiahan.NgayGiaHanMoi;

            if (xulygiahan.SoLanGiaHan.HasValue)
                ishas.SoLanGiaHan = xulygiahan.SoLanGiaHan;

            if (!string.IsNullOrWhiteSpace(xulygiahan.TrangThaiDuyet))
                ishas.TrangThaiDuyet = xulygiahan.TrangThaiDuyet;

            if (xulygiahan.MaNvduyet.HasValue)
                ishas.MaNvduyet = xulygiahan.MaNvduyet;
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<List<XuLyGiaHan>> GetXuLyGiaHans()
        {
            return await _context.XuLyGiaHans.ToListAsync();
        }

        public async Task<List<XuLyGiaHan>> GetByTrangThai(string trangthai)
        {
            return await _context.XuLyGiaHans.AsNoTracking().Where(e=>e.TrangThaiDuyet==trangthai).ToListAsync();
        }
    }
}
