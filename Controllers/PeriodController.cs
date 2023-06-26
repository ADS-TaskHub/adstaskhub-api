using adstaskhub_api.Models;
using adstaskhub_api.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<List<Period>>> GetAllPeriods()
        {
            List<Period> periods = await _periodRepository.GetAllPeriods();
            return Ok(periods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Period>>> GetPeriodById(long id)
        {
            Period periods = await _periodRepository.GetPeriodById(id);
            return Ok(periods);
        }

        [HttpPost]
        public async Task<ActionResult<Period>> CreatePeriod([FromBody] Period period)
        {
            Period periodResult = await _periodRepository.CreatePeriod(period);

            return Ok(periodResult);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Period>> UpdatePeriod([FromBody] Period period, long id)
        {
            period.Id = id;
            Period periodResult = await _periodRepository.UpdatePeriod(period, id);

            return Ok(periodResult);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Period>> DeletePeriod(long id)
        {
            bool deleted = await _periodRepository.DeletePeriod(id);
            return Ok(deleted);
        }
    }
}
