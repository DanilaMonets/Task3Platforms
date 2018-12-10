using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogicLayer;
using DataAccessLayer.OrderModel;
using DataAccessLayer.SushiModels;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddMethod()
        {
            OrdersList ol = new OrdersList();
            ol.AddOrder(new Order());
            Assert.AreEqual(ol.orders.Count, 1);
        }
        [TestMethod]
        public void TestDeleteMethod()
        {
            OrdersList ol = new OrdersList();
            Order o = new Order();
            ol.AddOrder(o);
            ol.DeleteOrder(o);
            Assert.AreEqual(ol.orders.Count, 0);
        }
        [TestMethod]
        public void TestFindMethod()
        {
            OrdersList ol = new OrdersList();
            Order o = new Order();
            ol.AddOrder(o);
            Assert.AreEqual(ol.Find(or => or == o), o);
        }
    }
}
