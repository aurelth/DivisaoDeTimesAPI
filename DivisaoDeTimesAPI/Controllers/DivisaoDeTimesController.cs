using DivisaoDeTimesAPI.Models;
using DivisaoDeTimesAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DivisaoDeTimesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DivisaoDeTimesController : ControllerBase
    {
        private readonly SorteadorDeTimesService _service;

        public DivisaoDeTimesController()
        {
            _service = new SorteadorDeTimesService();
        }

        [HttpPost("dividir")]
        public ActionResult<(Time, Time)> DividirTimes([FromBody] List<Jogador> jogadores)
        {
            try
            {
                var result = _service.DividirTimes(jogadores);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
