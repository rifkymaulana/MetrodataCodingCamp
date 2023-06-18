namespace DatabaseConnectivity.Models;


public class EmployeeData
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public int? Salary { get; set; }
    public string DepartmentName { get; set; }
    public string StreetAddress { get; set; }
    public string CountryName { get; set; }
    public string RegionName { get; set; }
}
