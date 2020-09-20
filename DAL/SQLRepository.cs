using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SQLRepository : IRepository
    {
        EmployeeContext _db;
        public SQLRepository()
        {
            this._db = new EmployeeContext();
        }
        public double AllSalary()
        {
            var allSalary = _db.Employees.Select(s => s.Salary).ToArray().Sum();
            return allSalary;
        }

        public void Create(Employee item)
        {
            _db.Employees.Add(item);
        }

        public void Delete(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
            }
        }

        public Employee GetEmployee(int id)
        {
            return _db.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _db.Employees;
        }

        public Employee GetWithBiggestSalary()
        {
            return _db.Employees.OrderByDescending(s => s.Salary).FirstOrDefault();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Employee item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
