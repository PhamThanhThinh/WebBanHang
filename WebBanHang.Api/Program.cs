using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using WebBanHang.Api.Data;
using WebBanHang.Api.Repositories;
using WebBanHang.Api.Repositories.Contracts;

var builder = WebApplication.CreateBuilder(args);

var chuoiKetNoi = builder.Configuration.GetConnectionString("ChuoiKetNoi");

builder.Services.AddDbContext<WebBanhangDbContext>(options => options.UseSqlServer(chuoiKetNoi));

builder.Services.AddScoped<IProductRepository, ProductRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseCors(policy =>
policy.WithOrigins("https://localhost:7204", "http://localhost:5239")
.AllowAnyMethod()
.WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
