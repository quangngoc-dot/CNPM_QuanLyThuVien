using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DatMuonTruocRepo : IDatMuonTruocRepo
    {
        private QuanlythuvienContext _context;
        public DatMuonTruocRepo(QuanlythuvienContext context)
        {
            _context = context;
        }
        public async Task Create(DatMuonTruoc datmuontruoc)
        {
            await _context.DatMuonTruocs.AddAsync(datmuontruoc);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCTDT(List<ChiTietDatTruoc> CTDTs)
        {
            await _context.ChiTietDatTruocs.AddRangeAsync(CTDTs);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            DatMuonTruoc? datmuontruoc = await _context.DatMuonTruocs.FirstOrDefaultAsync(e => e.MaDatTruoc == id);
            if (datmuontruoc == null) {
                return false;
            }
            _context.DatMuonTruocs.Remove(datmuontruoc);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistID(int id)
        {
            return await _context.DatMuonTruocs.AnyAsync(e => e.MaDatTruoc == id);
        }

        public async Task<List<DatMuonTruoc>> GetAll()
        {
            return await _context.DatMuonTruocs.AsNoTracking()
                .Include(e => e.ChiTietDatTruocs)
                .ToListAsync();
        }

        public async Task<List<DatMuonTruoc>> GetByDocGiaID(int id, string trangthai)
        {
            IQueryable<DatMuonTruoc> query = _context.DatMuonTruocs
                .Include(e => e.ChiTietDatTruocs)
                .AsNoTracking()
                .Where(e => e.MaDocGia == id);
            if (!string.IsNullOrEmpty(trangthai))
            {
                query = query.Where(e => e.TrangThai == trangthai);
            }

            return await query.ToListAsync();
        }

        public async Task<List<DatMuonTruoc>> GetByTrangThai(string trangthai)
        {
            return await _context.DatMuonTruocs.AsNoTracking().Include(e => e.ChiTietDatTruocs).Where(e => e.TrangThai == trangthai).ToListAsync();
        }
    }
}
