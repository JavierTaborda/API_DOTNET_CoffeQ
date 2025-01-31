using API_CoffeQ.DTOs;

namespace API_CoffeQ.Interfaces
{
    public interface IProductRepository
    {
        Task<List<ProductDTO>> GetProducts();
        Task<ProductDTO> GetProduct(int id);
        Task<ProductDTO> AddProduct(ProductDTO product);
        Task<ProductDTO> UpdateProduct(ProductDTO product);

        Task<ProductDTO> DeleteProduct(int id);
    }
}
