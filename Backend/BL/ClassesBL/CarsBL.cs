using BL.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL.ClassesDTO;
using static DAL.DBConection;

namespace BL.ClassesBL
{
    public class CarsBL
    {
        DBConection conn = new DBConection();
        //קבלת לקוח ע"פ מז
        public CarsDTO GetCustemerById(int id)
        {
            List<CarsDTO> list = Convert(conn.GetDbSet<Cars>());
            return list.FirstOrDefault(c => c.IdCar == id);
        }
        //הוספה
        public bool Add(CarsDTO c)
        {
            Cars c1 = Convert(c);
            try
            {
                conn.Execute<Cars>(c1, ExecuteActions.Insert);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //עדכון
        public bool Update(CarsDTO c)
        {
            Cars c1 = Convert(c);
            try
            {
                conn.Execute<Cars>(c1, ExecuteActions.Update);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //מחיקה
        public bool Delete(CarsDTO c)
        {
            Cars c1 = Convert(c);
            try
            {
                conn.Execute<Cars>(c1, ExecuteActions.Delete);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //קבלת הקוד הבא getNext
        public int GetNext()
        {
            int code=conn.GetDbSet<Cars>().Count;
            return ++code;
        }
        //קבלת כל הרשימה
        public List<CarsDTO> GetAll()
        {
            return Convert(conn.GetDbSet<Cars>());
        }

        public List<CarsDTO> GetCarsByPlace(int place)
        {
            return Convert(conn.GetDbSet<Cars>()).FindAll(x=>x.numPlace==place).ToList();
        }

        public List<CarsDTO> GetCarsByLevel(int level)
        {
            return Convert(conn.GetDbSet<Cars>()).FindAll(x => x.level <= level).ToList();
        }

        public List<CarsDTO> GetCarsByPrice(int price)
        {
            return Convert(conn.GetDbSet<Cars>()).FindAll(x => x.priseDay <= price).ToList();
        }
        public List<CarsDTO> GetCarsByThree(int price,int level,int place)
        {
            return Convert(conn.GetDbSet<Cars>()).FindAll(x => x.priseDay <= price&& x.level<=level&&x.numPlace==place).ToList();
        }

        public CarsDTO Convert(Cars c)
        {
            CarsDTO cdt = new CarsDTO();
            cdt.IdCar=c.IdCar;
            cdt.numPlace = c.numPlace;
            cdt.level=c.level;
            cdt.priseDay=c.priseDay;
            cdt.priceThreeDays=c.priceThreeDays;
            return cdt;
        }
        public Cars Convert(CarsDTO cdt)
        {
            Cars c = new Cars();
            c.IdCar = cdt.IdCar;
            c.numPlace = cdt.numPlace;
            c.level = cdt.level;
            c.priseDay = cdt.priseDay;
            c.priceThreeDays = cdt.priceThreeDays;
            return c;
        }

        public List<CarsDTO> Convert(List<Cars> list)
        {
            List<CarsDTO> cr = new List<CarsDTO>();
            foreach (Cars car in list) 
            { 
                cr.Add(Convert(car));
            }
            return cr;
        }
        public List<Cars> Convert(List<CarsDTO> cr)
        {
            List<Cars> list = new List<Cars>();
            foreach (CarsDTO car in cr)
            {
                list.Add(Convert(car));
            }
            return list;
        }

    }
}
