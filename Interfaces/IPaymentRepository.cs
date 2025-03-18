using API_CoffeQ.DTOs;


namespace API_CoffeQ.Interfaces
{
    public interface IPaymentRepository
    {
        Task<PaymentDTO> AddPayment(PaymentDTO payment);
        Task<List<PaymentDTO>> GetPayments(DateTime f1, DateTime f2, string customercedula );
        Task<PaymentDTO> GetPayment(int id);
        Task<List<PaymentDTO>> GetPaymentOrder(int id);
        Task<PaymentDTO> UpdatePayment(PaymentDTO payment);
        Task<PaymentDTO> DeletePayment(int id); 
    }
}
