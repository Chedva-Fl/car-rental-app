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
    public class RenlsBL
    {
        DBConection conn = new DBConection();
        CarsBL c=new CarsBL();
        //קבלת לקוח ע"פ מז
        public RenlsDTO GetCustemerById(int id)
        {
            List<RenlsDTO> list = Convert(conn.GetDbSet<Renls>());
            return list.FirstOrDefault(c => c.codeR == id);
        }
        //הוספה
        public bool Add(RenlsDTO c)
        {
            Renls c1 = Convert(c);
            try
            {
                conn.Execute<Renls>(c1, ExecuteActions.Insert);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //עדכון
        public bool Update(RenlsDTO c)
        {
            Renls c1 = Convert(c);
            try
            {
                conn.Execute<Renls>(c1, ExecuteActions.Update);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //מחיקה
        public bool Delete(RenlsDTO c)
        {
            Renls c1 = Convert(c);
            try
            {
                conn.Execute<Renls>(c1, ExecuteActions.Delete);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //קבלת כל הרשימה
        public List<RenlsDTO> GetAll()
        {
            return Convert(conn.GetDbSet<Renls>());
        }

        public List<RenlsDTO> GetLastWeek()
        {
            DateTime dateTime = DateTime.Now;
            return Convert(conn.GetDbSet<Renls>()).FindAll(r => r.startDate.Date >= dateTime.AddDays(-7).Date && r.startDate <= dateTime).ToList();
        }
        public List<RenlsDTO> GetLastMonth()
        {
            DateTime dateTime = DateTime.Now;
            return Convert(conn.GetDbSet<Renls>()).FindAll(r => r.startDate.Date >= dateTime.AddDays(-28).Date &&r.startDate<=dateTime).ToList();
        }
        public List<RenlsDTO> GetDay()
        {
            DateTime dateTime = DateTime.Now;
            return Convert(conn.GetDbSet<Renls>()).FindAll(r => r.startDate.Date == dateTime.Date).ToList();
        }

        public List<RenlsDTO> GetStartDate(DateTime dateTime)
        {
            return Convert(conn.GetDbSet<Renls>()).FindAll(r => r.startDate.Date == dateTime.Date).ToList();
        }
        //public List<CarsDTO> GetEndDate(DateTime dateTime)
        //{
        //    List<RenlsDTO>list= Convert(conn.GetDbSet<Renls>());
        //    RenlsDTO ret=list.FirstOrDefault(r => r.endDate.Date == dateTime.Date);
        //    return c.Convert(ret.Cars);
        //}
        //קבלת כל השכרות ממוינות ע"פ תאריך התחלה
        public List<RenlsDTO> GetSortByDate()
        {
            return Convert(conn.GetDbSet<Renls>()).OrderBy(x=>x.startDate).ToList();
        }




        public RenlsDTO Convert(Renls r)
        {
            RenlsDTO reldt = new RenlsDTO();
            reldt.codeR = r.codeR;
            reldt.idCustemers = r.idCustemers;
            reldt.idCars = r.idCars;
            reldt.startDate = r.startDate;
            reldt.endDate = r.endDate;
            reldt.goalRenl=r.goalRenl;
            reldt.Cars = r.Cars;
            reldt.Custemers=r.Custemers;
            return reldt;
        }
        public Renls Convert(RenlsDTO reldt)
        {
            Renls r = new Renls();
            r.codeR = reldt.codeR;
            r.idCustemers = reldt.idCustemers;
            r.idCars = reldt.idCars;
            r.startDate = reldt.startDate;
            r.endDate = reldt.endDate;
            r.goalRenl = reldt.goalRenl;
            r.Cars = reldt.Cars;
            r.Custemers = reldt.Custemers;
            return r;
        }
        public List<RenlsDTO> Convert(List<Renls> list)
        {
            List<RenlsDTO> re = new List<RenlsDTO>();
            foreach (Renls r in list)
            {
                re.Add(Convert(r));
            }
            return re;
        }
        public List<Renls> Convert(List<RenlsDTO> re)
        {
            List<Renls> list = new List<Renls>();
            foreach (RenlsDTO r in re)
            {
                list.Add(Convert(r));
            }
            return list;
        }

    }
}
