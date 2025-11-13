using Microsoft.EntityFrameworkCore;
using BackEnd.Middleware;
using Infrastructure.Context;
using Application.IServices;
using API.Services;
using API.Authentication;
using Application.Interfaces;
using Infrastructure.Repositories;
namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("CORS", options =>
                {
                    options
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });
            builder.Services.AddCustomJwtAuthentication(builder.Configuration);
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
                options.AddPolicy("User", policy => policy.RequireRole("Admin").RequireRole("User"));
            });
            builder.Services.AddSingleton<JwtTokenService>();
            builder.Services.AddDbContext<QuanlythuvienContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("QL_THUVIENV2"));
            });
            builder.Services.AddMemoryCache();
            //v1
            builder.Services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            //
            //v2
            builder.Services.AddScoped<ITaiLieuRepo,TaiLieuRepo>();
            builder.Services.AddScoped<IDocGia,DocGiaRepo>();
            builder.Services.AddScoped<INhanVien,NhanVienRepo>();
            builder.Services.AddScoped<ITacGia_TheLoai_NXB,TacGia_TheLoai_NXB>();
            //   


            builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
            builder.Services.AddControllers();
            builder.Services.AddHttpClient();
            builder.Services.AddAutoMapper(typeof(MappingProfile));
            var app = builder.Build();
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            app.UseCors("CORS");
            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
