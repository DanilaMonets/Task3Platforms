using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.SushiModels
{
    /// <summary>
    /// Class Cheaps inherited from Sushi
    /// </summary>
    public class Cheaps : Sushi
    {
        public Cheaps()
        {
            Name = "Cheaps";
            Sauce = Sauces.Goma;
        }
    }
}
