using System;
using System.Collections.Generic;
using Models;

namespace DAL
{
    public interface IRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int id);
        void Create(Employee item);
        void Update(Employee item);
        void Delete(int id);
        Employee GetWithBiggestSalary();
        double AllSalary();
        void Save();
    }
}
