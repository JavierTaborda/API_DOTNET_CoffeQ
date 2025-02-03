using API_CoffeQ.DTOs;
using API_CoffeQ.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API_CoffeQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentRepository paymentRepository):ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository = paymentRepository;

        [HttpGet]
        public async Task<ActionResult<List<PaymentDTO>>> GetPayments()
        {
            var payments = await _paymentRepository.GetPayments();
            return Ok(payments);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDTO>> GetPayment(int id)
        {
            var payment = await _paymentRepository.GetPayment(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }

        [HttpGet("Order/{orderid}")]
        public async Task<ActionResult<List<PaymentDTO>>> GetPaymentsOrder(int orderid)
        {
            var payments = await _paymentRepository.GetPaymentOrder(orderid);
            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult<PaymentDTO>> AddPayment(PaymentDTO payment)
        {
            var newPayment = await _paymentRepository.AddPayment(payment);
            return CreatedAtAction(nameof(GetPayment), new { id = newPayment.IdPayment }, newPayment);
        }
        [HttpPut]
        public async Task<ActionResult<PaymentDTO>> UpdatePayment(PaymentDTO payment)
        {
            var newPayment = await _paymentRepository.UpdatePayment(payment);
            return CreatedAtAction(nameof(GetPayment), new { id = newPayment.IdPayment }, newPayment);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<PaymentDTO>> DeletePayment(int id)
        {
            var payment = await _paymentRepository.DeletePayment(id);
            if (payment == null)
            {
                return NotFound();
            }
            return Ok(payment);
        }
    }
}
