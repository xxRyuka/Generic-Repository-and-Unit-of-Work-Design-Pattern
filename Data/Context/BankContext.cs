using Microsoft.EntityFrameworkCore;
using rdp.Data.Configurations;
using rdp.Data.Entities;

namespace rdp.Data.Context;

public class BankContext : DbContext
{
    public BankContext(DbContextOptions<BankContext> options) : base(options)
    {
        
    }
    public DbSet<Account> Accounts{ get; set; }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}