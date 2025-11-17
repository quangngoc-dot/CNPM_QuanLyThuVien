using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPhieuPhatRepo
    {
        public Task<bool> ExistPhieuPhat(int id);
        public Task<List<PhieuPhat>> GetPhieuPhats();
        public Task<PhieuPhat?> GetPhieuPhatByID(int id);
        public Task CreatePhieuPhat(PhieuPhat phieuphat);
        public Task<bool> UpdatePhieuPhat(PhieuPhat phieuphat);
        public Task<List<PhieuPhat>> GetPhieuPhatByTheBanDocId(int id,int trangthai);
    }
}
