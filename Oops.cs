using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS
{
    // Step 1: Base Employee class
    public class Employee
    {
        public int EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
    }

    // Step 2: Generic Interface IEmployee
    public interface IEmployee<T> where T : Employee
    {
        string PrintEmployeeDetails(T employee);
    }

    // Step 3: Interface for Full Time Employee
    public interface IFullTimeEmployee : IEmployee<Employee>
    {
        double Basic { get; set; }
        double Hra { get; set; }
        double Da { get; set; }
        double NetSalary { get; set; }

        double CalculateSalary();
    }

    // Step 4: Interface for Part Time Employee
    public interface IPartTimeEmployee : IEmployee<Employee>
    {
        double Basic { get; set; }
        double Da { get; set; }
        double NetSalary { get; set; }

        double CalculateSalary();
    }

    // Step 5: FullTimeEmployee Class
    public class FullTimeEmployee : Employee, IFullTimeEmployee
    {
        public double Basic { get; set; }
        public double Hra { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Hra = Basic * 0.15;
            Da = Basic * 0.10;
            NetSalary = Basic + Hra + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee employee)
        {
            return $"Full Time Employee Details:\n" +
                   $"Code: {employee.EmpCode}, Name: {employee.EmpName}, Email: {employee.Email}, " +
                   $"Dept: {employee.DeptName}, Location: {employee.Location}, Net Salary: {NetSalary:C}";
        }
    }

    // Step 6: PartTimeEmployee Class
    public class PartTimeEmployee : Employee, IPartTimeEmployee
    {
        public double Basic { get; set; }
        public double Da { get; set; }
        public double NetSalary { get; set; }

        public double CalculateSalary()
        {
            Da = Basic * 0.05;
            NetSalary = Basic + Da;
            return NetSalary;
        }

        public string PrintEmployeeDetails(Employee employee)
        {
            return $"Part Time Employee Details:\n" +
                   $"Code: {employee.EmpCode}, Name: {employee.EmpName}, Email: {employee.Email}, " +
                   $"Dept: {employee.DeptName}, Location: {employee.Location}, Net Salary: {NetSalary:C}";
        }
    }

    // Step 7: Program Class with Main Method
    class Program
    {
        static void Main(string[] args)
        {
            // a. Employee base object (optional demonstration)
            Employee baseEmployee = new Employee
            {
                EmpCode = 1001,
                EmpName = "Generic Employee",
                Email = "employee@abc.com",
                DeptName = "General",
                Location = "Hyderabad"
            };

            // b. Part Time Employee
            PartTimeEmployee pte = new PartTimeEmployee
            {
                EmpCode = 2001,
                EmpName = "John Doe",
                Email = "john.doe@abc.com",
                DeptName = "Support",
                Location = "Mumbai",
                Basic = 15000
            };
            pte.CalculateSalary();
            Console.WriteLine(pte.PrintEmployeeDetails(pte));

            Console.WriteLine();

            // c. Full Time Employee
            FullTimeEmployee fte = new FullTimeEmployee
            {
                EmpCode = 3001,
                EmpName = "Jane Smith",
                Email = "jane.smith@abc.com",
                DeptName = "Development",
                Location = "Bangalore",
                Basic = 50000
            };
            fte.CalculateSalary();
            Console.WriteLine(fte.PrintEmployeeDetails(fte));

            Console.ReadKey();
        }
    }
}
