using API.DTOs;
using Application.Interfaces;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers_V2
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtTokenService _generateJwtToken;
        private readonly IMapper _mapper;
        private readonly IDocGiaRepo _docgiarepo;
        private readonly IGoogleAuthService _authService;
        public AuthController(JwtTokenService generateJwtToken,IMapper mapper,IDocGiaRepo docgia, IGoogleAuthService googleAuthService) { 
            _mapper = mapper;
            _docgiarepo = docgia;
            _generateJwtToken = generateJwtToken;
            _authService = googleAuthService;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTo userlogin)
        {
            string vaitro = "";
            DocGia user=_mapper.Map<DocGia>(userlogin);
            if (userlogin.MatKhau == null || string.IsNullOrEmpty(userlogin.MatKhau) ||
                user.Email == null || string.IsNullOrEmpty(userlogin.Email)) {
                return NotFound();
            }

            DocGia? isValidUser = await _docgiarepo.ExistDocGia(user.Email, user.MatKhau);
            if (isValidUser != null)
            {
                if (vaitro == "Thủ thư" || vaitro== "Quản lý")
                {
                    var token = _generateJwtToken.Generate(isValidUser.MaDocGia, user.Email!, "Admin");
                    return Ok(new
                    {
                        Token = token,
                        user = isValidUser
                    });
                }
                else
                {
                    var token = _generateJwtToken.Generate(isValidUser.MaDocGia, user.Email!, "User");
                    return Ok(new
                    {
                        Token = token,
                        user = isValidUser
                    });
                }
            }
            return NotFound();
        }
        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO userRegister)
        {
            DocGia user = _mapper.Map<DocGia>(userRegister);
            bool emailExists = await _docgiarepo.ExistEmail(user.Email!);
            if (emailExists)
            {
                return Conflict();
            }
            await _docgiarepo.CreateDocGia(user);
            return Created();
        }


        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginDTO model)
        {
            if (string.IsNullOrEmpty(model.IdToken))
            {
                return BadRequest(new { Message = "ID Token is required." });
            }

            try
            {
                var result = await _authService.HandleGoogleLoginAsync(model.IdToken);

                if (result.IsSuccess)
                {
                    return Ok(new
                    {
                        Token = result.CustomJwtToken
                    });
                }
                else
                {
                    return Unauthorized(new { Message = result.ErrorMessage });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred." });
            }
        }
    }
}
