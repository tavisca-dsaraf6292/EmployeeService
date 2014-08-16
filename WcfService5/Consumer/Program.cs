using System;
using WcfService5;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
                string name,remark,result;
                int choice,id=0;
                var obj = new WcfService5.EmployeeService();  
                DateTime today = DateTime.Today;
                do
                {
                    Console.WriteLine("\n--------------------------------------------------");
                    Console.WriteLine("\n\n1.Add Employee Details.");
                    Console.WriteLine("2.Get Details Of All Employees.");
                    Console.WriteLine("3.Search Employee Details by Id.");
                    Console.WriteLine("4.Search Employee Details by Name.");
                    Console.WriteLine("5.Exit.");
                    Console.WriteLine("Enter your Choice:");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Name Of Employee:");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter Remark for Employee:");
                            remark = Console.ReadLine();
                            obj.CreateEmployee(name, remark, today);
                            break;
                        case 2:
                            var returnedList = obj.GetAllEmployees();
                            for (int i = 0; i < returnedList.Count; i++)
                            {
                                Console.WriteLine("\n\n\n");
                                Console.WriteLine("Id:" + returnedList[i].Id);
                                Console.WriteLine("Name:" + returnedList[i].Name);
                                Console.WriteLine("Date:" + returnedList[i].date);
                                Console.WriteLine("Remark:" + returnedList[i].remark + "\n\n");
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter Id Of Employee:");
                            id = Convert.ToInt32(Console.ReadLine());
                            result = obj.GetEmployeeDetails(id);
                            Console.WriteLine(result + "\n\n");
                            break;
                        case 4:
                            Console.WriteLine("Enter Name Of Employee:");
                            name = Console.ReadLine();
                            result = obj.GetEmployeeDetails(name);
                            Console.WriteLine(result + "\n\n");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice..!!!");
                            break;
                    }
                } while (choice != 5);
        }
    }
}
