using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SushiModels
{
    /// <summary>
    /// Class Sashimi inherited from Sushi
    /// </summary>
    public class Sashimi : Sushi
    {
        public Sashimi()
        {
            Name = "Sashimi";
            Sauce = Sauces.Ponzu;
        }
    }
}
