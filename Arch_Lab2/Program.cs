using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Models;

namespace Arch_Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            while(true)
            {
                Console.WriteLine("Доступные комады: \n1 - Create; \n2 - GetEmployees; \n3 - Save; \n4 - Delate; \n5 - Update; \n6 - GetOneEmp; \n7 - GetWithBiggestSalary; \n8 - AllSalary ");
                Console.WriteLine();
                var input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        {
                            Console.WriteLine("Данные работника через запятую");
                            var empInfo = Console.ReadLine();
                            logic.Create(empInfo);
                            Console.WriteLine("ok");
                            break;
                        }
                    case "2":
                        {
                            foreach(Employee employee in logic.GetEmployees())
                            {
                                Console.WriteLine($"{employee.Id} {employee.Name} {employee.Age} {employee.Salary}");
                            }
                            Console.WriteLine("ok");
                            break;
                            
                        }
                    case "3":
                        {
                            logic.Save();
                            Console.WriteLine("ok");
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Enter id");
                            string id = Console.ReadLine();
                            logic.Delete(id);
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Enter employee info");
                            var empInfo = Console.ReadLine();
                            logic.Update(empInfo);
                            Console.WriteLine("ok");
                            break;
                        }
                    case "6":
                        {
                            Console.WriteLine("Enter id");
                            string id = Console.ReadLine();
                            Employee employee = logic.GetEmployee(id);
                            Console.WriteLine($"{employee.Id} {employee.Name} {employee.Age} {employee.Salary}");
                            Console.WriteLine("ok");
                            break;
                        }
                    case "7":
                        {
                            Employee employee = logic.GetWithBiggestSalary();
                            Console.WriteLine($"{employee.Id} {employee.Name} {employee.Age} {employee.Salary}");
                            break;
                        }
                    case "8":
                        {
                            double salary = logic.AllSalary();
                            Console.WriteLine(salary);
                            Console.WriteLine("ok");
                            break;
                        }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
