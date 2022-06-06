namespace ServerNet.Dtos
{
    public class ProductDto : IValidatableDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime ProductRegisterDate { get; set; }
       
    }

    public class CreateProductDto : IValidatableDto
    {
        public string Name { get; set; }
        public DateTime ProductRegisterDate { get; set; }
       
    }
}