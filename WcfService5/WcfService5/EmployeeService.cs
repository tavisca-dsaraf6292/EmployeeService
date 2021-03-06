﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService5
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IAddandCreate
    {
        [OperationContract]
        [FaultContract(typeof(ArgumentNullException))]
        string CreateEmployee(string name, string remark, DateTime today);

        [OperationContract]
        [FaultContract(typeof(ExceptionFaultContract))]
        string AddRemarksToEmployee(int id, string remark);
    }


    [ServiceContract]
    public interface IRetrieve
    {
        [OperationContract]
        List<Employee> GetAllEmployees();

        [OperationContract(Name = "SearchById")]
        [FaultContract(typeof(ExceptionFaultContract))]
        string GetEmployeeDetails(int id);

        [OperationContract(Name = "SearchByName")]
        [FaultContract(typeof(ExceptionFaultContract))]
        string GetEmployeeDetails(string name);
        // TODO: Add your service operations here
    }

    [DataContract]
    public class Employee
    {
        [DataMember] //this proprty should be exposed
        public int Id { get; set; }

        [DataMember]//this proprty should be exposed
        public string Name { get; set; }

        [DataMember] //this proprty should be exposed
        public DateTime date { get; set; }

        [DataMember]//this proprty should be exposed
        public string remark { get; set; }
    }
}