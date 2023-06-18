namespace DatabaseConnectivity.Models;


public class DepartmentData
{
    public string DepartmentName { get; set; }
    public int TotalEmployees { get; set; }
    public int? MinSalary { get; set; }
    public int? MaxSalary { get; set; }
    public double? AverageSalary { get; set; }
}
