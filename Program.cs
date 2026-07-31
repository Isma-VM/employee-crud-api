using EmployeeCrudApi.Endpoints;
using EmployeeCrudApi.Repositories;
using EmployeeCrudApi.Services;
using EmployeeCrudApi.Validation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IEmployeeRepository, InMemoryEmployeeRepository>();
builder.Services.AddSingleton<IEmployeeValidator, EmployeeValidator>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();

var app = builder.Build();

app.MapEmployeeEndpoints();

app.Run();
