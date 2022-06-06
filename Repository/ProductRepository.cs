
using Microsoft.EntityFrameworkCore;
using ServerNet.Helpers;
using ServerNet.Instracture;
using ServerNet.Models;
using ServerNet.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerNet.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {

        private ISortHelperProudct _productSortHelper;
        public ProductRepository(ServerNet.Instracture.AppContext repositoryContext, ISortHelperProudct productSortHelper)
           : base(repositoryContext)
        {
            _productSortHelper = productSortHelper;
        }

        public void CreateProduct(Product product)
        {
            Create(product);
        }

        public void DeleteProduct(Product product)
        {
            Delete(product);
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await FindAll()
                        .OrderBy(p => p.Name)
                        .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            return await FindByCondition(product => product.Id.Equals(productId))
                        .FirstOrDefaultAsync();
        }

        public async Task<PagedList<Product>> GetProductsAsync(ProductParameters productParameters)
        {
            var products = FindAll();

            SearchByName(ref products, productParameters.Name);
            if(productParameters.OrderBy == null)
            {
                productParameters.OrderBy = "Name";
            }

            var sorderProducts = _productSortHelper.ApplySort(products, productParameters.OrderBy);
           
            return await PagedList<Product>.ToPagedList(sorderProducts, productParameters.PageNumber, productParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Product> products, string productName)
        {
            if (!products.Any() || string.IsNullOrWhiteSpace(productName))
                return;

            products = products.Where(o => o.Name.ToLower().Contains(productName.Trim().ToLower()));
        }

      

        public void UpdateProduct(Product product)
        {
            Update(product);
        }
    }
}