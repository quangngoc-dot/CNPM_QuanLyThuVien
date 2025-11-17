using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITheBanDocRepo
    {
        public Task<List<TheBanDoc>> GetTheBanDocs();
        public Task<TheBanDoc?> GetTheBanDocByDocGiaID(int id);
        public Task Create(TheBanDoc theBanDoc);
        public Task<bool> ExistID(int id);
    }
}
