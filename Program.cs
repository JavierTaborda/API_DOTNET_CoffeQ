using API_CoffeQ.Context;
using API_CoffeQ.Interfaces;
using API_CoffeQ.Repositories;
using Microsoft.EntityFrameworkCore;
using API_CoffeQ.Middlewares;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Database
builder.Services.AddDbContext<CafetinContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("CafetinConnection"))
    , ServiceLifetime.Transient);

//Interfaces and Repositories
builder.Services.AddScoped<ICustomersRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//automapper for DTOs
builder.Services.AddAutoMapper(typeof(Program));

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyHeader());

    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
        .WithOrigins("http://example.com") // Replace with your allowed origins
        .AllowAnyHeader()
        .AllowAnyMethod());
});
builder.WebHost.UseUrls("http://*:5291");

var app = builder.Build();

// error handling
app.UseMiddleware<ExeptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

// Use CORS
app.UseCors("AllowAllOrigins");

app.MapControllers();

app.Run();
