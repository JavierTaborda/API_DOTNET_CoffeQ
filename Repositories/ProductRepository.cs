using API_CoffeQ.Context;
using API_CoffeQ.Interfaces;
using API_CoffeQ.DTOs;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using API_CoffeQ.Models;

namespace API_CoffeQ.Repositories
{
    public class ProductRepository(CafetinContext context, IMapper mapper) : IProductRepository
    {
        private readonly CafetinContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductDTO> AddProduct(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            var result = await _context.Products.AddAsync(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(result.Entity);
        }
        public async Task<ProductDTO> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            var result = _context.Products.Update(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(result.Entity);
        }
        public async Task<ProductDTO> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null!;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductDTO>(product);
        }
    }
}
