using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.NewFolder1
{
    public class CarsDTO
    {
        public int IdCar { get; set; }
        public int numPlace { get; set; }
        public int level { get; set; }
        public int priseDay { get; set; }
        public int priceThreeDays { get; set; }

        public virtual ICollection<Renls> Renls { get; set; }
    }
}
