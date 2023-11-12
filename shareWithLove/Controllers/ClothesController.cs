using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shareWithLove.Models;
using shareWithLove.Models.Request;
using shareWithLove.Models.Response;

namespace shareWithLove.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothesController : ControllerBase
    {
        private readonly shareWithLoveDbContext _context;
        private readonly IMapper _mapper;
        public ClothesController(shareWithLoveDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<List<DonationResponse>>> GetAllClothsFiltered()
        {
            var clothes = await _context.Clothes.Where(l => l.DonateId!=null).ToListAsync();
            var clothResult = _mapper.Map<List<DonationResponse>>(clothes);
            return Ok(clothResult);
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<ActionResult<List<DonationWithUserResponse>>> GetAllCloths()
        {
            var clothes = await _context.Clothes.Include(l => l.Owner).Include(l=>l.Donate).ToListAsync();

            var clothResult = _mapper.Map<List<DonationWithUserResponse>>(clothes);
            return Ok(clothResult);
        }

        [HttpGet("User")]
        [Authorize]
        public async Task<ActionResult<List<DonationResponse>>> GetAllClothsByUser()
        {
            var userId = User.FindFirst("UsuarioId")?.Value;
            var clothes = await _context.Clothes.Where(l => l.OwnerId.Equals(userId)).ToListAsync();
            var clothResult = _mapper.Map<List<DonationResponse>>(clothes);
            return Ok(clothResult);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> InsertCloth([FromBody] DonationRequest request)
        {
            var userId = User.FindFirst("UsuarioId")?.Value;
            var cloth = _mapper.Map<Clothe>(request);
            cloth.Id = Guid.NewGuid().ToString();
            cloth.OwnerId = userId;
            await _context.Clothes.AddAsync(cloth);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpPut("{clothId}")]
        [Authorize]
        public async Task<ActionResult<bool>> UpdateCloth([FromBody] DonationRequest request, string clothId)
        {
            var cloth = await _context.Clothes.Where(l => l.Id.Equals(clothId)).FirstOrDefaultAsync();
            cloth.Name = request.Name;
            cloth.Size = request.Size;

            _context.Entry(cloth).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(true);
        }

        [HttpDelete("Delete/{clothId}")]
        [Authorize]
        public async Task<ActionResult<bool>> DeleteCloth(string clothId)
        {
            var EliminarCloth = await _context.Clothes.FindAsync(clothId);
            _context.Clothes.Remove(EliminarCloth);
            await _context.SaveChangesAsync();
            return Ok(true);
        }
        
        [HttpPost("Receive/{clothId}")]
        [Authorize]
        public async Task<ActionResult<bool>> ReceiveCloth(string clothId)
        {
            var userId = User.FindFirst("UsuarioId")?.Value;
            var cloth = await _context.Clothes.Where(l => l.Id.Equals(clothId)).FirstOrDefaultAsync();
            if (cloth.DonateId==null) return Ok(false);
            cloth.DonateId = userId;
            _context.Entry(cloth).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
