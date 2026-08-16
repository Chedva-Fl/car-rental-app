//using DAL;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BL.ClassesDTO
//{
//    public class CustemersDTO
//    {
//        public int Id { get; set; }
//        public string firstName { get; set; }
//        public string lastName { get; set; }
//        public int idCity { get; set; }
//        public string email { get; set; }
//        public int numOfLendings { get; set; }
//        public int? idPayment { get; set; }

//        public virtual Cities? Cities { get; set; }
//        public virtual Payments Payments { get; set; }
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<Renls> Renls { get; set; }

//    }
//}
using DAL;
using System;
using System.Collections.Generic;

namespace BL.ClassesDTO
{
    public class CustemersDTO
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int idCity { get; set; }
        public string email { get; set; }
        public int numOfLendings { get; set; }

        // זה הכי חשוב! מאפשר להירשם בלי אשראי
        public int? idPayment { get; set; }

        public virtual Cities Cities { get; set; }
        public virtual Payments Payments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renls> Renls { get; set; }
    }
}
