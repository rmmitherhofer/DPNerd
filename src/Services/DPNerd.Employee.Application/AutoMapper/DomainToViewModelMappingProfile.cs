using AutoMapper;
using DPNerd.Employees.Application.Models;
using DPNerd.Employees.Application.Queries.ViewModels;

namespace DPNerd.Employees.Application.AutoMapper;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Parents, ParentsViewModel>()
            .ReverseMap();
        CreateMap<Address, AddressViewModel>()
            .ReverseMap();
        CreateMap<Contact, ContactViewModel>()
            .ForPath(dest => dest.Email, opt => opt.MapFrom(src => src.Email.EmailAddress))
            .ReverseMap();
        CreateMap<GeneralRecord, GeneralRecordViewModel>()
            .ReverseMap();
        CreateMap<Reservist, ReservistViewModel>()
            .ReverseMap();
        CreateMap<VoterTitle, VoterTitleViewModel>()
            .ReverseMap();
        CreateMap<WorkPassport, WorkPassportViewModel>()
            .ReverseMap();
        CreateMap<Employee, EmployeeViewModel>()
            .ForPath(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf.Number))
            .ForPath(dest => dest.Pis, opt => opt.MapFrom(src => src.Pis.Number))
            .ReverseMap();
    }
}
