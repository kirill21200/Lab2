using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BusinessLogic
{
    public class Logic
    {
        IRepository db;

        public Logic()
        {
            db = new TEXTRepository(); 
        }

        public double AllSalary()
        {
            return db.AllSalary();
        }

        public void Create(string empInfo)
        {
            String[] filds = empInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Employee employee = new Employee() { Name = filds[0], Age = int.Parse(filds[1]), Salary = double.Parse(filds[2]) };
            db.Create(employee);
        }

        public void Delete(string id)
        {
            db.Delete(int.Parse(id));
        }

        public Employee GetEmployee(string id)
        {
            return db.GetEmployee(int.Parse(id));
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return db.GetEmployees();
        }

        public Employee GetWithBiggestSalary()
        {
            return db.GetWithBiggestSalary();
        }

        public void Save()
        {
            db.Save();
        }

        public void Update(string empInfo)
        {
            String[] filds = empInfo.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Employee employee = new Employee() { Id = int.Parse(filds[0]), Name = filds[1], Age = int.Parse(filds[2]), Salary = double.Parse(filds[3]) };
            db.Update(employee);
        }
    }
}
