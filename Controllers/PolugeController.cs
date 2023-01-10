using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PriceUpdater.Entities;
using PriceUpdater.Models;
using PriceUpdater.Repository;

namespace PriceUpdater.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolugeController : ControllerBase
    {
        private readonly IZlatnePoluge _zlatnePoluge;
        private readonly IMapper _mapper;


        public PolugeController(IZlatnePoluge zlatnePoluge, IMapper mapper)
        {
            _zlatnePoluge = zlatnePoluge ?? throw new ArgumentNullException(nameof(zlatnePoluge));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));    
        }

        [HttpGet("GetPoluge")]
        [EnableCors("CorsPolicy")]
        public async Task<ActionResult<IEnumerable<PolugeDTO>>> GetAllPoluge()
        {
            var kovaniceFromRepo = await _zlatnePoluge.GetPolugeAsync();

            return Ok(_mapper.Map<IEnumerable<PolugeDTO>>(kovaniceFromRepo));
        }

        [HttpPost(Name = "PostPoluge")]
        public async Task<ActionResult<PolugeDTO>> CreatePoluge([FromBody] PolugeDTO polugeDTO)
        {
            var polugeEntity = _mapper.Map<Zlatne_poluge>(polugeDTO);
            await _zlatnePoluge.AddPoluge(polugeEntity);
            await _zlatnePoluge.Save();

            var polugeToReturn = _mapper.Map<KovaniceDTO>(polugeEntity);

            return CreatedAtRoute("GetPoluge",
                new { polugeId = polugeToReturn.id },
                polugeToReturn);
        }


    }
}
