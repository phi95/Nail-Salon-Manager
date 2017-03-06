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
using System.Web.Security;
using System.Security.Claims;

namespace Nail_Salon_Manager.Controllers.Api
{
    public class TransactionsController : ApiController
    {
        private ApplicationDbContext _context;

        public TransactionsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/transactions
        public IHttpActionResult GetTransactions()
        {
            if(User.IsInRole(RoleName.Employer))
                return Ok(_context.Transactions
                .Include(x => x.Employee)
                .ToList()
                .Select(Mapper.Map<Transaction, TransactionDto>));

            var claimsIdentity = User.Identity as ClaimsIdentity;
            var employeeId = claimsIdentity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            return Ok(_context.Transactions
                .Where(x=>x.EmployeeId == employeeId)
                .Include(x => x.Employee)
                .ToList()
                .Select(Mapper.Map<Transaction, TransactionDto>));
        }

        // GET /api/transactions/1
        public IHttpActionResult GetTransaction(int id)
        {
            var transaction = _context.Transactions.SingleOrDefault(x => x.Id == id);

            if (transaction == null)
                return NotFound();

            return Ok(Mapper.Map<Transaction, TransactionDto>(transaction));
        }

        // POST /api/transactions
        [HttpPost]
        public IHttpActionResult CreateTransaction(TransactionDto transactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var transaction = Mapper.Map<TransactionDto, Transaction>(transactionDto);
            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            transactionDto.Id = transaction.Id;

            return Created(new Uri(Request.RequestUri + "/" + transaction.Id), transactionDto);
        }

        // PUT /api/transactions/1
        [HttpPut]
        public IHttpActionResult UpdateTransaction(int id, TransactionDto transactionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var transactionInDb = _context.Transactions.SingleOrDefault(x => x.Id == id);
            if (transactionInDb == null)
                return NotFound();

            Mapper.Map(transactionDto, transactionInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/transactions/1
        [HttpDelete]
        public IHttpActionResult DeleteTransaction(int id)
        {
            var transactionInDb = _context.Transactions.SingleOrDefault(x => x.Id == id);
            if (transactionInDb == null)
                return NotFound();

            _context.Transactions.Remove(transactionInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
