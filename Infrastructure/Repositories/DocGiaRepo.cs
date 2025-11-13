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
    public class DocGiaRepo : IDocGia
    {
        QuanlythuvienContext _context;
        public DocGiaRepo(QuanlythuvienContext context)
        {
            _context = context;
        }

        public async Task CreateDocGia(DocGia docGia)
        {
            await _context.Set<DocGia>().AddAsync(docGia); 
            await _context.SaveChangesAsync();
        }

        public async Task<int> ExistDocGia(string email, string matkhau)
        {
            DocGia? a = await _context.Set<DocGia>().FirstOrDefaultAsync(e => e.Email == email && e.MatKhau == matkhau); 
            if (a == null) return -1;
            return a.MaDocGia;
        }

        public async Task<bool> ExistEmail(string email)
        {
            return await _context.Set<DocGia>().AnyAsync(e => e.Email == email); 
        }

        public async Task<DocGia> GetDocGia(int id)
        {
            return await _context.Set<DocGia>().FirstOrDefaultAsync(e => e.MaDocGia == id); 
        }

        public async Task<List<DocGia>> GetDocGias()
        {
            return await _context.Set<DocGia>().AsNoTracking().ToListAsync();
        }
    }
}
