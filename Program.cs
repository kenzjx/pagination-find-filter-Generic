using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerNet.Helpers;
using ServerNet.Instracture;
using ServerNet.Mapping;
using ServerNet.Repository;
using ServerNet.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ServerNet.Instracture.AppContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});

var mapperConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MappingProfile());
    });
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
// builder.Services.AddTransient(typeof(ISortHelper<>), typeof(SortHelper<>));
// builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
builder.Services.AddScoped<ISortHelperProudct>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    InsertProduct.Initialize(scope.ServiceProvider);
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
