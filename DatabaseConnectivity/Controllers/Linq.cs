using DatabaseConnectivity.Models;


namespace DatabaseConnectivity.Controllers;

public class Linq
{
    private readonly Region _region = new Region();
    private readonly Country _country = new Country();
    private readonly Location _location = new Location();
    private readonly Employee _employee = new Employee();
    private readonly Department _department = new Department();
    private readonly Job _job = new Job();

    
    public void GetEmployees(int limit)
    {
        var employees = (from e in _employee.GetAllEmployees()
            join j in _job.GetAllJobs() on e.JobId equals j.Id
            join d in _department.GetAllDepartments() on e.DepartmentId equals d.Id
            join l in _location.GetAllLocations() on d.LocationId equals l.Id
            join c in _country.GetAllCountries() on l.CountryId equals c.Id
            join r in _region.GetAllRegions() on c.RegionId equals r.Id
            select new {
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
        
        foreach (var employee in employees)
        {
            Console.WriteLine($"Id: {employee.Id}");
            Console.WriteLine($"Full Name: {employee.FullName}");
            Console.WriteLine($"Email: {employee.Email}");
            Console.WriteLine($"Phone: {employee.Phone}");
            Console.WriteLine($"Salary: {employee.Salary}");
            Console.WriteLine($"Department Name: {employee.Department_Name}");
            Console.WriteLine($"Street Address: {employee.StreetAddress}");
            Console.WriteLine($"Country Name: {employee.CountryName}");
            Console.WriteLine($"Region Name: {employee.RegionName}");
            Console.WriteLine();
        }
    }
    
    
    public void GetDepartments()
    {
        var employees = (from e in _employee.GetAllEmployees()
            join d in _department.GetAllDepartments() on e.DepartmentId equals d.Id
            group e by new {d.Name, e.DepartmentId}
            into g
            where g.Count() > 3
            select new
            {
                DepartmentName = g.Key.Name,
                TotalEmployee = g.Count(),
                MinSalary = g.Min(e => e.Salary),
                MaxSalary = g.Max(e => e.Salary),
                AverageSalary = g.Average(e => e.Salary)
            }).ToList();

        foreach (var employee in employees)
        {
            Console.WriteLine($"Department Name: {employee.DepartmentName}");
            Console.WriteLine($"Total Employee: {employee.TotalEmployee}");
            Console.WriteLine($"Min Salary: {employee.MinSalary}");
            Console.WriteLine($"Max Salary: {employee.MaxSalary}");
            Console.WriteLine($"Average Salary: {employee.AverageSalary}");
            Console.WriteLine();
        }
    }
}