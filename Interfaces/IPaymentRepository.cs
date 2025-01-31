using API_CoffeQ.DTOs;


namespace API_CoffeQ.Interfaces
{
    public interface IPaymentRepository
    {
        Task<PaymentDTO> AddPayment(PaymentDTO payment);
        Task<List<PaymentDTO>> GetPayments();
        Task<PaymentDTO> GetPayment(int id);
        Task<PaymentDTO> UpdatePayment(PaymentDTO payment);
        Task<PaymentDTO> DeletePayment(int id);
    }
}
