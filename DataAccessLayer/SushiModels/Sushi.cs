using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SushiModels
{
    /// <summary>
    /// Class Sushi is based class for others
    /// </summary>
    public class Sushi
    {
        public string Name { get; protected set; }
        public Sauces Sauce { get; protected set; }
    }
}
