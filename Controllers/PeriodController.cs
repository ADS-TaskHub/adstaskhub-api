using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace adstaskhub_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodController : ControllerBase
    {
        private readonly IPeriodRepository _periodRepository;

        public PeriodController(IPeriodRepository periodRepository)
        {
            _periodRepository = periodRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PeriodDTO>>> GetAllPeriodsDTO()
        {
            List<PeriodDTO> periods = await _periodRepository.GetAllPeriodsDTO();
            return Ok(periods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<PeriodDTO>>> GetPeriodDTOById(long id)
        {
            PeriodDTO periods = await _periodRepository.GetPeriodDTOById(id);
            return Ok(periods);
        }

        [HttpPost]
        public async Task<ActionResult<PeriodDTO>> CreatePeriod([FromBody] Period period)
        {
            PeriodDTO periodResult = await _periodRepository.CreatePeriod(period);

            return Ok(periodResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PeriodDTO>> UpdatePeriod([FromBody] Period period, long id)
        {
            period.Id = id;
            PeriodDTO periodResult = await _periodRepository.UpdatePeriod(period, id);

            return Ok(periodResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePeriod(long id)
        {
            bool deleted = await _periodRepository.DeletePeriod(id);
            return Ok(deleted);
        }
    }
}
