using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OSDSII.api.Models;
using OSDSII.api.Data;


namespace OsDsII.api.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context; 
        }
         
         [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Customer> lista = await _context.Customers.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
     
        }
    [HttpGet("{id}")] //Buscar pelo id
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Customer c = await _context.Customers
                    .FirstOrDefaultAsync(cBusca => cBusca.Id == id);

                return Ok(c);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    [HttpPost] 
         public async Task<IActionResult> CreateCustomer(Customer novoCustomer) 
         { 
             try 
             { 
                 await _context.Customers.AddAsync(novoCustomer); 
                 await _context.SaveChangesAsync(); 
  
                 return Ok(novoCustomer.Id); 
             } 
             catch (Exception ex) 
             { 
                 return BadRequest(ex.Message); 
             } 
         } 
         [HttpPut("{id}")] 
         public async Task<IActionResult> UpdateCustomer(Customer novoCustomer) 
         { 
             try 
             {   
                 _context.Customers.Update(novoCustomer); 
                 int linhaAfetadas = await _context.SaveChangesAsync(); 
  
                 return Ok(linhaAfetadas); 
             } 
             catch (Exception ex) 
             { 
                 return BadRequest(ex.Message); 
             } 
         } 
         [HttpDelete] 
         public async Task<IActionResult> DeleteCustomer(int id) 
         { 
             try 
             { 
                 Customer customerRemover = await _context.Customers.FirstOrDefaultAsync(p => p.Id == id); 
  
                 _context.Customers.Remove(customerRemover); 
                 int linhaAfetadas = await _context.SaveChangesAsync(); 
  
                 return Ok(linhaAfetadas); 
             } 
             catch (Exception ex) 
             { 
                 return BadRequest(ex.Message); 
             } 
         }}}