using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.ClassesDTO;
using BL.NewFolder1;
using DAL;
using static DAL.DBConection;

namespace BL.ClassesBL
{
    public class PaymentsBL
    {
        DBConection conn = new DBConection();
        //קבלת לקוח ע"פ מז
        public PaymentsDTO GetCustemerById(int id)
        {
            List<PaymentsDTO> list = Convert(conn.GetDbSet<Payments>());
            return list.FirstOrDefault(c => c.IdPay == id);
        }
        //הוספה
        public bool Add(PaymentsDTO c)
        {
            Payments c1 = Convert(c);
            try
            {
                conn.Execute<Payments>(c1, ExecuteActions.Insert);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //עדכון
        public bool Update(PaymentsDTO c)
        {
            Payments c1 = Convert(c);
            try
            {
                conn.Execute<Payments>(c1, ExecuteActions.Update);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //מחיקה
        public bool Delete(PaymentsDTO c)
        {
            Payments c1 = Convert(c);
            try
            {
                conn.Execute<Payments>(c1, ExecuteActions.Delete);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //קבלת כל הרשימה
        public List<PaymentsDTO> GetAll()
        {
            return Convert(conn.GetDbSet<Payments>());
        }
        public PaymentsDTO Convert(Payments p)
        {
            PaymentsDTO paydto= new PaymentsDTO();
            paydto.IdPay=p.IdPay;
            paydto.creditCard=p.creditCard;
            paydto.validity=p.validity;
            paydto.cvc=p.cvc;
            return paydto;
        }
        public Payments Convert(PaymentsDTO paydto)
        {
            Payments p = new Payments();
            p.IdPay = paydto.IdPay;
            p.creditCard = paydto.creditCard;
            p.validity = paydto.validity;
            p.cvc = paydto.cvc;
            return p;
        }
        public List<PaymentsDTO> Convert(List<Payments> list)
        {
            List<PaymentsDTO> pr = new List<PaymentsDTO>();
            foreach (Payments p in list)
            {
                pr.Add(Convert(p));
            }
            return pr;
        }
        public List<Payments> Convert(List<PaymentsDTO> pr)
        {
            List<Payments> list = new List<Payments>();
            foreach (PaymentsDTO p in pr)
            {
                list.Add(Convert(p));
            }
            return list;
        }
    }
}
