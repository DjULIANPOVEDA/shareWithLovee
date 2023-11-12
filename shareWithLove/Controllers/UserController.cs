using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using shareWithLove.Models;
using shareWithLove.Models.Request;
using shareWithLove.Models.Response;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace shareWithLove.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly shareWithLoveDbContext _context;
        private readonly IMapper _mapper;
        public UserController(shareWithLoveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserResponse>> Login([FromBody] LoginRequest request)
        {
            var user = await _context.Users
                .Where(x => x.UserName.ToLower().Equals(request.UserName.ToLower()))
                .FirstOrDefaultAsync();

            if (user == null) return BadRequest();
            if (!VerifyPassword(request.Password, user.Password)) return BadRequest();
            var userResponse = _mapper.Map<UserResponse>(user);

            userResponse.Token = GenereteToken(user);
            return Ok(userResponse);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<bool>> Register([FromBody] RegisterRequest request)
        {
            var user = _mapper.Map<User>(request);
            user.Id = Guid.NewGuid().ToString();
            user.Password = EncryptPassword(request.Password);

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(true);
        }


        private string GenereteToken(User user)
        {
            var claims = new[]
            {
                new Claim("UsuarioId", user.Id)
            };

            var symetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1e98df0c-6999-40ce-9ab2-e6586e7e2f6a"));
            var signingCredentials = new SigningCredentials(symetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
            claims: claims,
                expires: DateTime.UtcNow.AddMinutes(120),
                signingCredentials: signingCredentials
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }


        private string EncryptPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10);

            string hash = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hash;
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
