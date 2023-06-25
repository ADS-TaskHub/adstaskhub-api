using adstaskhub_api.Data;
using adstaskhub_api.Models;
using adstaskhub_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace adstaskhub_api.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DBContext _dbContext;

        public ClassRepository(DBContext DBContext)
        {
            _dbContext = DBContext;   
        }

        public async Task<Class> GetClassById(long Id)
        {
            return await _dbContext.classes.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<Class>> GetAllClasses()
        {
            return await _dbContext.classes.ToListAsync();
        }

        public async Task<Class> CreateClass(Class @class)
        {
            await _dbContext.classes.AddAsync(@class);
            await _dbContext.SaveChangesAsync();

            return @class;
        }

        public async Task<Class> UpdateClass(Class @class, long id)
        {
            Class classById = await GetClassById(id);

            if(classById == null)
            {
                throw new Exception($"Class for ID: {id} not found");
            }

            classById.Id = @class.Id;
            classById.ClassNumber = @class.ClassNumber;
            classById.PeriodId = @class.PeriodId;

            _dbContext.classes.Update(classById);
            await _dbContext.SaveChangesAsync();
            return @classById;
        }

        public async Task<bool> DeleteClass(Class @class, long id)
        {
            Class classById = await GetClassById(id);

            if (classById == null)
            {
                throw new Exception($"Class for ID: {id} not found");
            }

            _dbContext.classes.Remove(classById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
