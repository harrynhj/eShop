using Microsoft.EntityFrameworkCore;
using ShippingService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<ShippingDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ShippingDbConnection"));
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();

app.Run();
