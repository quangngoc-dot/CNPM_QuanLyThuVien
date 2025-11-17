using Application.Interfaces;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly QuanlythuvienContext _context;
        public IDocGiaRepo docgiarepo { get; private set; }
        public IDanhGiaBinhLuanRepo danhgiabinhluanRepo { get; private set; }
        public INhanVienRepo nhanviensRepo { get; private set; }
        public IPhieuMuonRepo phieumuonRepo { get; private set; }
        public ITacGia_TheLoai_NXBRepo tacgia_theloai_NXBRepo { get; private set; }
        public ITaiLieuRepo tailieuRepo { get; private set; }
        public ITheBanDocRepo thebandocRepo { get; private set; }
        public IPhieuPhatRepo phieuPhatRepo { get; private set; }
        public IDatMuonTruocRepo datmuontruocRepo { get; private set; }
        public IXuLyGiaHanRepo xuLyGiaHanRepo { get; private set; }
        public UnitOfWork(QuanlythuvienContext context)
        {
            _context = context;
            docgiarepo = new DocGiaRepo(_context);
            danhgiabinhluanRepo = new DanhGiaBinhLuanRepo(_context);
            nhanviensRepo = new NhanVienRepo(_context);
            phieumuonRepo = new PhieuMuonRepo(_context);
            tacgia_theloai_NXBRepo = new TacGia_TheLoai_NXB(_context);
            tailieuRepo = new TaiLieuRepo(_context);
            thebandocRepo = new TheBanDocRepo(_context);
            phieuPhatRepo=new PhieuPhatRepo(_context);
            datmuontruocRepo = new DatMuonTruocRepo(_context);
            xuLyGiaHanRepo=new XuLyGiaHanRepo(_context);
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
