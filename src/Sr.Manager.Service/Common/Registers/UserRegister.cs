using Sr.Manager.Core.Domains.Entities.User;
using Sr.Manager.Core.Interface.IRepositories.Core;
using Sr.Manager.Service.Core.User.Output;
using Mapster;

namespace Sr.Manager.Service.Common.Registers;

public class UserRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.ForType<UserEntity, UserDto>()
            .Map(d => d.Address, s => $"{s.Province}{s.City}{s.District}{s.Street}")
            .Map(d => d.Gender, s => GenderConvert(s.Gender));
    }

    public string GenderConvert(int sourceMember)
    {
        var typeRepo = MapContext.Current.GetService<IBaseTypeRepo>();
        var itemRepo = MapContext.Current.GetService<IBaseItemRepo>();
        var typeId = typeRepo.Select.Where(t => t.TypeCode == "Sex").ToOne()?.Id;
        var item = itemRepo.Select.Where(i => i.BaseTypeId == typeId && i.ItemCode == $"{sourceMember}").ToOne();
        return item?.ItemName;
    }
}
