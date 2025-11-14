using Encryption.Service;
using Repository.Models;
using Repository.UnitOfWork;
using schoolattendance_api.Dtos.Auth;
using schoolattendance_api.Dtos.User;
using schoolattendance_api.Exceptions;
using schoolattendance_api.Mapper;

namespace schoolattendance_api.Services.Auth
{
    public class AuthService : IAuthService
    {
        public List<string> Errors { get; }
        private string messageError = "Error de inicio de sesión";

        private readonly IUnitOfWorkManager _unitOfWork;
        private readonly IMapperAdapter _mapper;
        private readonly IJwtTokenService _jwtTokenService;
        private readonly IEncryptionStrategy _encryptionStrategy;


        public AuthService(IUnitOfWorkManager unitOfWork,
                            IMapperAdapter mapper,
                           IJwtTokenService tokenGenerator,
                           IEncryptionStrategy encryptionStrategy)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtTokenService = tokenGenerator;
            _encryptionStrategy = encryptionStrategy;
        }

        public async Task<AuthResponseDto> Login(AuthDto authDto)
        {
            _encryptionStrategy.SetStrategyAes();
            var identifier = _encryptionStrategy.Encrypt(authDto.Username);

            var user = await _unitOfWork.UserRepository.GetByIdentification(identifier);

            if (user == null)
            {
                user = await _unitOfWork.UserRepository.GetByEmail(identifier);
                if (user == null) throw new ApiExceptionNotFound(messageError, Errors);
            }

            _encryptionStrategy.SetStrategyBcrypt();
            bool isValid = _encryptionStrategy.Verify(authDto.Password, user.Password);

            if (!isValid) throw new ApiExceptionNotFound(messageError, Errors);

            var userDto = _mapper.Map<MasterUser, UserDto>(user);

            string token = _jwtTokenService.GenerateToken(userDto);

            _encryptionStrategy.SetStrategyAes();
            userDto.Identification = _encryptionStrategy.Decrypt(userDto.Identification);
            userDto.FullName = _encryptionStrategy.Decrypt(userDto.FullName);
            userDto.Email = _encryptionStrategy.Decrypt(userDto.Email);
            userDto.RoleName = user.Role.RoleName;

            return new AuthResponseDto
            {
                Token = token,
                TokenExpiration = _jwtTokenService.timeHours * 3600,
                UserData = userDto
            };
        }

        public async Task<AuthResponseDto> Register(UserInsertDto userInsertDto)
        {
            var user = _mapper.Map<UserInsertDto, MasterUser>(userInsertDto);

            _encryptionStrategy.SetStrategyAes();
            user.Identification = _encryptionStrategy.Encrypt(user.Identification);
            user.Email = _encryptionStrategy.Encrypt(user.Email);

            await _unitOfWork.BeginTransaction();

            var verifiedIdentificate = await _unitOfWork.UserRepository.GetByIdentification(user.Identification);
            var verifiedEmail = await _unitOfWork.UserRepository.GetByEmail(user.Email);

            if (verifiedIdentificate != null) throw new ApiException("El usuario ya se encuentra registrado con esa identificacion");
            if (verifiedEmail != null) throw new ApiException("El usuario ya se encuentra registrado con ese email");

            var uuid = Guid.NewGuid();


            user.UserId = uuid.ToString();

            // Encriptación en AES 
            user.FullName = _encryptionStrategy.Encrypt(user.FullName);

            // Encriptación en BCrypt 
            _encryptionStrategy.SetStrategyBcrypt();
            user.Password = _encryptionStrategy.Encrypt(user.Password);

            user.RoleId = userInsertDto.RoleId;

            await _unitOfWork.UserRepository.Add(user);

            //  We commit
            await _unitOfWork.Commit();

            var userDto = _mapper.Map<MasterUser, UserDto>(user);

            string token = _jwtTokenService.GenerateToken(userDto);

            return new AuthResponseDto
            {
                Token = token,
                TokenExpiration = _jwtTokenService.timeHours * 3600
            };
        }
    }
}
