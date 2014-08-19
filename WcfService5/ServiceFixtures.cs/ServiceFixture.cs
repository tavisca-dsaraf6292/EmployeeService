using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using System.Diagnostics;
using ServiceFixtures.cs.EmployeeService;

namespace ServiceFixtures.cs
{
    [TestClass]
    public class ServiceFixture
    {
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException))]
        public void TestToCheckWhetherEnteredValuesShouldNotBeNull()
        {
            string name = string.Empty;
            string remark = string.Empty;
            var client = new ServiceFixtures.cs.EmployeeService.AddandCreateClient("BasicHttpBinding_IAddandCreate");
            client.CreateEmployee(name, remark, DateTime.Now);
              
        }
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException))]
        public void TestToCheckWhetherEmployeeIsAddedSuccessfully()
        {
            string name = "john$%@";
            string remark = "noble";
            var createEmployeeClient = new ServiceFixtures.cs.EmployeeService.AddandCreateClient("BasicHttpBinding_IAddandCreate");
            var result = createEmployeeClient.CreateEmployee(name,remark,DateTime.Now);
            Assert.AreEqual(result, "Record Added Successfully.");
            Debug.WriteLine(result + "\n\n");
        }
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<ExceptionFaultContract>))]
        public void TestToCheckWhetherEmployeeIdExist()
        {
            int id = 546;
            var retrieveClient = new ServiceFixtures.cs.EmployeeService.RetrieveClient("WSHttpBinding_IRetrieve");
            var result = retrieveClient.SearchById(id);
            Debug.WriteLine(result + "\n\n");
        }
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<ExceptionFaultContract>))]
        public void TestToCheckWhetherEmployeeNameExist()
        {
            string name = "kljlkl";
            var retrieveClient = new ServiceFixtures.cs.EmployeeService.RetrieveClient("WSHttpBinding_IRetrieve");
            var result = retrieveClient.SearchByName(name);
            Debug.WriteLine(result + "\n\n");
        }


        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<ExceptionFaultContract>))]
        public void TestToReturnProperMessageIfEmployeeIsNotPresentWhileAddingRemark()
        {
            int id = 78;
            var updateRemarkClient = new ServiceFixtures.cs.EmployeeService.AddandCreateClient("BasicHttpBinding_IAddandCreate");
            var result=updateRemarkClient.AddRemarksToEmployee(id, "Good Employee");
            Debug.WriteLine(result + "\n\n");
        }


        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException<ExceptionFaultContract>))]
        public void TestToCheckWhetherEmployeeNameContainsSpecialCharacters()
        {
            string name = "kljlkl";
            var retrieveClient = new ServiceFixtures.cs.EmployeeService.RetrieveClient("WSHttpBinding_IRetrieve");
            var result = retrieveClient.SearchByName(name);
            Debug.WriteLine(result + "\n\n");
        }

    }
}
