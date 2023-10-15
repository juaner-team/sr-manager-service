using AutoMapper;
using Sr.Manager.Core.Domains.Entities.User;
using Sr.Manager.Service.Common.Common.Converter;
using Sr.Manager.Service.Core.User.Input;
using Sr.Manager.Service.Core.User.Output;

namespace Sr.Manager.Service.Common.Mapper.Core
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<ModifyUserDto, UserEntity>();
            CreateMap<UserEntity, UserDto>()
                .ForMember(d => d.Address, opt => opt.MapFrom(s => $"{s.Province}{s.City}{s.District}{s.Street}"))
                .ForMember(d => d.Gender, opt => opt.ConvertUsing<GenderFormatter, int>());
        }
    }
}
