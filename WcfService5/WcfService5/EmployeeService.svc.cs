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
    public class EmployeeService : IAddandCreate,IRetrieve
    {
        private List<Employee> _List = new List<Employee>();
        private int _Count;
        public void CreateEmployee(string name,string remark,DateTime today)
        {
            _List.Add(new Employee() { Id = _Count, Name =name,remark=remark,date=today});
            _Count++; 
        }

        public void AddRemarksToEmployee()
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            return _List;
            //throw new NotImplementedException();
        }

        public string GetEmployeeDetails(int id)
        {
            //var objToBeReturned = new Employee();
            int index =_List.FindIndex(a=>a.Id==id);
            if(index!=-1)
                return "ID:"+_List[index].Id+"\n"+"Name:"+_List[index].Name+"\n"+"Remark:"+_List[index].remark+"\n"+"Date:"+_List[index].date+"\n";
            return "Record Not Found..!!!";
        }

        public string GetEmployeeDetails(string name)
        {
            int index = _List.FindIndex(a => a.Name == name);
            if (index != -1)
                return "ID:" + _List[index].Id + "\n" + "Name:" + _List[index].Name + "\n" + "Remark:" + _List[index].remark + "\n" + "Date:" + _List[index].date + "\n"; return "Record Not Found..!!!";
        }
    }
}
