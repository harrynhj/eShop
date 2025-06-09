using Microsoft.EntityFrameworkCore;
using PromotionService.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


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
