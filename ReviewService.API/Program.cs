using Microsoft.EntityFrameworkCore;
using ReviewService.ApplicationCore.Services;
using ReviewService.ApplicationCore.Repositories;
using ReviewService.Infrastructure.Data;
using ReviewService.Infrastructure.Services;
using ReviewService.Infrastructure.Repositories;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IReviewService, CustomerReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddDbContext<ReviewDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReviewDbConnection"));
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
