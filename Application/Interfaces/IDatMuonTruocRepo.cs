using Domain.Entities;
namespace Application.Interfaces
{
    public interface IDatMuonTruocRepo
    {
        public Task<List<DatMuonTruoc>> GetAll();
        public Task<List<DatMuonTruoc>> GetByTrangThai(string trangthai);
        public Task<List<DatMuonTruoc>> GetByDocGiaID(int id,string trangthai);
        public Task Create(DatMuonTruoc datmuontruoc);
        public Task CreateCTDT(List<ChiTietDatTruoc> CTDTs);
        public Task<bool> Delete(int id);
        public Task<bool> ExistID(int id);
    }
}
