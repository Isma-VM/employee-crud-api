using EmployeeCrudApi.Models;

namespace EmployeeCrudApi.Repositories;

public class InMemoryEmployeeRepository : IEmployeeRepository
{
    private readonly List<Employee> _employees = new();
    private int _nextId = 1;

    public IEnumerable<Employee> GetAll() => _employees;

    public Employee? GetById(int id) => _employees.FirstOrDefault(e => e.Id == id);

    public Employee Add(Employee employee)
    {
        employee.Id = _nextId++;
        _employees.Add(employee);
        return employee;
    }

    public bool Update(Employee employee)
    {
        var index = _employees.FindIndex(e => e.Id == employee.Id);
        if (index == -1) return false;

        _employees[index] = employee;
        return true;
    }

    public bool Delete(int id)
    {
        var existing = GetById(id);
        if (existing is null) return false;

        _employees.Remove(existing);
        return true;
    }

    public bool ExistsWithEmail(string email, int? excludeId = null) =>
        _employees.Any(e =>
            e.Email.Equals(email, StringComparison.OrdinalIgnoreCase) &&
            e.Id != excludeId);
}
