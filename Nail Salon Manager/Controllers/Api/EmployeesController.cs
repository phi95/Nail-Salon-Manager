using AutoMapper;
using Nail_Salon_Manager.Dtos;
using Nail_Salon_Manager.Models;
using System;
using System.Data.Entity;
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
        public IHttpActionResult GetEmployees()
        {
            return Ok(_context.Employees.ToList().Select(Mapper.Map<Employee, EmployeeDto>));
        }

        // GET /api/employees/1
        public IHttpActionResult GetEmployee(string id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);

            if (employee == null)
                return NotFound();

            return Ok(Mapper.Map<Employee, EmployeeDto>(employee));
        }

        // GET /api/employees/1/transactions
        [Route("api/employees/transactions/{id}")]
        public IHttpActionResult GetEmployeeTransactions(string id)
        {
            return Ok(_context.Transactions.Where(x=>x.EmployeeId == id).ToList().Select(Mapper.Map<Transaction, TransactionDto>));
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
        public IHttpActionResult UpdateEmployee(string id, EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var employeeInDb = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employeeInDb == null)
                return NotFound();

            Mapper.Map(employeeDto, employeeInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/employees/1
        [HttpDelete]
        public IHttpActionResult DeleteEmployee(string id)
        {
            var employeeInDb = _context.Employees.SingleOrDefault(x => x.Id == id);
            if (employeeInDb == null)
                return NotFound();

            var employeeInUser = _context.Users.SingleOrDefault(x => x.Id == id);
            _context.Employees.Remove(employeeInDb);
            _context.Users.Remove(employeeInUser);
            _context.SaveChanges();

            return Ok();
        }
    }
}
