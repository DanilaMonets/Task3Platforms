using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SushiModels
{
    /// <summary>
    /// Class Maki inherited from Sushi
    /// </summary>
    public class Maki : Sushi
    {
        public Maki()
        {
            Name = "Maki";
            Sauce = Sauces.MisoMayo;
        }
    }
}
