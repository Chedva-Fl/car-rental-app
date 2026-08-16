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
    public class CustemersBL
    {
        DBConection conn=new DBConection();
        PaymentsBL payments = new PaymentsBL();
        //קבלת לקוח ע"פ מז
        public CustemersDTO GetCustemerById(int id)
        {
            List<CustemersDTO> list = Convert(conn.GetDbSet<Custemers>());
            return list.FirstOrDefault(c=> c.Id==id);
        }
        //הוספה
        public bool Add(CustemersDTO c)
        {
            try
            {
                Custemers c1 = Convert(c);
                conn.Execute<Custemers>(c1, ExecuteActions.Insert);
                return true;
            }
            catch (Exception ex) // הוספנו את ה-ex
            {
                // כאן תשימי Breakpoint (נקודה אדומה)
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        //עדכון
        public bool Update(CustemersDTO c)
        {
            Custemers c1 = Convert(c);
            try
            {
                conn.Execute<Custemers>(c1, ExecuteActions.Update);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //מחיקה
        public bool Delete(CustemersDTO c)
        {
            Custemers c1 = Convert(c);
            try
            {
                conn.Execute<Custemers>(c1, ExecuteActions.Delete);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //קבלת הקוד הבא getNext
        //קבלת כל הרשימה
        public List<CustemersDTO> GetAll()
        {
            return Convert(conn.GetDbSet<Custemers>());
        }

        public List<CustemersDTO> GetAllSort()
        {
            List<CustemersDTO> list= Convert(conn.GetDbSet<Custemers>());
            return list.OrderBy(c=>c.firstName).ToList();
        }

        public List<CustemersDTO> GetThreeOld()
        {
            List<CustemersDTO> list = Convert(conn.GetDbSet<Custemers>());
            return list.OrderBy(c=> c.numOfLendings).Take(3).ToList();
        }

       public List<CustemersDTO> GetCustemersByCity(int city)
        {
            List<CustemersDTO> list = Convert(conn.GetDbSet<Custemers>());
            return list.FindAll(c=>c.idCity==city).ToList();
        }
        public PaymentsDTO GetPayments(int idP)
        {
            List<CustemersDTO> list = Convert(conn.GetDbSet<Custemers>());
            CustemersDTO c1 = list.FirstOrDefault(c => c.idPayment == idP);
            return payments.Convert(c1.Payments);
        }

        public CustemersDTO Convert(Custemers c)
        {
            CustemersDTO cd = new CustemersDTO();
            cd.Id = c.Id;
            cd.firstName = c.firstName;
            cd.lastName = c.lastName;
            cd.idCity=c.idCity;
            cd.email= c.email;
            cd.numOfLendings=c.numOfLendings;
            cd.idPayment=c.idPayment;
            //cd.Cities=c.Cities;
            //cd.Payments=c.PaymeDnts;
            return cd;
        }
        public Custemers Convert(CustemersDTO cd)
        {
            return new Custemers()
            {
                Id = cd.Id,
                firstName = cd.firstName,
                lastName = cd.lastName,
                idCity = cd.idCity,
                email = cd.email,
                numOfLendings = cd.numOfLendings,
                idPayment = cd.idPayment ??0,
                // אל תגעי ב-c.Cities וב-c.Payments, ה-DB יסתדר עם ה-IDs בלבד!
            };
        }
        public List<CustemersDTO> Convert(List<Custemers> list)
        {
            List<CustemersDTO> cr = new List<CustemersDTO>();
            foreach (Custemers c in list)
            {
                cr.Add(Convert(c));
            }
            return cr;
        }
        public List<Custemers> Convert(List<CustemersDTO> cr)
        {
            List<Custemers> list = new List<Custemers>();
            foreach (CustemersDTO c in cr)
            {
                list.Add(Convert(c));
            }
            return list;
        }

    }
}
