using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ClassesDTO
{
    public class RenlsDTO
    {
        public int codeR { get; set; }
        public int idCustemers { get; set; }
        public int idCars { get; set; }
        public System.DateTime startDate { get; set; }
        public System.DateTime endDate { get; set; }
        public string goalRenl { get; set; }
        public virtual Cars Cars { get; set; }
        public virtual Custemers Custemers { get; set; }
    }
}
  