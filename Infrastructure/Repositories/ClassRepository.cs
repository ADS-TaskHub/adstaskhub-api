using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace adstaskhub_api.Infrastructure.Repositories
{
    public class ClassRepository : IClassRepository
    {
        private readonly DBContext _dbContext;
        private readonly IClassMapper _classMapper;

        public ClassRepository(DBContext DBContext, IClassMapper classMapper)
        {
            _dbContext = DBContext;
            _classMapper = classMapper;
        }

        public async Task<Class> GetClassById(long id)
        {
            return await _dbContext.classes
                .Include(x => x.Period)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ClassDTO> GetClassDTOById(long id)
        {
            Class @class = await _dbContext.classes
                .Include(x => x.Period)
                .FirstOrDefaultAsync(x => x.Id == id);

            return _classMapper.MapToDTO(@class);
        }

        public async Task<List<ClassDTO>> GetAllClassesDTO()
        {
            List<Class> classes = await _dbContext.classes
                .Include(x => x.Period)
            .ToListAsync();

            return classes.Select(@class => _classMapper.MapToDTO(@class)).ToList();
        }

        public async Task<ClassDTO> CreateClass(Class @class)
        {
            await _dbContext.classes.AddAsync(@class);
            await _dbContext.SaveChangesAsync();

            return _classMapper.MapToDTO(@class);
        }

        public async Task<ClassDTO> UpdateClass(Class @class, long id)
        {
            Class classById = await GetClassById(id) ?? throw new Exception($"Class for ID: {id} not found");
            classById.Id = @class.Id;
            classById.ClassNumber = @class.ClassNumber;
            classById.PeriodId = @class.PeriodId;

            _dbContext.classes.Update(classById);
            await _dbContext.SaveChangesAsync();

            return _classMapper.MapToDTO(classById);
        }

        public async Task<bool> DeleteClass(long id)
        {
            Class classById = await GetClassById(id) ?? throw new Exception($"Class for ID: {id} not found");
            _dbContext.classes.Remove(classById);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
