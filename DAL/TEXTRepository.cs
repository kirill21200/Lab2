using Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TEXTRepository : IRepository
    {
        string path = @"C:\Users\user\Desktop\Arch_Lab2\Arch_Lab2\bin\Debug\repo.txt.txt";
        List<Employee> bufer { get; set; } = new List<Employee>();
        public TEXTRepository()
        {
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] filds = line.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    bufer.Add(new Employee() {Id = int.Parse(filds[0]), Name =filds[1], Age = int.Parse(filds[2]), Salary = double.Parse(filds[3])});
                }
            }
        }
        public double AllSalary()
        {
            var allSalary = bufer.Select(s => s.Salary).ToArray().Sum();
            return allSalary;
        }

        public void Create(Employee item)
        {
            if (bufer.Count == 0)
            {
                Employee employee = item;
                employee.Id = 1;
                bufer.Add(item);
            }
            else
            {
                Employee employee = item;
                employee.Id = bufer[bufer.Count].Id;
                bufer.Add(item);
            }
        }

        public void Delete(int id)
        {
            Employee employee = bufer.FirstOrDefault(e => e.Id == id);
            bufer.Remove(employee);
        }

        public Employee GetEmployee(int id)
        {
            Employee employee = bufer.FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return bufer;
        }

        public Employee GetWithBiggestSalary()
        {
            return bufer.OrderByDescending(s => s.Salary).FirstOrDefault();
        }

        public void Save()
        {
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                foreach (Employee employee in bufer)
                {
                    sw.WriteLine($"{employee.Id},{employee.Name},{employee.Age},{employee.Salary}");
                }
            }
        }

        public void Update(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
