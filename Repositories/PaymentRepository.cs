using API_CoffeQ.Context;
using API_CoffeQ.DTOs;
using API_CoffeQ.Interfaces;
using API_CoffeQ.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API_CoffeQ.Repositories
{
    public class PaymentRepository( CafetinContext context, IMapper mapper) : IPaymentRepository
    {
        private readonly CafetinContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task<PaymentDTO> AddPayment(PaymentDTO payment)
        {
            var entity = _mapper.Map<Payment>(payment);
            var result = await _context.Payments.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PaymentDTO>(result.Entity);
        }

        public async Task<PaymentDTO> GetPayment(int id)
        {
            var payment = await _context.Payments.FindAsync(id);
            return _mapper.Map<PaymentDTO>( payment);
        }
        public async Task<List<PaymentDTO>> GetPaymentOrder(int id)
        {
            var payment = await _context.Payments.Where(p=>p.IdOrder==id).ToListAsync();
            return _mapper.Map<List<PaymentDTO>>( payment);
        }

        public async Task<List<PaymentDTO>> GetPayments(DateTime f1, DateTime f2, string customeCedula)
        {
            var query = _context.Payments
                .Include(C => C.IdOrderNavigation!.IdCustomerNavigation)
                .Where(p => p.Date >= f1.Date && p.Date <= f2.Date);

            if (!customeCedula.Contains("Todos"))
            {
                query = query.Where(p => p.IdOrderNavigation!.IdCustomerNavigation.Cedula == customeCedula);
            }

            var payments = await query.ToListAsync();
            return _mapper.Map<List<PaymentDTO>>(payments);
        }

        public async Task<PaymentDTO> UpdatePayment(PaymentDTO payment)
        {
            var entity = _mapper.Map<Payment>(payment);
            var result = _context.Payments.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PaymentDTO>( result.Entity);

        }
        public async Task<PaymentDTO> DeletePayment(int id)
        {
            var pay = await _context.Payments.FindAsync(id);
            if (pay == null)
            {
                return null!;
            }
            _context.Payments.Remove(pay);
            await _context.SaveChangesAsync();

            return _mapper.Map<PaymentDTO>(pay);

        }
    }


}
