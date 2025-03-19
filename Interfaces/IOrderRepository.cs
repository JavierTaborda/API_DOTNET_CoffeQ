using API_CoffeQ.DTOs;

namespace API_CoffeQ.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderDTO>> GetOrders( int customerid );
        Task<string> GetNumberOrder(string customerCedula);
        Task<OrderDTO> GetOrder(int id);
        Task<OrderDTO> AddOrder(OrderDTO order);

        Task<OrderDetailDTO> AddOrderDetail(OrderDetailDTO order);

        Task<OrderDTO> UpdateOrder(OrderDTO order);
        Task<OrderDTO> DeleteOrder(int id);
        Task<OrderDTO> ClientOrderRecord(string client);

    }
}
