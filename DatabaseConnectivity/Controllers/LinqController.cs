using DatabaseConnectivity.Models;

namespace DatabaseConnectivity.Controllers;


public class LinqController
{
    private readonly Region _region = new Region();
    private readonly Country _country = new Country();
    private readonly Location _location = new Location();
    private readonly Employee _employee = new Employee();
    private readonly Department _department = new Department();
    private readonly Job _job = new Job();


    public List<EmployeeData> GetEmployees(int limit)
    {
        List<EmployeeData> employeeDatas = new List<EmployeeData>();
        var employees = (from e in _employee.GetAll()
                         join j in _job.GetAll() on e.JobId equals j.Id
                         join d in _department.GetAll() on e.DepartmentId equals d.Id
                         join l in _location.GetAll() on d.LocationId equals l.Id
                         join c in _country.GetAll() on l.CountryId equals c.Id
                         join r in _region.GetAll() on c.RegionId equals r.Id
                         select new
                         {
                             e.Id,
                             FullName = $"{e.FirstName} {e.LastName}",
                             e.Email,
                             Phone = e.PhoneNumber,
                             e.Salary,
                             Department_Name = d.Name,
                             l.StreetAddress,
                             CountryName = c.Name,
                             RegionName = r.Name
                         }).Take(limit).ToList();

        employeeDatas.AddRange(employees.Select(e => new EmployeeData
        {
            Id = e.Id,
            FullName = e.FullName,
            Email = e.Email,
            Phone = e.Phone,
            Salary = e.Salary,
            Department_Name = e.Department_Name,
            StreetAddress = e.StreetAddress,
            CountryName = e.CountryName,
            RegionName = e.RegionName
        }));

        return employeeDatas;
    }


    public List<DepartmentData> GetDepartments()
    {
        List<DepartmentData> departmentDatas = new List<DepartmentData>();
        var employees = (from e in _employee.GetAll()
                         join d in _department.GetAll() on e.DepartmentId equals d.Id
                         group e by new { d.Name, e.DepartmentId }
            into g
                         where g.Count() > 3
                         select new
                         {
                             DepartmentName = g.Key.Name,
                             TotalEmployees = g.Count(),
                             MinSalary = g.Min(e => e.Salary),
                             MaxSalary = g.Max(e => e.Salary),
                             AverageSalary = g.Average(e => e.Salary)
                         }).ToList();

        departmentDatas.AddRange(employees.Select(e => new DepartmentData
        {
            DepartmentName = e.DepartmentName,
            TotalEmployees = e.TotalEmployees,
            MinSalary = e.MinSalary,
            MaxSalary = e.MaxSalary,
            AverageSalary = e.AverageSalary
        }));

        return departmentDatas;
    }
}
