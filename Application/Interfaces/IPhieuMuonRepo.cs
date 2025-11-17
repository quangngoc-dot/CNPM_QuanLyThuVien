using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPhieuMuonRepo
    {
        public Task<List<PhieuMuon>> PhieuMuons();
        public Task<PhieuMuon?> GetByID(int id);
        public Task Create(PhieuMuon phieumuon);
        public Task CreateCTPM(List<ChiTietPhieuMuon> CTPM);
        public Task<bool> ExistID(int id);
        public Task<bool> ExistXuLyGiaHanIDPhieuMuon(int id);
        public Task<List<PhieuMuon>> GetPhieuMuonTheBanDocID(int id,string trangthai);
        public Task<bool> Update(PhieuMuon phieumuon);
    }
}
