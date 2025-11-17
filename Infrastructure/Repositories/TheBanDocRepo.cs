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
    public class TheBanDocRepo:ITheBanDocRepo
    {
        private readonly QuanlythuvienContext _context;
        public TheBanDocRepo(QuanlythuvienContext context) { 
            _context = context;
        }

        public async Task Create(TheBanDoc theBanDoc)
        {
            await _context.TheBanDocs.AddAsync(theBanDoc);
            _context.SaveChanges();
        }

        public async Task<bool> ExistID(int id)
        {
            return await _context.TheBanDocs.AnyAsync(e => e.MaSoThe == id);
        }

        public async Task<TheBanDoc?> GetTheBanDocByDocGiaID(int id)
        {
            return await _context.TheBanDocs.FirstOrDefaultAsync(e=>e.MaDocGia==id);
        }

        public async Task<List<TheBanDoc>> GetTheBanDocs()
        {
            return await _context.TheBanDocs.AsNoTracking().Include(e=>e.MaDocGiaNavigation)
                .Select(e => new TheBanDoc
                {
                    MaSoThe = e.MaSoThe,
                    MaDocGia = e.MaDocGia,
                    TinhTrangThe = e.TinhTrangThe,
                    NgayCap = e.NgayCap,
                    NgayHetHan = e.NgayHetHan,
                    MaDocGiaNavigation = e.MaDocGiaNavigation
                })
                .ToListAsync();
        }
    }
}
