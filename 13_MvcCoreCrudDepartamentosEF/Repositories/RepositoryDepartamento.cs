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

        //METODO PARA CREAR UN DEPARTAMENTO, LAS CONSULTAS DE ACCION PUEDEN SER ASINCRONAS
        public async Task CreateDepartamentoAsync(int id, string nombre, string localidad)
        {
            //INSTANCIAR EL MODELO
            Departamento departamento = new Departamento();
            departamento.IdDepartamento = id;
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;

            //AÑADIMOS EL MODEL A LA COLECCION CONTEXT
            this.context.Departamentos.Add(departamento);

            //GUARDAMOS CAMBIOS EN LA BBDD
            await this.context.SaveChangesAsync();
        }

        //METODO PARA MODIFICAR DEPARTAMENTO
        public async Task UpdateDepartamentoAsync(int id, string nombre, string localidad)
        {
            //BUSCAMOS EL MODELO DENTRO DEL CONTEXT
            Departamento departamento = this.FindDepartamento(id);

            //MODIFICAMOS SUS PROPIEDADES
            departamento.Nombre = nombre;
            departamento.Localidad = localidad;

            //GUARDAMOS CAMBIOS EN LA BBDD
            await this.context.SaveChangesAsync();
        }

        //METODO PARA ELIMINAR POR EL ID
        public async Task DeleteDepartamentoAsync(int id)
        {
            //BUSCAMOS EL MODELO DENTRO DEL CONTEXT
            Departamento departamento = this.FindDepartamento(id);

            //BORRAMOS EL DEPARTAMENTO DE LA COLECCION DE CONTEXT
            this.context.Departamentos.Remove(departamento);

            //GUARDAMOS CAMBIOS EN LA BBDD
            await this.context.SaveChangesAsync();
        }
    }
}
