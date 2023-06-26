using adstaskhub_api.Data;
using adstaskhub_api.Models;
using adstaskhub_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Repositories
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly DBContext _dbContext;

        public PeriodRepository(DBContext DBContext)
        {
            _dbContext = DBContext;   
        }

        public async Task<Period> GetPeriodById(long Id)
        {
            return await _dbContext.periods.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Period>> GetAllPeriods()
        {
            return await _dbContext.periods.ToListAsync();
        }

        public async Task<Period> CreatePeriod(Period period)
        {
            await _dbContext.periods.AddAsync(period);
            await _dbContext.SaveChangesAsync();

            return period;
        }

        public async Task<Period> UpdatePeriod(Period period, long id)
        {
            Period periodById = await GetPeriodById(id);

            if(periodById == null)
            {
                throw new Exception($"Period for ID: {id} not found");
            }

            periodById.Id = period.Id;
            periodById.Number = period.Number;

            _dbContext.periods.Update(periodById);
            await _dbContext.SaveChangesAsync();
            return periodById;
        }

        public async Task<bool> DeletePeriod(long id)
        {
            Period periodById = await GetPeriodById(id);

            if (periodById == null)
            {
                throw new Exception($"Period for ID: {id} not found");
            }

            _dbContext.periods.Remove(periodById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
