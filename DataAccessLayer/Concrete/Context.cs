using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=.\HASANERTURK;database=FormCreaterDB; integrated security=true;TrustServerCertificate=True;");
        }

        public DbSet<Form> Forms { get; set; }


    }


}
