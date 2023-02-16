using _13_MvcCoreCrudDepartamentosEF.Data;
using _13_MvcCoreCrudDepartamentosEF.Models;

namespace _13_MvcCoreCrudDepartamentosEF.Repositories
{
    public class RepositoryDepartamento
    {
        private DepartamentosContext context;

        public RepositoryDepartamento(DepartamentosContext context)
        {
            this.context = context;
        }

        public List<Departamento> GetDepartamentos()
        {
            var consulta = from datos in this.context.Departamentos
                           select datos;
            return consulta.ToList();
        }

        public Departamento FindDepartamento(int idDepartamento)
        {
            var consulta = from datos in this.context.Departamentos
                           where datos.IdDepartamento == idDepartamento
                           select datos;
            return consulta.FirstOrDefault();
        }
    }
}
