namespace EmployeeCrudApi.DTOs;

public record CreateEmployeeDto(
    string FirstName,
    string LastName,
    string Email,
    string Position,
    DateTime HireDate);
