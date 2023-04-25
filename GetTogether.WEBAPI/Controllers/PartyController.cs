using GetTogether.BLL.Interfaces;
using GetTogether.Common.DTO.Party;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetTogether.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        private readonly IPartyService _service;
        public PartyController(IPartyService partyService) 
        {
            _service = partyService;
        }

        [HttpGet("active")]
        public async Task<ActionResult<ICollection<PartyDTO>>> GetActiveParties() => Ok(await _service.GetActiveParties());

        [HttpGet("{id}")]
        public async Task<ActionResult<PartyDTO>> GetById(long id) => Ok(await _service.GetById(id));
    }
}
