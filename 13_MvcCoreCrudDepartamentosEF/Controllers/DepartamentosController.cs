using _13_MvcCoreCrudDepartamentosEF.Models;
using _13_MvcCoreCrudDepartamentosEF.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace _13_MvcCoreCrudDepartamentosEF.Controllers
{
    public class DepartamentosController : Controller
    {
        RepositoryDepartamento repo;

        public DepartamentosController(RepositoryDepartamento repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Departamento> departamentos = this.repo.GetDepartamentos();
            return View(departamentos);
        }

        public IActionResult Details(int idDepartamento)
        {
            Departamento departamento = this.repo.FindDepartamento(idDepartamento);
            return View(departamento);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento)
        {
            await this.repo.CreateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int idDepartamento)
        {
            Departamento departamento = this.repo.FindDepartamento(idDepartamento);
            return View(departamento);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Departamento departamento)
        {
            await this.repo.UpdateDepartamentoAsync(departamento.IdDepartamento, departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int idDepartamento)
        {
            await this.repo.DeleteDepartamentoAsync(idDepartamento);
            return RedirectToAction("Index");
        }
    }
}