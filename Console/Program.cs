using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer;
using DataAccessLayer.OrderModel;
using DataAccessLayer.SushiModels;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            OrdersList list = new OrdersList();
            

            list.OpenFromFile();

            foreach (var v in list.orders)
            {
                Console.WriteLine("lol");
            }

            Console.ReadKey();
        }
    }
}
