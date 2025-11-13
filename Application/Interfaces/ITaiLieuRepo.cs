using Domain.Entities;
namespace Application.Interfaces
{
    public interface ITaiLieuRepo
    {
        public Task<List<TaiLieu>> GetTaiLieus();
        public Task<List<TaiLieu>> GetByTacGia(int id);
        public Task<List<TaiLieu>> GetByTheLoai(int id);
        public Task<List<TaiLieu>> GetByNXB(int id);
    }
}
