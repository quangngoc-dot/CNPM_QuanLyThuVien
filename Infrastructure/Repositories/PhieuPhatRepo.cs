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
    public class PhieuPhatRepo:IPhieuPhatRepo
    {
        private readonly QuanlythuvienContext _context;
        public PhieuPhatRepo(QuanlythuvienContext context)
        {
            _context = context;
        }
        public async Task<List<PhieuPhat>> GetPhieuPhats()
        {
            return await _context.PhieuPhats.ToListAsync();
        }

        public async Task<PhieuPhat?> GetPhieuPhatByID(int id)
        {
            return await _context.PhieuPhats.FirstOrDefaultAsync(e => e.MaPhieuPhat == id);
        }

        public async Task CreatePhieuPhat(PhieuPhat phieuphat)
        {
            await _context.PhieuPhats.AddAsync(phieuphat);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePhieuPhat(PhieuPhat phieuphat)
        {
            PhieuPhat? ishas = await _context.PhieuPhats.FirstOrDefaultAsync(e => e.MaPhieuPhat == phieuphat.MaPhieuPhat);
            if (ishas == null)
            {
                return false;
            }
            if (!string.IsNullOrEmpty(phieuphat.LyDoPhat))
            {
                ishas.LyDoPhat = phieuphat.LyDoPhat;
            }
            if (phieuphat.MaNv != 0)
            {
                ishas.MaNv = phieuphat.MaNv;
            }
            if (phieuphat.PhiPhat.HasValue)
            {
                ishas.PhiPhat = phieuphat.PhiPhat;
            }
            if (phieuphat.NgayLap.HasValue)
            {
                ishas.NgayLap = phieuphat.NgayLap;
            }
            if (phieuphat.TrangThaiThanhToan.HasValue)
            {
                ishas.TrangThaiThanhToan = phieuphat.TrangThaiThanhToan;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<PhieuPhat>> GetPhieuPhatByTheBanDocId(int id, int trangthai)
        {
            IQueryable<PhieuPhat> query = _context.PhieuPhats
                .Include(p => p.MaPhieuMuonNavigation)
                .AsNoTracking()
                .Where(p => p.MaPhieuMuonNavigation.MaSoThe == id);
            if (trangthai != -9)
            {
                bool trangthaithanhtoan = false;
                if (trangthai == 1)
                {
                    trangthaithanhtoan = true;
                }
                query = query.Where(e => e.TrangThaiThanhToan == trangthaithanhtoan);
            }
            return await query.ToListAsync();
        }

        public async Task<bool> ExistPhieuPhat(int id)
        {
            return await _context.PhieuPhats.AnyAsync(e => e.MaPhieuPhat == id);
        }

    }
}
