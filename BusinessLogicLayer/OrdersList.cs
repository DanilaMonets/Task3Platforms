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
            IsSubmitted = true;
            foreach (var o in orders)
            {
                o.TakeOrder();
            }
            SaveToFile();
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
            File.Delete(this.PATH);
            if (orders.Count == 0)
                return;
            string str = String.Empty;
            FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (StreamWriter streamWriter = new StreamWriter(fs))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{CookName}'s orders");
                foreach (var item in orders)
                {
                    sb.AppendLine(item.ToString());
                }
                sb.AppendLine("Active orders: " + FindAll(o => o.IsTaken == true && o.IsReady == false).Count);
                streamWriter.Write(sb.ToString());
            }
        }
        public void OpenFromFile()
        {
            if (File.Exists(PATH))
            {
                FileStream fs = new FileStream(PATH, FileMode.Open, FileAccess.ReadWrite);
                using (StreamReader sr = new StreamReader(fs))
                {
                    Order orderBuffer = new Order();
                    string str = String.Empty;
                    string[] arr;
                    str = sr.ReadToEnd();

                    char[] separatist = { '\n' };
                    arr = str.Split(separatist, StringSplitOptions.RemoveEmptyEntries);

                    string stringBuffer = arr[0].Split('\'')[0];
                    CookName = stringBuffer;

                    for (int i = 0, nameIndex = 1; i < (arr.Length - 2) / 6; ++i, nameIndex += 6)
                    {
                        Order order = new Order();
                        order.Name = arr[nameIndex];

                        char[] separator = { ',' };
                        string[] sushiArr = arr[nameIndex + 1].Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < sushiArr.Length - 1; ++j)
                        {
                            switch (sushiArr[j])
                            {
                                case "Nigiri":
                                    order.AddSushi(new Nigiri());
                                    break;
                                case "Maki":
                                    order.AddSushi(new Maki());
                                    break;
                                case "Uramaki":
                                    order.AddSushi(new Uramaki());
                                    break;
                                case "Sashimi":
                                    order.AddSushi(new Sashimi());
                                    break;
                                case "Cheaps":
                                    order.AddSushi(new Cheaps());
                                    break;
                                case "Rolls":
                                    order.AddSushi(new Rolls());
                                    break;
                            }
                        }
                        switch (arr[nameIndex + 2])
                        {
                            case "True\r":
                                order.IsTaken = true;
                                break;
                            case "False\r":
                                order.IsTaken = false;
                                break;
                        }
                        switch (arr[nameIndex + 3])
                        {
                            case "True\r":
                                order.IsReady = true;
                                break;
                            case "False\r":
                                order.IsReady = false;
                                break;
                        }
                        order.Time = DateTime.Parse(arr[nameIndex + 4]);
                        orders.Add(order);
                    }
                }
            }
        }
    }
}
