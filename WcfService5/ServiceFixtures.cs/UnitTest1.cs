using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Consumer.EmployeeService;
using System.ServiceModel;

namespace ServiceFixtures.cs
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(System.ServiceModel.FaultException))]
        //[ExpectedException(typeof(FaultException<ArgumentNullException>))]
        public void TestToCheckWhetherEnteredValuesShouldNotBeNull()
        {
            string name = string.Empty;
            string remark = string.Empty;
 
                var client = new AddandCreateClient("BasicHttpBinding_IAddandCreate");
                client.CreateEmployee(name, remark, DateTime.Now);
              
        }
        //[TestMethod]
        //[ExpectedException(typeof(System.ArgumentNullException))]
        //public void TestToCheckWhetherEmployeeExist()
        //{
            
        //}
    }
}
