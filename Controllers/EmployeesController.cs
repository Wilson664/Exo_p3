using Exo_P3.Models;
using Exo_P3.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace Exo_P3.Controllers
{
    [Route("employees")]
    public class EmployeesController : Controller
    {
        [Route("index")]
        [Route("index/{id?}")]
        [Route("{id?}")]
        public IActionResult Index(int? id)
        {

            var employees = GenerateEmployees();
            //if (id == null)
            //{
            //    return View(EmployeesToString(employees));
            //}
            //var employeeIndex=employees.FirstOrDefault(x => x.Id == id);
            //if (employeeIndex == null)
            //{
            //    return new EmptyResult();
            //    //return NotFound($" l'employer avec id "+ employeeIndex+" n'existe pas");
            //}
            var vm = new EmployeesIndexVM();
            vm.Employees = employees;
            return View(vm);
        }

        private static IList<Employee> GenerateEmployees()
        {
            return [
                new Employee() { Id = 1, Name = "Adam", HiringDate = DateTimeOffset.Parse("2016-11-23"), YearlySalary = 28000 },

                new Employee() { Id = 2, Name = "Benoit", HiringDate = DateTimeOffset.Parse("2006-08-17"), YearlySalary = 70000 },
                new Employee() { Id = 3, Name = "Charles", HiringDate = DateTimeOffset.Parse("2014-03-14"), YearlySalary = 60000 },
                new Employee() { Id = 4, Name = "Denis", HiringDate = DateTimeOffset.Parse("2019-01-22"), YearlySalary = 19000 },
                new Employee() { Id = 5, Name = "Émile", HiringDate = DateTimeOffset.Parse("2017-06-01"), YearlySalary = 84000 },
                new Employee() { Id = 6, Name = "Fanny", HiringDate = DateTimeOffset.Parse("2022-07-12"), YearlySalary = 30000 },
                new Employee() { Id = 7, Name = "Gaétan", HiringDate = DateTimeOffset.Parse("2020-12-07"), YearlySalary = 40000 },
                new Employee() { Id = 8, Name = "Hugo", HiringDate = DateTimeOffset.Parse("2003-08-23"), YearlySalary = 80000 },
                new Employee() { Id = 9, Name = "Ibrahem", HiringDate = DateTimeOffset.Parse("2018-04-09"), YearlySalary = 65000 },
                new Employee() { Id = 10, Name = "Jonathan", HiringDate = DateTimeOffset.Parse("2016-01-19"), YearlySalary = 70000 }
];
        }
        private string EmployeesToString(IList<Employee> employees) { 
            return string.Join("\r\n", employees.Select(e => e.ToString()));
        
        }

        [Route("aleatoire")]
        public IActionResult Aleatoire()
        {
            var employees = GenerateEmployees();
            var random = new Random();
            var employeeAleatoire = employees[random.Next(employees.Count)];
           
            return Content(employeeAleatoire.ToString());
        }

        [Route("chercher/{nom}")]
        public IActionResult Chercher(string nom)
        {
            var emp=GenerateEmployees();
            var empNom=emp.FirstOrDefault(e => e.Name.Equals(nom , StringComparison.OrdinalIgnoreCase));
            if (empNom == null)
            {
                return NotFound("L'employé n'existe pas");
            }
            return Content(empNom.ToString());
        }
        [Route("dateembauche/{annee:int:length(4)}/{mois:int:range(1,12)}")]
        public IActionResult DateEmbauche(int annee , int mois)
        {

            var empoyee = GenerateEmployees();
            var empEmbauche=empoyee.Where(e => e.HiringDate.Year==annee && e.HiringDate.Month==mois).ToList(); 
            
            if(empEmbauche.Any())
            {
                return new EmptyResult();
            }
            return Content(EmployeesToString(empEmbauche));
        }

        [Route("moyenne/{propriete}")]
        public IActionResult Moyenne(string propriete)
        {
            var empoyee = GenerateEmployees();
            if (propriete.Equals("salaire", StringComparison.OrdinalIgnoreCase))
            {
                return Content(empoyee.Average(e => e.YearlySalary).ToString());
            }
            else if (propriete.Equals("experience", StringComparison.OrdinalIgnoreCase)) {

                return Content(empoyee.Average(e=>e.YearsOfExperience).ToString());
            }
            return new EmptyResult();
        }

    }

    
    }


