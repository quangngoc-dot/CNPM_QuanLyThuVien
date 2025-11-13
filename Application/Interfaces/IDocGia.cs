using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDocGia
    {
        public Task<List<DocGia>> GetDocGias();
        public Task<DocGia> GetDocGia(int id);
        public Task CreateDocGia(DocGia docGia);
        public Task<bool> ExistEmail(string email);
        public Task<int> ExistDocGia(string email, string matkhau);
    }
}
