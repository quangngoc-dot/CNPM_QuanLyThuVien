namespace Application.Interfaces
{
    public interface IUnitOfWork
    {
        public IDocGiaRepo docgiarepo { get; }
        public IDanhGiaBinhLuanRepo danhgiabinhluanRepo { get; }
        public INhanVienRepo nhanviensRepo { get; }
        public IPhieuMuonRepo phieumuonRepo { get; }
        public ITacGia_TheLoai_NXBRepo tacgia_theloai_NXBRepo { get; }
        public ITaiLieuRepo tailieuRepo { get; }
        public ITheBanDocRepo thebandocRepo { get; }
        public IPhieuPhatRepo phieuPhatRepo { get; }
        public IDatMuonTruocRepo datmuontruocRepo { get; }
        public IXuLyGiaHanRepo xuLyGiaHanRepo { get; }
        public Task CompleteAsync();
    }
}
