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
    public class TacGia_TheLoai_NXB : ITacGia_TheLoai_NXBRepo
    {
        private readonly QuanlythuvienContext _context;
        public TacGia_TheLoai_NXB(QuanlythuvienContext context) {
            _context = context;
        }

        public async Task CreateNXB(NhaXuatBan nxb)
        {
            await _context.NhaXuatBans.AddAsync(nxb);
            await _context.SaveChangesAsync();
        }

        public async Task CreateTacGia(TacGia tacGia)
        {
            await _context.TacGia.AddAsync(tacGia);
            await _context.SaveChangesAsync();
        }

        public async Task CreateTheLoai(Theloai theloai)
        {
            await _context.Theloais.AddAsync(theloai);
            await _context.SaveChangesAsync();
        }

        public async Task<NhaXuatBan?> GetByIDNXB(int id)
        {
            return await _context.NhaXuatBans
                .AsNoTracking()
                .FirstOrDefaultAsync(e=>e.MaNxb==id);
        }

        public async Task<TacGia?> GetByIDTacGia(int id)
        {
            return await _context.TacGia
                .AsNoTracking()
                .FirstOrDefaultAsync(e=>e.MaTacGia==id);
        }

        public async Task<Theloai?> GetByIDTheLoai(int id)
        {
            return await _context.Theloais
                .AsNoTracking()
                .FirstOrDefaultAsync(e=>e.MaTheLoai==id);
        }

        public async Task<List<NhaXuatBan>> GetNhaXuatBans()
        {
            return await _context.NhaXuatBans.ToListAsync();
        }

        public async Task<List<TacGia>> GetTacGias()
        {
            return await _context.TacGia.ToListAsync();
        }

        public async Task<List<Theloai>> GetTheloais()
        {
            return await _context.Theloais.ToListAsync();
        }
    }
}
