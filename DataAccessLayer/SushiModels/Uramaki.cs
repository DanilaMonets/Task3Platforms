using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SushiModels
{
    /// <summary>
    /// Class Uramaki inherited from Sushi
    /// </summary>
    public class Uramaki : Sushi
    {
        public Uramaki()
        {
            Name = "Uramaki";
            Sauce = Sauces.SpicyMayo;
        }
    }
}
