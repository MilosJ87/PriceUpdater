using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PriceUpdater.Entities;
using PriceUpdater.Models;
using PriceUpdater.Repository;

namespace PriceUpdater.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KovaniceController : ControllerBase
    {
        private readonly IZlatneKovaniceRepo _zlatneKovaniceRepo;
        private readonly IMapper _mapper;

        public KovaniceController(IZlatneKovaniceRepo zlatneKovaniceRepo, IMapper mapper)
        {
            _zlatneKovaniceRepo = zlatneKovaniceRepo ?? throw new ArgumentNullException(nameof(zlatneKovaniceRepo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("GetKovanice")]
        [HttpHead]
        public async Task<ActionResult<IEnumerable<KovaniceDTO>>> GetAllKovanice()
        {
            var kovaniceFromRepo = await _zlatneKovaniceRepo.GetKovanice();

            return Ok(_mapper.Map<IEnumerable<KovaniceDTO>>(kovaniceFromRepo));
        }
        [HttpGet("kovaniceId", Name = "GetKovaniceById")]
        public async Task<ActionResult<KovaniceDTO>> GetKovanice(Guid kovaniceId)
        {
            var kovaniceFromRepo = await _zlatneKovaniceRepo.GetKovaniceAsync(kovaniceId);

            return Ok(kovaniceFromRepo);
        }

        [HttpPost]
        public async Task<ActionResult<KovaniceDTO>> CreateKovanice([FromBody]KovaniceDTO kovaniceDTO)
        {
            var kovaniceEntity =  _mapper.Map<Zlatne_Kovanice>(kovaniceDTO);
            await _zlatneKovaniceRepo.AddKovanice(kovaniceEntity);
            await _zlatneKovaniceRepo.Save();

            var kovaniceToReturn = _mapper.Map<KovaniceDTO>(kovaniceEntity);

            return CreatedAtRoute("GetKovanice", 
                new { kovaniceId = kovaniceToReturn.id},
                kovaniceToReturn);
        }
    }
}
