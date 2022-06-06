using ServerNet.Instracture;

namespace ServerNet.SeedData
{
    public static class InsertProduct
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = serviceProvider.GetService<ServerNet.Instracture.AppContext>())
            {
                if (context.Products.Any())
                {
                    // Đã có dữ liệu
                    return;
                }

                for (var i = 1; i < 50; i++)
                {
                    context.Add(new Product(){
                        Name = $"Name {i}",
                        ProductRegisterDate = DateTime.Now
                    });
                }
                context.SaveChanges();
            }
        }
    }
}