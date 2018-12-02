using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.OrderModel;
using DataAccessLayer.SushiModels;

namespace BusinessLogicLayer
{
    public class OrdersList
    {
        public List<Order> orders { get; set; }
        public string CookName { get; set; }
        public bool IsSubmitted { get; set; }
        public string PATH;
        public OrdersList()
        {
            orders = new List<Order>();
            IsSubmitted = false;
            PATH = Directory.GetCurrentDirectory() + @"\sushi.txt";
        }
        public OrdersList(string CookName)
        {
            this.CookName = CookName;
            orders = new List<Order>();
            IsSubmitted = false;
            PATH = Directory.GetCurrentDirectory() + @"\sushi.txt";
        }
        public void SubmitOrders()
        {
            SaveToFile();
            IsSubmitted = true;
        }
        public void MarkReady(Order order)
        {
            orders.Find(o => o.Name == order.Name).MarkReady();
        }
        public List<Order> FindAll(Predicate<Order> p)
        {
            return orders.FindAll(p);
        }
        public Order Find(Predicate<Order> p)
        {
            return orders.Find(p);
        }
        public void AddOrder(Order order)
        {
            this.orders.Add(order);
        }
        public void DeleteOrder(Order order)
        {
            this.orders.Remove(orders.Find(o => o.Name == order.Name));
        }
        public void SaveToFile()
        {
            if (orders.Count == 0)
                return;
            string str = String.Empty;
            if (File.Exists(PATH))
            {
                FileStream fs = new FileStream(PATH, FileMode.Open, FileAccess.ReadWrite);
                using (StreamReader sr = new StreamReader(fs))
                {
                    str = sr.ReadToEnd();
                    fs.Position = 0;                   
                }
                File.Delete(PATH);
            }

            using (StreamWriter streamWriter = new StreamWriter(PATH, true))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{CookName}'s orders");
                foreach (var item in orders)
                {
                    sb.AppendLine(item.ToString());
                }
                sb.AppendLine("Active orders: " + FindAll(o => o.IsTaken == true && o.IsReady == false).Count);
                sb.AppendLine();
                if (str == null)
                {
                    streamWriter.Write(sb.ToString());
                }
                else
                {
                    streamWriter.Write(sb + Environment.NewLine + str);
                }
            }
        }
    }
}
