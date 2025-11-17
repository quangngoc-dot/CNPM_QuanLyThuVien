using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class DanhGiaBinhLuanRepo : IDanhGiaBinhLuanRepo
    {
        private QuanlythuvienContext _context;
        public DanhGiaBinhLuanRepo(QuanlythuvienContext context)
        {
            _context = context;
        }

        public async Task Create(DanhGiaBinhLuan danhGiaBinhLuan)
        {
            await _context.DanhGiaBinhLuans.AddAsync(danhGiaBinhLuan);
            _context.SaveChanges();
        }

        public async Task<List<DanhGiaBinhLuan>> GetAll()
        {
            return await _context.DanhGiaBinhLuans.ToListAsync();
        }

        public async Task<List<DanhGiaBinhLuan>> GetByDocGiaId(int id)
        {
            return await _context.DanhGiaBinhLuans.Where(e=>e.MaDocGia==id).ToListAsync();
        }

        public async Task<DanhGiaBinhLuan?> GetById(int id)
        {
            return await _context.DanhGiaBinhLuans.FirstOrDefaultAsync(e => e.MaDanhGia == id);
        }

        public async Task<List<DanhGiaBinhLuan>> GetByTaiLieuID(int id)
        {
            return await _context.DanhGiaBinhLuans.Where(e => e.MaTaiLieu == id).ToListAsync();
        }
    }
}
