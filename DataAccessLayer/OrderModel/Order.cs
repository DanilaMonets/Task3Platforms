using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.SushiModels;

namespace DataAccessLayer.OrderModel
{
    /// <summary>
    /// Contains all necessary data about order
    /// </summary>
    public class Order
    {
        public string Name { get; set; }
        public List<Sushi> Sushis { get; set; }
        public bool IsTaken { get; set; }
        public bool IsReady { get; set; }
        public DateTime Time { get; set; }
        public Order()
        {
            Name = OrderName.GetName();
            Sushis = new List<Sushi>();
            IsTaken = false;
            IsReady = false;
            Time = DateTime.Now;
        }
        public Order(List<Sushi> Sushis)
        {
            Name = OrderName.GetName();
            foreach (var item in Sushis)
            {
                this.Sushis.Add(item);
            }
            IsTaken = false;
            IsReady = false;
            Time = DateTime.Now;
        }
        public void TakeOrder()
        {
            IsTaken = true;
        }
    }
}
