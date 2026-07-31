using System.Text.RegularExpressions;
using EmployeeCrudApi.DTOs;

namespace EmployeeCrudApi.Validation;

public class EmployeeValidator : IEmployeeValidator
{
    private static readonly Regex EmailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    public ValidationResult ValidateCreate(CreateEmployeeDto dto)
    {
        var errors = new List<string>();
        ValidateCommon(dto.FirstName, dto.LastName, dto.Email, dto.Position, dto.HireDate, errors);
        return errors.Count == 0 ? ValidationResult.Success() : ValidationResult.Fail(errors.ToArray());
    }

    public ValidationResult ValidateUpdate(UpdateEmployeeDto dto)
    {
        var errors = new List<string>();
        ValidateCommon(dto.FirstName, dto.LastName, dto.Email, dto.Position, dto.HireDate, errors);
        return errors.Count == 0 ? ValidationResult.Success() : ValidationResult.Fail(errors.ToArray());
    }

    private static void ValidateCommon(
        string firstName, string lastName, string email, string position,
        DateTime hireDate, List<string> errors)
    {
        if (string.IsNullOrWhiteSpace(firstName)) errors.Add("FirstName es obligatorio.");
        if (string.IsNullOrWhiteSpace(lastName)) errors.Add("LastName es obligatorio.");
        if (string.IsNullOrWhiteSpace(email) || !EmailRegex.IsMatch(email)) errors.Add("Email inválido.");
        if (string.IsNullOrWhiteSpace(position)) errors.Add("Position es obligatorio.");
        if (hireDate > DateTime.UtcNow) errors.Add("HireDate no puede ser una fecha futura.");
    }
}
