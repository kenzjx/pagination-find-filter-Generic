
using System;
using System.Threading.Tasks;
using ServerNet.Instracture;
using ServerNet.Models;
using ServerNet.Pagination;

namespace ServerNet.Repository
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        Task<PagedList<Product>> GetProductsAsync(ProductParameters productParameters);
        Task<Product> GetProductByIdAsync(Guid productId);
       
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}