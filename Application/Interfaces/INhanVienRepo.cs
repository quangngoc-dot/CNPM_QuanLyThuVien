using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INhanVienRepo
    {
        public Task<List<NhanVien>> GetAll();
        public Task<NhanVien?> GetNhanVien(int id);
        public Task CreateNhanVien(NhanVien nhanVien);
        public Task<bool> ExistDocGia(int id);
        public Task<bool> ExistNhanVien(int id);
    }
}
