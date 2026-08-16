using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ClassesDTO
{
    public class CitiesDTO
    {
        public int codeCity { get; set; }
        public string nameCity { get; set; }

        public virtual ICollection<Custemers> Custemers { get; set; }

    }
}
