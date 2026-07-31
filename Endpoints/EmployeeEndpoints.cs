using EmployeeCrudApi.DTOs;
using EmployeeCrudApi.Services;

namespace EmployeeCrudApi.Endpoints;

public static class EmployeeEndpoints
{
    public static void MapEmployeeEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/employees").WithTags("Employees");

        group.MapGet("/", GetAll);
        group.MapGet("/{id:int}", GetById);
        group.MapPost("/", Create);
        group.MapPut("/{id:int}", Update);
        group.MapDelete("/{id:int}", Delete);
    }

    private static IResult GetAll(IEmployeeService service) =>
        Results.Ok(service.GetAll());

    private static IResult GetById(int id, IEmployeeService service)
    {
        var employee = service.GetById(id);
        return employee is null ? Results.NotFound() : Results.Ok(employee);
    }

    private static IResult Create(CreateEmployeeDto dto, IEmployeeService service)
    {
        var result = service.Create(dto);
        return result.Success
            ? Results.Created($"/api/employees/{result.Data!.Id}", result.Data)
            : Results.BadRequest(new { errors = result.Errors });
    }

    private static IResult Update(int id, UpdateEmployeeDto dto, IEmployeeService service)
    {
        var result = service.Update(id, dto);
        if (result.NotFound) return Results.NotFound();

        return result.Success
            ? Results.Ok(result.Data)
            : Results.BadRequest(new { errors = result.Errors });
    }

    private static IResult Delete(int id, IEmployeeService service)
    {
        var deleted = service.Delete(id);
        return deleted ? Results.NoContent() : Results.NotFound();
    }
}
