using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.ClassesDTO
{
    public class PaymentsDTO
    {
        public int IdPay { get; set; }
        public string creditCard { get; set; }
        public string validity { get; set; }
        public int cvc { get; set; }
        public virtual ICollection<Custemers> Custemers { get; set; }
    }
}
