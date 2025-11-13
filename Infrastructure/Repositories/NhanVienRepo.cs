using Application.Interfaces;
using Infrastructure.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NhanVienRepo : INhanVien
    {
        QuanlythuvienContext _context;
        public NhanVienRepo(QuanlythuvienContext context)
        {
            _context = context;
        }
        public async Task CreateNhanVien(NhanVien nhanVien)
        {
            await _context.NhanViens.AddAsync(nhanVien);
            await _context.SaveChangesAsync();
            return;

        }

        public async Task<List<NhanVien>> GetAll()
        {
            return await _context.NhanViens
                .AsNoTracking()
                .Include(e => e.MaDocGiaNavigation)
                .Select(e=>new NhanVien
                {
                    MaNv=e.MaNv,
                    MaDocGia=e.MaDocGia,
                    NgayVaoLam=e.NgayVaoLam,
                    MaDocGiaNavigation=e.MaDocGiaNavigation
                })
                .ToListAsync(); 
        }

        public async Task<NhanVien?> GetNhanVien(int id)
        {
            return await _context.NhanViens
                 .AsNoTracking()
                 .Include(e => e.MaDocGiaNavigation)
                 .Select(e => new NhanVien
                 {
                     MaNv = e.MaNv,
                     MaDocGia = e.MaDocGia,
                     NgayVaoLam = e.NgayVaoLam,
                     MaDocGiaNavigation = e.MaDocGiaNavigation
                 })
                 .FirstOrDefaultAsync(e => e.MaNv == id);
        }

        public async Task<bool> ExistDocGia(int id)
        {
            return await _context.DocGia.AnyAsync(e=>e.MaDocGia==id);
        }
    }
}
