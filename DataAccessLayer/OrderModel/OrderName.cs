using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.OrderModel
{
    public static class OrderName
    {
        public static int counter;
        static OrderName()
        {
            counter = 0;
        }
        public static string GetName()
        {
            return $"Order {counter++}";
        }
    }
}
