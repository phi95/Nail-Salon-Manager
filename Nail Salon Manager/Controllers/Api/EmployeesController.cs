using AutoMapper;
using Nail_Salon_Manager.Dtos;
using Nail_Salon_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Nail_Salon_Manager.Controllers.Api
{
    public class EmployeesController : ApiController
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/employees
        public IEnumerable<EmployeeDto> GetEmployees()
        {
            return _context.Employees.ToList().Select(Mapper.Map<Employee, EmployeeDto>);
        }

        // GET /api/employees/1
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);

            if (employee == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Ok(Mapper.Map<Employee, EmployeeDto>(employee));
        }

        // POST /api/employees
        [HttpPost]
        public IHttpActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employee = Mapper.Map<EmployeeDto, Employee>(employeeDto);
            _context.Employees.Add(employee);
            _context.SaveChanges();

            employeeDto.Id = employee.Id;

            return Created(new Uri(Request.RequestUri + "/" + employee.Id), employeeDto);
        }

        // PUT /api/employees/1
        [HttpPut]
        public void UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var employeeInDb = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(employeeDto, employeeInDb);

            _context.SaveChanges();
        }

        // DELETE /api/employees/1
        [HttpDelete]
        public void DeleteEmployee(int id)
        {
            var employeeInDb = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employeeInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Employees.Remove(employeeInDb);
            _context.SaveChanges();
        }
    }
}
