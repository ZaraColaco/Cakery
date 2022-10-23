using Cakeryz.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cakeryz.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cakeryz.Data;

public class CakeryzContext : IdentityDbContext<CakeryzUser>
{
    public CakeryzContext(DbContextOptions<CakeryzContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new CakeryzUserEntityConfiguration());
    }
   

    //public DbSet<Cakeryz.Models.Order>? Order { get; set; }

    public DbSet<Cakeryz.Models.Product>? Product { get; set; }

    public DbSet<Cakeryz.Models.OrderProduct>? OrderProduct { get; set; }

    public DbSet<Cakeryz.Models.Order>? Order { get; set; }
    public object CakeryzUser { get; internal set; }
}

public class CakeryzUserEntityConfiguration : IEntityTypeConfiguration<CakeryzUser>
{
    public void Configure(EntityTypeBuilder<CakeryzUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(35);
    }
}