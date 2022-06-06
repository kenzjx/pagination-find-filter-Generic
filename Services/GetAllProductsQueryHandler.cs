using Domain.Services;
using MediatR;
using ServerNet.Instracture;
using ServerNet.Pagination;
using ServerNet.Repository;

namespace ServerNet.Services
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedList<Product>>
    {
     
        public IProductRepository repository { get; }
        public GetAllProductsQueryHandler( IProductRepository repository)
        {
            repository = repository;
           
        }
        public async Task<PagedList<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            Validate(request);
            var products = await repository.GetProductsAsync(request.Parameters);
         
            return products;
        }

        private void Validate(GetAllProductsQuery request)
        {
            if (request == null)
                throw new ArgumentNullException("Request object can not be null.");

            if (request.Parameters == null)
                throw new ArgumentNullException("Parameters object can not be null.");
        }
    }
}