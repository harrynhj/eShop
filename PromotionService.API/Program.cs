using Microsoft.EntityFrameworkCore;
using PromotionService.Infrastructure.Data;
using PromotionService.ApplicationCore.Repositories;
using PromotionService.ApplicationCore.Services;
using PromotionService.Infrastructure.Repositories;
using PromotionService.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IPromotionDetailRepository, PromotionDetailRepository>();
builder.Services.AddScoped<IPromotionSaleRepository, PromotionSaleRepository>();
builder.Services.AddScoped<IPromotionService, PromotionServices>();

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<PromotionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PromotionDbConnection"));
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
