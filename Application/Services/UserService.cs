using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Application.Services.Interfaces;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;

namespace adstaskhub_api.Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IUserMapper _userMapper;
        private readonly IClassRepository _classRepository;

        public UserService(IUserRepository userRepository, IPasswordService passwordService, IUserMapper userMapper, IClassRepository classRepository)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _userMapper = userMapper;
            _classRepository = classRepository;
        }

        public async Task<UserDTOBase> CreateUser(UserCreateDTO userCreate, string createdBy)
        {
            if (userCreate == null)
            {
                throw new ArgumentNullException(nameof(userCreate), "Os dados de criação do usuário não podem ser nulos.");
            }

            if (string.IsNullOrEmpty(createdBy))
            {
                throw new ArgumentException("O criador do usuário não pode ser nulo ou vazio.", nameof(createdBy));
            }

            User existingUser = await _userRepository.GetUserByEmailAsync(userCreate.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Já existe um usuário com este email.");
            }

            User user = _userMapper.MapToEntity(userCreate);

            Class @class = await _classRepository.GetClassByClassNumberAndPeriod(user.Class.ClassNumber, user.Class.Period.Number) ?? throw new InvalidOperationException("Classe não encontrada!");
            user.CreatedAt = DateTime.UtcNow;
            user.CreatedBy = createdBy;
            user.ClassId = @class.Id;
            user.Class = @class;
            user.Class.Period = @class.Period;
            user.Class.PeriodId = @class.PeriodId;


            string hashedPassword = _passwordService.HashPassword(userCreate.Password);
            user.Password = hashedPassword;

            return await _userRepository.CreateUserAsync(user);
        }
    }
}
