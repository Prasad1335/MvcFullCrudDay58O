using Microsoft.EntityFrameworkCore;

namespace MvcFullCrudDay58O.Models.DataAccess
{
    public class MvcDbContext : DbContext
    {
        public virtual DbSet<User>? Users { get; set; }
        public virtual DbSet<Department>? Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WAIANGDESK13\MSSQLSERVER01;Initial Catalog=MVC_CRUD;Integrated Security=True");
        }
    }


}
