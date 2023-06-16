namespace DatabaseConnectivity;

public class Linq
{
    protected Region region = new Region();
    protected Country country = new Country();
    protected Location location = new Location();
    protected Employee employee = new Employee();
    protected Department department = new Department();
    protected Job job = new Job();
    protected History history = new History();

    public void GetEmployees(int limit)
    {
        var employees = (from e in employee.GetAllEmployees()
            join j in job.GetAllJobs() on e.jobId equals j.id
            join d in department.GetAllDepartments() on e.departmentId equals d.id
            join l in location.GetAllLocations() on d.locationId equals l.id
            join c in country.GetAllCountries() on l.countryId equals c.id
            join r in region.GetAllRegions() on c.regionId equals r.id
            select new {
                Id = e.id,
                FullName = $"{e.firstName} {e.lastName}",
                Email = e.email,
                Phone = e.phoneNumber,
                Salary = e.salary,
                Department_Name = d.name,
                StreetAddress = l.streetAddress,
                CountryName = c.name,
                RegionName = r.name
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
    
    /*SELECT d.name AS department_name, COUNT(e.department_id) AS total_employee, MIN(e.salary) AS min_salary, MAX(e.salary) AS max_salary, AVG(e.salary) AS average_salary
    FROM tb_m_employees e RIGHT JOIN tb_m_departments d ON e.department_id = d.id
        GROUP BY d.name, e.department_id
        HAVING COUNT(e.department_id) > 3;*/

    public void GetDepartments()
    {
        var employees = (from e in employee.GetAllEmployees()
            join d in department.GetAllDepartments() on e.departmentId equals d.id
            group e by new {d.name, e.departmentId}
            into g
            where g.Count() > 3
            select new
            {
                DepartmentName = g.Key.name,
                TotalEmployee = g.Count(),
                MinSalary = g.Min(e => e.salary),
                MaxSalary = g.Max(e => e.salary),
                AverageSalary = g.Average(e => e.salary)
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