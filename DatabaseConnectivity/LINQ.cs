﻿namespace DatabaseConnectivity;

public class LINQ
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
}