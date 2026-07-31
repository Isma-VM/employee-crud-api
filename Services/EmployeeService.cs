using EmployeeCrudApi.DTOs;
using EmployeeCrudApi.Models;
using EmployeeCrudApi.Repositories;
using EmployeeCrudApi.Validation;

namespace EmployeeCrudApi.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;
    private readonly IEmployeeValidator _validator;

    public EmployeeService(IEmployeeRepository repository, IEmployeeValidator validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public IEnumerable<Employee> GetAll() => _repository.GetAll();

    public Employee? GetById(int id) => _repository.GetById(id);

    public ServiceResult<Employee> Create(CreateEmployeeDto dto)
    {
        var validation = _validator.ValidateCreate(dto);
        if (!validation.IsValid)
            return ServiceResult<Employee>.Invalid(validation.Errors);

        if (_repository.ExistsWithEmail(dto.Email))
            return ServiceResult<Employee>.Invalid(new[] { "Ya existe un empleado con ese email." });

        var employee = new Employee
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            Position = dto.Position,
            HireDate = dto.HireDate
        };

        var created = _repository.Add(employee);
        return ServiceResult<Employee>.Ok(created);
    }

    public ServiceResult<Employee> Update(int id, UpdateEmployeeDto dto)
    {
        var existing = _repository.GetById(id);
        if (existing is null)
            return ServiceResult<Employee>.NotFoundResult();

        var validation = _validator.ValidateUpdate(dto);
        if (!validation.IsValid)
            return ServiceResult<Employee>.Invalid(validation.Errors);

        if (_repository.ExistsWithEmail(dto.Email, excludeId: id))
            return ServiceResult<Employee>.Invalid(new[] { "Ya existe otro empleado con ese email." });

        existing.FirstName = dto.FirstName;
        existing.LastName = dto.LastName;
        existing.Email = dto.Email;
        existing.Position = dto.Position;
        existing.HireDate = dto.HireDate;

        _repository.Update(existing);
        return ServiceResult<Employee>.Ok(existing);
    }

    public bool Delete(int id) => _repository.Delete(id);
}
