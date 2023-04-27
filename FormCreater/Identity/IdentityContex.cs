using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FormCreater.Identity
{
    public class IdentityContex : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"server=.\HASANERTURK;database=FormCreaterDB; integrated security=true;TrustServerCertificate=True;");
        }
        public IdentityContex(DbContextOptions<IdentityContex> options) : base(options)
        {

        }
    }
}