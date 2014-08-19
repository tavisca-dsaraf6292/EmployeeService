using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]
    public class EmployeeService : IAddandCreate, IRetrieve
    {
        private static List<Employee> _List = new List<Employee>();
        private int _Count;
        public string CreateEmployee(string name, string remark, DateTime today)
        {
            if (name == string.Empty || remark == string.Empty)
            {
                throw new ArgumentNullException();
            }
            else
            {
                _List.Add(new Employee() { Id = _Count, Name = name, remark = remark, date = today });
                _Count++;
                return "Record Added Successfully.";
            }
        }

        public string AddRemarksToEmployee(int id,string remark)
        {
            int index = _List.FindIndex(a => a.Id == id);
            if (index != -1)
            {
                _List[index].remark = remark;
                return "Remark Added Successfully.";
            }
            else
            {
                ExceptionFaultContract _faultcontract = new ExceptionFaultContract();
                _faultcontract.StatusCode = "Empty Database";
                _faultcontract.Message = "Requested ID is Not Present in the Database";
                _faultcontract.Description = "Error occurred in service";
                throw new FaultException<ExceptionFaultContract>(_faultcontract, new FaultReason(_faultcontract.Message));
            }
            //return "Record not Found.";
        }

        public List<Employee> GetAllEmployees()
        {
            return _List;
        }

        public string GetEmployeeDetails(int id)
        {

            int index = _List.FindIndex(a => a.Id == id);
            if (index != -1)
                return "ID:" + _List[index].Id + "\n" + "Name:" + _List[index].Name + "\n" + "Remark:" + _List[index].remark + "\n" + "Date:" + _List[index].date + "\n";
            else
            {
                ExceptionFaultContract _faultcontract = new ExceptionFaultContract();
                _faultcontract.StatusCode = "Empty Database";
                _faultcontract.Message = "Requested ID is Not Present in the Database";
                _faultcontract.Description = "Error occurred in service";
                throw new FaultException<ExceptionFaultContract>(_faultcontract, new FaultReason(_faultcontract.Message));
            }
        }
            //return "Record Not Found.";

        public string GetEmployeeDetails(string name)
        {
            int index = _List.FindIndex(a => a.Name == name);
            try
            {
                if (index != -1)
                    return "ID:" + _List[index].Id + "\n" + "Name:" + _List[index].Name + "\n" + "Remark:" + _List[index].remark + "\n" + "Date:" + _List[index].date + "\n";
                else
                    throw new Exception();
            }
            catch (Exception ex)
            {
                ExceptionFaultContract _faultcontract = new ExceptionFaultContract();
                _faultcontract.StatusCode = "Empty Database";
                _faultcontract.Message = "Requested Name is Not Present in the Database";
                _faultcontract.Description = "Error occurred in service";
                throw new FaultException<ExceptionFaultContract>(_faultcontract, new FaultReason(_faultcontract.Message));
            }
            //return "Record Not Found.";
        }
    }
}
