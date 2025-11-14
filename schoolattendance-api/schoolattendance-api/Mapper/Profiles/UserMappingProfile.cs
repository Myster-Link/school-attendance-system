using AutoMapper;
using Repository.Models;
using schoolattendance_api.Dtos.User;

namespace schoolattendance_api.Mapper.Profiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<MasterUser, UserDto>().ReverseMap();
            CreateMap<MasterUser, UserInsertDto>().ReverseMap();
            // Mapeos generales
            /*CreateMap<MasterUser, MasterUserDto>().ReverseMap();
            CreateMap<MasterUserDetail, MasterUserDetailDto>().ReverseMap();
            CreateMap<MasterUserConfig, MasterUserConfigDto>().ReverseMap();
            CreateMap<MasterUserCertificate, MasterUserCertificateDto>().ReverseMap();
            CreateMap<MasterUserEconomicActivity, MasterUserEconomicActivityDto>().ReverseMap();
            CreateMap<MasterUserConsecutive, MasterUserConsecutiveDto>().ReverseMap();
            CreateMap<CommonEnvironment, CommonEnvironmentDto>().ReverseMap();

            CreateMap<MasterUserDto, UserDto>()
                .ForMember(dest => dest.UserDetails, opt => opt.MapFrom(src => src.MasterUserDetail))
                .ForMember(dest => dest.EconomicActivities, opt => opt.MapFrom(src =>
                    src.MasterUserEconomicActivities.Select(mua => new EconomicActivityDto
                    {
                        EconomicActivityId = mua.EconomicActivity.EconomicActivityId,
                        ActivityName = mua.EconomicActivity.ActivityName
                    }).ToList()))
                .ReverseMap();

            CreateMap<MasterUserDto, UserInsertDto>().ReverseMap();

            CreateMap<MasterUserDetailDto, UserDetailDto>().ReverseMap();
            CreateMap<UserDetailInsertDto, MasterUserDetailDto>();
            CreateMap<UserDetailUpdateDto, MasterUserDetailDto>()
                .ForMember(dest => dest.LogoFilename, opt => opt.Ignore());

            CreateMap<MasterUserConfigDto, UserConfigInsertDto>().ReverseMap();
            CreateMap<MasterUserConfigDto, UserConfigUpdateDto>().ReverseMap();
            CreateMap<MasterUserConfigDto, UserConfigDto>().ReverseMap();

            CreateMap<MasterUserCertificateDto, UserConfigInsertDto>().ReverseMap();
            CreateMap<MasterUserCertificateDto, UserConfigUpdateDto>().ReverseMap();
            CreateMap<MasterUserCertificateDto, UserConfigDto>().ReverseMap();*/
        }
    }
}
