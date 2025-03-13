using API_CoffeQ.DTOs;

namespace API_CoffeQ.Interfaces
{
    public interface ICustomersRepository
    {
        Task<List<CustomerDTO>> GetCustomers();
        Task<CustomerDTO> GetCustomer(string customer);
        Task<CustomerDTO> AddCustomer(CustomerDTO customer);
        Task<CustomerDTO> UpdateCustomer(CustomerDTO customer);

        Task<CustomerDTO> DeleteCustomer(int id);

    }
}
