using _13_MvcCoreCrudDepartamentosEF.Models;
using Microsoft.EntityFrameworkCore;

namespace _13_MvcCoreCrudDepartamentosEF.Data
{
    public class DepartamentosContext : DbContext
    {
        public DepartamentosContext(DbContextOptions<DepartamentosContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
