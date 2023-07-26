using adstaskhub_api.Application.DTOs;
using adstaskhub_api.Application.Services.Interfaces;
using adstaskhub_api.Domain.Models;
using adstaskhub_api.Infrastructure.Mappers.Interfaces;
using adstaskhub_api.Infrastructure.Repositories.Interfaces;
using adstaskhub_api.Helpers.ErrorMessages;

namespace adstaskhub_api.Application.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly IUserMapper _userMapper;
        private readonly IClassRepository _classRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IPasswordService passwordService, IUserMapper userMapper, IClassRepository classRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _passwordService = passwordService;
            _userMapper = userMapper;
            _classRepository = classRepository;
            _roleRepository = roleRepository;
        }

        public async Task<UserDTOBase> CreateUser(UserCreateDTO userCreate, string createdBy)
        {
            if (userCreate == null)
            {
                throw new ArgumentNullException(nameof(userCreate), UserErrorMessages.UserCreationDataNull);
            }

            if (string.IsNullOrEmpty(createdBy))
            {
                throw new ArgumentNullException(nameof(createdBy), UserErrorMessages.UserCreationDataNull);
            }

            User existingUser = await _userRepository.GetUserByEmailAsync(userCreate.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException(UserErrorMessages.UserAlreadyExists);
            }

            User user = _userMapper.MapToEntity(userCreate);

            Class @class = await _classRepository.GetClassByClassNumberAndPeriod(user.Class.ClassNumber, user.Class.Period.Number) ?? throw new InvalidOperationException(ClassErrorMessages.ClassNotFound);
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

        public async Task<UserDTOBase> ApproveUser(long userId, string updateBy)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId), UserErrorMessages.UserCreationDataNull);
            }

            if (string.IsNullOrEmpty(updateBy))
            {
                throw new ArgumentNullException(nameof(updateBy), UserErrorMessages.UserCreationDataNull);
            }

            User user = await _userRepository.GetUserByIdAsync(userId) ?? throw new Exception(UserErrorMessages.UserNotFound);

            user.IsApproved = true;
            user.UpdatedBy = updateBy;
            user.UpdatedAt = DateTime.UtcNow;

            return await _userRepository.UpdateUserAsync(user, userId);
        }

        public async Task<UserDTOBase> ChangeUserClass(long userId, int newClassNumber, int newPeriodNumber, string updateBy)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId), UserErrorMessages.UserCreationDataNull);
            }

            if (string.IsNullOrEmpty(updateBy))
            {
                throw new ArgumentNullException(nameof(updateBy), UserErrorMessages.UserCreationDataNull);
            }

            User user = await _userRepository.GetUserByIdAsync(userId) ?? throw new Exception(UserErrorMessages.UserNotFound);
            Class newClass = await _classRepository.GetClassByClassNumberAndPeriod(newClassNumber, newPeriodNumber) ?? throw new Exception(ClassErrorMessages.ClassNotFound);
            user.ClassId = newClass.Id;
            user.UpdatedBy = updateBy;
            user.UpdatedAt = DateTime.UtcNow;

            return await _userRepository.UpdateUserAsync(user, userId);
        }

        public async Task<UserDTOBase> ChangeUserRole(long userId, long roleId, string updateBy)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId), UserErrorMessages.UserCreationDataNull);
            }

            if (string.IsNullOrEmpty(updateBy))
            {
                throw new ArgumentNullException(nameof(updateBy), UserErrorMessages.UserCreationDataNull);
            }

            User user = await _userRepository.GetUserByIdAsync(userId) ?? throw new Exception(UserErrorMessages.UserNotFound);
            _ = await _roleRepository.GetRoleByIdAsync(roleId) ?? throw new Exception(RoleErrorMessages.RoleNotFound);

            user.RoleId = roleId;
            user.UpdatedBy = updateBy;
            user.UpdatedAt = DateTime.UtcNow;

            return await _userRepository.UpdateUserAsync(user, userId);
        }

        public async Task<UserDTOBase> ChangeUserPassword(long userId, string newPassword, string updateBy)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId), UserErrorMessages.UserCreationDataNull);
            }

            if (string.IsNullOrEmpty(updateBy))
            {
                throw new ArgumentNullException(nameof(updateBy), UserErrorMessages.UserCreationDataNull);
            }

            User user = await _userRepository.GetUserByIdAsync(userId) ?? throw new Exception(UserErrorMessages.UserNotFound);

            string hashedPassword = _passwordService.HashPassword(newPassword);
            user.Password = hashedPassword;
            user.UpdatedBy = updateBy;
            user.UpdatedAt = DateTime.UtcNow;

            return await _userRepository.UpdateUserAsync(user, userId);
        }

        public async Task<bool> SoftDeleteUser(long userId, string updateBy)
        {
            if (userId == null)
            {
                throw new ArgumentNullException(nameof(userId), UserErrorMessages.UserCreationDataNull);
            }

            if (string.IsNullOrEmpty(updateBy))
            {
                throw new ArgumentNullException(nameof(updateBy), UserErrorMessages.UserCreationDataNull);
            }

            User userById = await _userRepository.GetUserByIdAsync(userId) ?? throw new Exception(UserErrorMessages.UserNotFound);

            userById.IsDeleted = true;
            userById.UpdatedBy = updateBy;
            userById.UpdatedAt = DateTime.UtcNow;

            await _userRepository.UpdateUserAsync(userById, userId);
            return true;
        }
    }
}
