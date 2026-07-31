using EmployeeCrudApi.DTOs;

namespace EmployeeCrudApi.Validation;

public interface IEmployeeValidator
{
    ValidationResult ValidateCreate(CreateEmployeeDto dto);
    ValidationResult ValidateUpdate(UpdateEmployeeDto dto);
}
