using System;
using Consumer.EmployeeService;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
                string name,remark,result;
                int choice,id=0;
                var createObj = new AddandCreateClient("BasicHttpBinding_IAddandCreate");
                var retrieveObj = new RetrieveClient("WSHttpBinding_IRetrieve");  
                DateTime today = DateTime.Today;
                do
                {
                    Console.WriteLine("\n--------------------------------------------------");
                    Console.WriteLine("\n\n1.Add Employee Details.");
                    Console.WriteLine("2.Get Details Of All Employees.");
                    Console.WriteLine("3.Search Employee Details by Id.");
                    Console.WriteLine("4.Search Employee Details by Name.");
                    Console.WriteLine("5.Add Remark To An Employee.");
                    Console.WriteLine("6.Exit.");
                    Console.WriteLine("Enter your Choice:");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter Name Of Employee:");
                            name = Console.ReadLine();
                            Console.WriteLine("Enter Remark for Employee:");
                            remark = Console.ReadLine();
                            createObj.CreateEmployee(name, remark, today);
                            break;
                        case 2:
                            var returnedList = retrieveObj.GetAllEmployees();
                            for (int i = 0; i < returnedList.Length; i++)
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
                            result = retrieveObj.SearchById(id);
                            Console.WriteLine(result + "\n\n");
                            break;
                        case 4:
                            Console.WriteLine("Enter Name Of Employee:");
                            name = Console.ReadLine();
                            result = retrieveObj.SearchByName(name);
                            Console.WriteLine(result + "\n\n");
                            break;
                        case 5:
                            Console.WriteLine("Enter Id Of Employee:");
                            id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Remark For Employee:");
                            remark = Console.ReadLine();
                            result = createObj.AddRemarksToEmployee(id, remark);


                            //result = createObj.;
                            Console.WriteLine(result + "\n\n");
                            break;
                        case 6:
                            System.Environment.Exit(1);
                            break;
                        default:
                            Console.WriteLine("\n\nInvalid Choice.");
                            break;
                    }
                } while (choice != 6);
        }
    }
}
