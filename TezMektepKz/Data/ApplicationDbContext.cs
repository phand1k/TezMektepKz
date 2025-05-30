using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TezMektepKz.Models;
using TezMektepKz.Models.Identity;

namespace TezMektepKz.Data;

public class ApplicationDbContext : IdentityDbContext<AspNetUser>
{
    public DbSet<Grade> Grades { get; set; }
    public DbSet<AspNetUser> AspNetUsers { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Ученик",
                NormalizedName = "УЧЕНИК"
            },
            new IdentityRole
            {
                Name = "Директор",
                NormalizedName = "ДИРЕКТОР"
            },
            new IdentityRole
            {
                Name = "Учитель",
                NormalizedName = "УЧИТЕЛЬ"
            },
            new IdentityRole
            {
                Name = "Кассир",
                NormalizedName = "КАССИР"
            },
            new IdentityRole
            {
                Name = "Админ",
                NormalizedName = "АДМИН"
            }
            );

        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<AspNetUser>().HasQueryFilter(x => x.IsDeleted == false);
        modelBuilder.Entity<Organization>().HasQueryFilter(x => x.IsDeleted == false);
    }
}
