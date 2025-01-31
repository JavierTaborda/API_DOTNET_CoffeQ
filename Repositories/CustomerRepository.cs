using API_CoffeQ.Context;
using API_CoffeQ.DTOs;
using API_CoffeQ.Interfaces;
using API_CoffeQ.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_CoffeQ.Repositories
{
    public class CustomerRepository( CafetinContext context, IMapper mapper) : ICustomersRepository
    {
        private readonly CafetinContext _context = context;
        private readonly IMapper _mapper=mapper;
        public async Task<CustomerDTO> AddCustomer(CustomerDTO customer)
        {
            var entity = _mapper.Map<Customer>(customer);
            var result = await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerDTO>(result.Entity);
           
        }
  
        public async Task<CustomerDTO> GetCustomer(int id)
        {
            
            var customer = await _context.Customers.FindAsync(id);
            return _mapper.Map<CustomerDTO>(customer) ;
        }

        public async Task<List<CustomerDTO>> GetCustomers()
        {

            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDTO>>(customers);
        }

        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO customer)
        {
            var entity = _mapper.Map<Customer>(customer);
            var result = _context.Customers.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<CustomerDTO>(result.Entity);
        }
        public async Task<CustomerDTO> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return null!;
            }

            _context.Customers.Remove(customer);
            return _mapper.Map<CustomerDTO>(customer); ;
        }
    }
}
