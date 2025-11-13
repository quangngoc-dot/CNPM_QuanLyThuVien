namespace API.DTOs
{
    public class LoginDTo
    {
        public string? Email { get; set; }
        public string? MatKhau { get; set; }
    }
    public class RegisterDTO
    {
        public string? Hoten { get; set; }
        public string? Email { get; set; }
        public string? SoDienThoai { get; set; }
        public string? MatKhau { get; set; }
    }
    public class GoogleLoginDTO
    {
        public string IdToken { get; set; } = string.Empty;
    }
}
