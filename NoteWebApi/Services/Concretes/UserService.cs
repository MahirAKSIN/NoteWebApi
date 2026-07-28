
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using NoteWebApi.Common;
using NoteWebApi.Dtos;
using NoteWebApi.Entities;
using NoteWebApi.Repository.Interfaces;
using NoteWebApi.Services.Repositories;

namespace NoteWebApi.Services.Concretes
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateUserDto> _validator;

        public UserService(IUserRepository userRepository, IMapper mapper, IValidator<CreateUserDto> validator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<ServiceResult<ResultUserDto>> CreateUserAsync(CreateUserDto dto)
        {
            ValidationResult validationResult = _validator.Validate(dto);

            if (!validationResult.IsValid)
            {
                var errorMessage = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
                return ServiceResult<ResultUserDto>.Fail(errorMessage);
            }


            if (await _userRepository.ExistsByUsernameAsync(dto.UserName))
            {
                return ServiceResult<ResultUserDto>.Fail(new List<string> { "Bu kullanıcının adı zaten alınmış" });
            }

            var user = _mapper.Map<User>(dto);

            await _userRepository.AddAsync(user);
            return ServiceResult<ResultUserDto>.Ok(_mapper.Map<ResultUserDto>(user));

        }

        public async Task<ServiceResult<List<ResultUserDto>>> GetAllUserAsync()
        {

            var users = await _userRepository.GetAllAsync();
            return ServiceResult<List<ResultUserDto>>.Ok(_mapper.Map<List<ResultUserDto>>(users));

        }

        public async Task<ServiceResult<ResultUserDto>> GetByIdUserAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if (user == null)
            {
                return ServiceResult<ResultUserDto>.Fail(new List<string> { "Kullanici bulunamadi" });
            }

            return ServiceResult<ResultUserDto>.Ok(_mapper.Map<ResultUserDto>(user));
        }
    }
}
