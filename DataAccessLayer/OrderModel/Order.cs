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

        public string Shushis
        {
            get
            {
                StringBuilder str = new StringBuilder();
                foreach(var elem in this.Sushis)
                {
                    str.Append($"{elem.Name}, ");
                }
                return str.ToString();
            }
        }

        public Order()
        {
            Name = OrderName.GetName();
            Sushis = new List<Sushi>();
            IsTaken = false;
            IsReady = false;
            Time = DateTime.Now;
        }
        public Order(List<Sushi> sushis)
        {
            Name = OrderName.GetName();
            Sushis = new List<Sushi>();
            foreach (var item in sushis)
            {
                Sushis.Add(item);
            }
            IsTaken = false;
            IsReady = false;
            Time = DateTime.Now;
        }
        public void AddSushi(Sushi s)
        {
            Sushis.Add(s);
        }
        public void TakeOrder()
        {
            IsTaken = true;
        }
        public void MarkReady()
        {
            IsReady = true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Name);
            foreach (var item in Sushis)
            {
                sb.Append(item.Name + ",");
            }
            sb.AppendLine();
            sb.AppendLine(IsTaken.ToString());
            sb.AppendLine(IsReady.ToString());
            sb.AppendLine(Time.ToString("HH:mm"));
            return sb.ToString();
        }
    }
}
