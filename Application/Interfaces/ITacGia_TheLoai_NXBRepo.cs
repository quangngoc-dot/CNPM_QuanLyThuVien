using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITacGia_TheLoai_NXBRepo
    {
        public Task<List<TacGia>> GetTacGias();
        public Task<TacGia?> GetByIDTacGia(int id);

        public Task<List<Theloai>> GetTheloais();
        public Task<Theloai?> GetByIDTheLoai(int id);

        public Task<List<NhaXuatBan>> GetNhaXuatBans();
        public Task<NhaXuatBan?> GetByIDNXB(int id);
        public Task CreateNXB(NhaXuatBan nxb);
        public Task CreateTheLoai(Theloai theloai);
        public Task CreateTacGia(TacGia tacGia);


    }
}
