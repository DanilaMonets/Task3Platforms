using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SushiModels
{
    /// <summary>
    /// Class Rolls inherited from Sushi
    /// </summary>
    class Rolls : Sushi
    {
        public Rolls()
        {
            Name = "Rolls";
            Sauce = Sauces.YumYum;
        }
    }
}
