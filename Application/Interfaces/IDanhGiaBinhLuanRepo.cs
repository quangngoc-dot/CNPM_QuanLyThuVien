using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDanhGiaBinhLuanRepo
    {
        public Task<List<DanhGiaBinhLuan>> GetAll();
        public Task<DanhGiaBinhLuan?> GetById(int id);
        public Task<List<DanhGiaBinhLuan>> GetByDocGiaId(int id);
        public Task<List<DanhGiaBinhLuan>> GetByTaiLieuID(int id);
        public Task Create(DanhGiaBinhLuan danhGiaBinhLuan);
    }
}
