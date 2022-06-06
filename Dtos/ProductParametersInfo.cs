namespace ServerNet.Dtos
{
    public class ProductParametersInfo : IValidatableDto
    {
        public ProductParametersInfo()
        {
            OrderBy = "ProductRegisterDate";
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; } 
        public string? OrderBy { get; set; }
    }
}