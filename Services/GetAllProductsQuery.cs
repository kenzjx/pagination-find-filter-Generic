
using MediatR;
using ServerNet.Instracture;
using ServerNet.Models;
using ServerNet.Pagination;

namespace Domain.Services
{
    public class GetAllProductsQuery : IRequest<PagedList<Product>>
    {

        public ProductParameters Parameters { get; set; }
    }
}   