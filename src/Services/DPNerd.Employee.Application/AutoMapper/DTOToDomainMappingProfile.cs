using AutoMapper;
using DPNerd.Employees.Application.DTO;
using DPNerd.Employees.Application.Models;

namespace DPNerd.Employees.Application.AutoMapper;

public class DTOToDomainMappingProfile : Profile
{
    public DTOToDomainMappingProfile()
    {
        CreateMap<ParentsDTO, Parents>()
            .ConstructUsing(p => new Parents(p.NameMother, p.NameFather));

        CreateMap<AddressDTO, Address>()
            .ConstructUsing(p => new Address(p.PublicPlace, p.Number, p.Complement, p.District, p.ZipCode, p.City, p.State, Guid.Empty));

        CreateMap<ContactDTO, Contact>()
            .ConstructUsing(c => new Contact(c.Type, c.Description, c.Value, Guid.Empty));

        CreateMap<GeneralRecordDTO, GeneralRecord>()
            .ConstructUsing(c => new GeneralRecord(c.Number, c.IssuingAgency, c.State, c.DispatchDate, Guid.Empty));

        CreateMap<ReservistDTO, Reservist>()
            .ConstructUsing(c => new Reservist(c.Number, c.EnlistmentRegistration, c.Serie, Guid.Empty));

        CreateMap<VoterTitleDTO, VoterTitle>()
            .ConstructUsing(c => new VoterTitle(c.Number, c.Zone, c.Section, Guid.Empty));

        CreateMap<WorkPassportDTO, WorkPassport>()
            .ConstructUsing(c => new WorkPassport(c.Number, c.Serie, c.State, c.DispatchDate, Guid.Empty));
    }
}
