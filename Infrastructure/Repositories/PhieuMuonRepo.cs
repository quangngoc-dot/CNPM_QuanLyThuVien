using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PhieuMuonRepo : IPhieuMuonRepo
    {
        private readonly QuanlythuvienContext _context;
        public PhieuMuonRepo(QuanlythuvienContext context)
        {
            _context = context;
        }
        public async Task Create(PhieuMuon phieumuon)
        {
            await _context.PhieuMuons.AddAsync(phieumuon);
            await _context.SaveChangesAsync();
        }

        public async Task CreateCTPM(List<ChiTietPhieuMuon> CTPM)
        {
            foreach (ChiTietPhieuMuon item in CTPM)
            {
                await _context.ChiTietPhieuMuons.AddAsync(item);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<bool> ExistID(int id)
        {
            return await _context.PhieuMuons.AnyAsync(e => e.MaPhieuMuon == id);
        }

        public async Task<bool> ExistXuLyGiaHanIDPhieuMuon(int id)
        {
            return await _context.XuLyGiaHans.AnyAsync(e => e.MaPhieuMuon == id);
        }


        public async Task<PhieuMuon?> GetByID(int id)
        {
            return await _context.PhieuMuons.AsNoTracking()
                .Include(e => e.ChiTietPhieuMuons)
                .Include(e => e.PhieuPhats)
                .FirstOrDefaultAsync(e => e.MaPhieuMuon == id);
        }

        public async Task<List<PhieuMuon>> GetPhieuMuonTheBanDocID(int id, string trangthai)
        {
            IQueryable<PhieuMuon> query = _context.PhieuMuons
                            .Include(e => e.XuLyGiaHans)
                            .Include(e=>e.ChiTietPhieuMuons)
                            .Include(e=>e.PhieuPhats)
                            .AsNoTracking()
                            .Where(e => e.MaSoThe == id);
            if (!string.IsNullOrEmpty(trangthai))
            {
                query = query.Where(e => e.TrangThai == trangthai);
            }
            return await query.ToListAsync();

        }

        public async Task<List<PhieuMuon>> PhieuMuons()
        {
            return await _context.PhieuMuons.AsNoTracking()
                        .Include(e => e.XuLyGiaHans)
                        .Include(e => e.ChiTietPhieuMuons)
                        .Include(e => e.PhieuPhats)
                        .ToListAsync();
        }

        public async Task<bool> Update(PhieuMuon phieumuon)
        {
            PhieuMuon? ishas = await _context.PhieuMuons.FirstOrDefaultAsync(e => e.MaPhieuMuon == phieumuon.MaPhieuMuon);
            if (ishas == null) return false;
            if (phieumuon.MaNv != 0)
            {
                ishas.MaNv = phieumuon.MaNv;
            }
            if (phieumuon.NgayMuon.HasValue)
            {
                ishas.NgayMuon = phieumuon.NgayMuon;
            }
            if (phieumuon.NgayTra != default(DateTime))
            {
                ishas.NgayTra = phieumuon.NgayTra;
            }
            if (phieumuon.NgayThucTra.HasValue)
            {
                ishas.NgayThucTra = phieumuon.NgayThucTra;
            }
            if (phieumuon.TongTien.HasValue)
            {
                ishas.TongTien = phieumuon.TongTien;
            }
            if (!string.IsNullOrWhiteSpace(phieumuon.TrangThai))
            {
                ishas.TrangThai = phieumuon.TrangThai;
            }
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
