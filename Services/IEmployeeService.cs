using EmployeeCrudApi.DTOs;
using EmployeeCrudApi.Models;

namespace EmployeeCrudApi.Services;

public interface IEmployeeService
{
    IEnumerable<Employee> GetAll();
    Employee? GetById(int id);
    ServiceResult<Employee> Create(CreateEmployeeDto dto);
    ServiceResult<Employee> Update(int id, UpdateEmployeeDto dto);
    bool Delete(int id);
}
