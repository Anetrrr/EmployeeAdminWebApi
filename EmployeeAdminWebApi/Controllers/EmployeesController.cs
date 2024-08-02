using EmployeeAdminWebApi.Data;
using EmployeeAdminWebApi.Models;
using EmployeeAdminWebApi.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminWebApi.Controllers
{
    // localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = dbContext.Employees.ToList();
            return Ok(allEmployees);

        }

        [HttpPost]
        public IActionResult CreateEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            var newEmp = new Employee()
            {
                Name = addEmployeeDTO.Name,
                Email = addEmployeeDTO.Email,
                Phone = addEmployeeDTO.Phone,
                Salary = addEmployeeDTO.Salary

            };
            dbContext.Employees.Add(newEmp);
            dbContext.SaveChanges();
            return Ok(newEmp);
        }

        [HttpGet]
        [Route("{Id:guid}")]
        public IActionResult GetSingleEmployee(Guid Id)
        {
            var search = dbContext.Employees.Find(Id);

            if (search != null)
            {
                var searchedEmployee = new Employee()
                {
                    Name = search.Name,
                    Email = search.Email,
                    Phone = search.Phone,
                    Salary = search.Salary

                };

                return Ok(searchedEmployee);

            }
            return NotFound($"Employee with {Id} not found");

        }

        [HttpPut]
        [Route("{Id:guid}")]
        public IActionResult UpdateEmployee(Guid Id, UpdateEmployeeDTO updateEmployeeDTO)
        {
            var search = dbContext.Employees.Find(Id);

            if (search != null)

            {
                search.Name = updateEmployeeDTO.Name;
                search.Salary = updateEmployeeDTO.Salary;
                search.Email = updateEmployeeDTO.Email;
                search.Phone = updateEmployeeDTO.Phone;
                
                dbContext.SaveChanges();

                return Ok(search);

            }
            return NotFound($"Employee with {Id} not found");

        }
        [HttpDelete]
        [Route("{Id:guid}")]
        public IActionResult DeleteEmployee(Guid Id)
        {
            var employee = dbContext.Employees.Find(Id);
            

            if(employee != null) {

                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
                return Ok();
        }
            return NotFound();

    }
    


}
}

