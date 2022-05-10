using AutoMapper;
using DPNerd.Employees.Application.Commands;
using DPNerd.Employees.Application.Models;

namespace DPNerd.Employees.Application.AutoMapper;

public class CommandToDomainMappingProfile : Profile
{
    public CommandToDomainMappingProfile()
    {
        CreateMap<InsertEmployeeCommand, Employee>()
            .ForPath(dest => dest.Parents.NameMother, opt => opt.MapFrom(src => src.NameMother))
            .ForPath(dest => dest.Parents.NameFather, opt => opt.MapFrom(src => src.NameFather))
            .ReverseMap();
    }
}
