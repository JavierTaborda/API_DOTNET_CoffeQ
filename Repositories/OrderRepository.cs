using API_CoffeQ.Context;
using API_CoffeQ.Interfaces;
using API_CoffeQ.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API_CoffeQ.Models;


namespace API_CoffeQ.Repositories
{
    public class OrderRepository(CafetinContext context, IMapper mapper) : IOrderRepository
    {
        private readonly CafetinContext _context=context;
        private readonly IMapper _mapper = mapper;



        public async Task<OrderDTO> AddOrder(OrderDTO order)
        {
            var entity = _mapper.Map<Order>(order);
            var result = await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(result.Entity);
        }

        public async Task<OrderDetailDTO> AddOrderDetail(OrderDetailDTO order)
        {
            var entity = _mapper.Map<OrderDetail>(order);
            var result = await _context.OrderDetails.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDetailDTO>(result.Entity);
        }

    

        public async Task<OrderDTO> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return null!;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<OrderDTO> GetOrder(int id)
        {
            var order = await _context
                .Orders
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.IdOrder == id);

            return _mapper.Map<OrderDTO>(order);
        }
        public async Task<OrderDTO> ClientOrderRecord(string client)
        {
            var order = await _context
                 .Orders
                 .Include(o => o.OrderDetails)
                 .Include(o => o.Payments)
                 .FirstOrDefaultAsync(o => o.IdCustomerNavigation.Cedula == client);

            return _mapper.Map<OrderDTO>(order);
        }

        public async Task<List<OrderDTO>> GetOrders(int customerid)
        {
            var orders = await _context
                .Orders
                .Include(o => o.OrderDetails)
                .Where(o => o.IdCustomer == customerid)
                .ToListAsync();

            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<OrderDTO> UpdateOrder(OrderDTO order)
        {
            var entity = _mapper.Map<Order>(order);
            var result = _context.Orders.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<OrderDTO>(result.Entity);
        }
    }
}
