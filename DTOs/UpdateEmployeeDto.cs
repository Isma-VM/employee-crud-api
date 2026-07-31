namespace EmployeeCrudApi.DTOs;

public record UpdateEmployeeDto(
    string FirstName,
    string LastName,
    string Email,
    string Position,
    DateTime HireDate);
