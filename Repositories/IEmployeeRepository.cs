using EmployeeCrudApi.Models;

namespace EmployeeCrudApi.Repositories;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAll();
    Employee? GetById(int id);
    Employee Add(Employee employee);
    bool Update(Employee employee);
    bool Delete(int id);
    bool ExistsWithEmail(string email, int? excludeId = null);
}

