using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IXuLyGiaHanRepo
    {
        public Task CreateXuLyGiaHan(XuLyGiaHan xulygiahan);
        public Task<bool> UpdateXuLyGiaHan(XuLyGiaHan xulygiahan);
        public Task<bool> ExistXuLyGiaHanID(int id);
        public Task<List<XuLyGiaHan>> GetXuLyGiaHans();
        public Task<List<XuLyGiaHan>> GetByTrangThai(string trangthai);
    }
}
