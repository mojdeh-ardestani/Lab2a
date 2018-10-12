
using Lab1A.Data;
using Lab1A.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        private static DealershipMgr dealershipMrg = null;

        [ClassInitialize]
        public static void Initialize(TestContext tc)
        {
            dealershipMrg = new DealershipMgr();
        }
        //Testing Get method for user with id = 4 ND ID =5
        [TestMethod]
        public void TestGetMethod1()
        {
            Dealership dealership = new Dealership();


             var result =  dealershipMrg.GetOneDealer(4);
             Assert.AreEqual("289-555-5555", result.PhoneNumber);

             var result1 = dealershipMrg.GetOneDealer(5);
             Assert.AreEqual("Jack", result1.Name);

            Dealership dealer = new Dealership { ID = 20, Name = "Rose", Email = "rose.sth@yahoo.com", PhoneNumber = "222-2222222"};
            dealershipMrg.Post(dealer);
            var result3 = dealershipMrg.GetOneDealer(20);
            Assert.AreEqual("Rose", result3.Name);



        } 
    }

}
