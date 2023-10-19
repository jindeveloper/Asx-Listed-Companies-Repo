namespace Ct.Interview.Application.MapperProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ListedCompany,
                    AsxListedCompanyResponseViewModel>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id.ToString()))
                    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.AsxCode, opt => opt.MapFrom(src => src.Code));
        }
    }
}
