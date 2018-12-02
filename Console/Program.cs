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
            OrdersList list = new OrdersList("Adam Jones");
            List<Sushi> sushi = new List<Sushi>();
            sushi.Add(new Rolls());
            sushi.Add(new Sashimi());
            sushi.Add(new Uramaki());

            list.AddOrder(new DataAccessLayer.OrderModel.Order(sushi));

            List<Sushi> Nesushi = new List<Sushi>();
            Nesushi.Add(new Rolls());
            Nesushi.Add(new Sashimi());
            Nesushi.Add(new Uramaki());

            list.AddOrder(new DataAccessLayer.OrderModel.Order(Nesushi));

            list.SaveToFile();
        }
    }
}
