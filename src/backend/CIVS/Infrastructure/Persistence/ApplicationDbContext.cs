using Domain.Agencies;
using Domain.Common;
using Domain.Converters.Persistence;
using Domain.Departments;
using Domain.Owners;
using Domain.Positions;
using Domain.Slots;
using Domain.Users;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext  : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options) 
        : base(options) { }
    
    public DbSet<User> Users { get; init; }
    
    public DbSet<Owner> Owners { get; init; }
    
    public DbSet<Slot> Slots { get; init; }
    
    public DbSet<Position> Positions { get; init; }
    
    public DbSet<Department> Departments { get; init; }
    
    public DbSet<Agency> Agencies { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ComplexProperty(e => e.Address);
        });

        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ComplexProperty(e => e.Address);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Email);
            entity.ComplexProperty(e => e.Name, b =>
            {
                b.Property(x => x.Firstname);
                b.Property(x => x.Lastname);
            });
            entity.Property(e => e.Username);
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.ComplexProperty(e => e.Code, b =>
            {
                b.Property(x => x.Value);
            });
            entity.ComplexProperty(e => e.Address);
            entity.ComplexProperty(e => e.Contact);
        });
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Email>()
            .HaveConversion<EmailConverter>();
        
        configurationBuilder
            .Properties<Username>()
            .HaveConversion<UsernameConverter>();
        
        configurationBuilder
            .Properties<AgencyId>()
            .HaveConversion<EntityIdConverter<AgencyId>>();
        
        configurationBuilder
            .Properties<DepartmentId>()
            .HaveConversion<EntityIdConverter<DepartmentId>>();
        
        configurationBuilder
            .Properties<OwnerId>()
            .HaveConversion<EntityIdConverter<OwnerId>>();
        
        configurationBuilder
            .Properties<PositionId>()
            .HaveConversion<EntityIdConverter<PositionId>>();
        
        configurationBuilder
            .Properties<SlotId>()
            .HaveConversion<EntityIdConverter<SlotId>>();
        
        configurationBuilder
            .Properties<UserId>()
            .HaveConversion<EntityIdConverter<UserId>>();
    }
}