using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SushiModels
{
    /// <summary>
    /// Class Nigiri inherited from Sushi
    /// </summary>
    public class Nigiri : Sushi
    {
        public Nigiri()
        {
            Name = "Nigiri";
            Sauce = Sauces.Nikiri;
        }
    }
}
