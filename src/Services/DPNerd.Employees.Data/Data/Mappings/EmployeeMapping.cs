using DPNerd.Core.DomainObjects.ValueObjects;
using DPNerd.Employees.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DPNerd.Employees.Infra.Data.Mappings;

public class EmployeeMapping : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.Registration)
            .IsRequired()
            .HasColumnName("Matricula");

        builder.Property(e => e.FirstName)
            .IsRequired()
            .HasColumnName("Nome")
            .HasColumnType("varchar(50)");

        builder.Property(e => e.LastName)
            .IsRequired()
            .HasColumnName("Sobrenome")
            .HasColumnType("varchar(250)");

        builder.OwnsOne(e => e.Cpf, tf =>
        {
            tf.Property(e => e.Number)
            .IsRequired()
            .HasMaxLength(Cpf.CpfMaxLength)
            .HasColumnName("Cpf")
            .HasColumnType($"varchar({Cpf.CpfMaxLength})");
        });

        builder.Property(e => e.BirthDate)
            .IsRequired()
            .HasColumnName("DataNascimento");

        builder.Property(e => e.Birthplace)
            .IsRequired()
            .HasColumnName("Naturalidade")
            .HasColumnType("varchar(250)");

        builder.Property(e => e.Nationality)
            .IsRequired()
            .HasColumnName("Nacionalidade")
            .HasColumnType("varchar(250)");

        builder.Property(e => e.Gender)
            .IsRequired()
            .HasColumnName("Genero");

        builder.Property(e => e.MaritalStatus)
            .IsRequired()
            .HasColumnName("EstadoCivil");

        builder.Property(e => e.SpouseName)
            .HasColumnName("NomeConjuge")
            .HasColumnType("varchar(250)");

        builder.Property(e => e.HasSpecialNeeds)
            .IsRequired()
            .HasColumnName("PossuiNecessidadesEspeciais");

        builder.Property(e => e.SpecialNeeds)
            .HasColumnName("NecessidadesEspeciais")
            .HasColumnType("varchar(600)");


        builder.HasMany(e => e.Contacts)
            .WithOne(e => e.Employee);

        builder.OwnsOne(e => e.Parents, ep =>
        {
            ep.Property(ep => ep.NameMother)
                .IsRequired()
                .HasColumnName("NomeMae")
                .HasColumnType("varchar(250)");

            ep.Property(ep => ep.NameFather)
                .HasColumnName("NomePai")
                .HasColumnType("varchar(250)");
        });

        builder.OwnsOne(e => e.Pis, es =>
        {
            es.Property(es => es.Number)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("Pis")
                .HasColumnType("varchar(11)");
        });

        builder.HasOne(e => e.WorkPassport)
            .WithOne(e => e.Employee);

        builder.HasOne(e => e.GeneralRecord)
            .WithOne(e => e.Employee);

        builder.HasOne(e => e.Address)
            .WithOne(e => e.Employee);

        builder.HasOne(e => e.VoterTitle)
            .WithOne(e => e.Employee);

        builder.HasOne(e => e.Reservist)
            .WithOne(e => e.Employee);

        builder.ToTable("Colaboradores");
    }
}
