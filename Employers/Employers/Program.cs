using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }

        public Employee(string dataLine)
        {
            var parts = dataLine.Split(',');
            Id = int.Parse(parts[0]);
            Name = parts[1];
            Age = int.Parse(parts[2]);
            Salary = int.Parse(parts[3]);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>();

            using (var reader = new StreamReader("employee_data_100_lines.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    employees.Add(new Employee(line));
                }
            }

            Console.WriteLine("3. Task");
            Console.WriteLine("All employee names:");
            foreach (var emp in employees)
            {
                Console.WriteLine(emp.Name);
            }

            Console.WriteLine("\n4. Task");
            var highestSalary = employees.Max(e => e.Salary);
            var topEarners = employees.Where(e => e.Salary == highestSalary);

            foreach (var emp in topEarners)
            {
                Console.WriteLine($"{emp.Id} {emp.Name}");
            }

            Console.WriteLine("\n5. Task");
            var nearRetirement = employees.Where(e => 65 - e.Age <= 10);

            foreach (var emp in nearRetirement)
            {
                Console.WriteLine($"{emp.Name} {emp.Age}");
            }

            Console.WriteLine("\n6. Task");
            var highEarnersCount = employees.Count(e => e.Salary > 50000);
            Console.WriteLine(highEarnersCount);
        }
    }
}