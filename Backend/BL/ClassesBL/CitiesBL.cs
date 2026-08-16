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
    public class CitiesBL
    {
        DBConection conn = new DBConection();
        //קבלת לקוח ע"פ מז
        public CitiesDTO GetCustemerById(int id)
        {
            List<CitiesDTO> list = Convert(conn.GetDbSet<Cities>());
            return list.FirstOrDefault(c => c.codeCity == id);
        }
        //הוספה
        public bool Add(CitiesDTO c)
        {
            Cities c1 = Convert(c);
            try
            {
                conn.Execute<Cities>(c1, ExecuteActions.Insert);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //עדכון
        public bool Update(CitiesDTO c)
        {
            Cities c1 = Convert(c);
            try
            {
                conn.Execute<Cities>(c1, ExecuteActions.Update);
                return true;
            }
            catch
            {
                return false;
            }
        }

        //מחיקה
        public bool Delete(CitiesDTO c)
        {
            Cities c1 = Convert(c);
            try
            {
                conn.Execute<Cities>(c1, ExecuteActions.Delete);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //קבלת כל הרשימה
        public List<CitiesDTO> GetAll()
        {
            return Convert(conn.GetDbSet<Cities>());
        }


        public CitiesDTO Convert(Cities city)
        {
            CitiesDTO cities = new CitiesDTO();
            cities.codeCity= city.codeCity;
            cities.nameCity= city.nameCity;
            return cities;
        }
        public Cities Convert(CitiesDTO cities)
        {
            Cities city = new Cities();
            city.codeCity = cities.codeCity;
            city.nameCity = cities.nameCity;
            return city;
        }
        public List<CitiesDTO> Convert(List<Cities> list)
        {
            List<CitiesDTO> lsdt = new List<CitiesDTO>();
            foreach (Cities ci in list)
            {
                lsdt.Add(Convert(ci));
            }
            return lsdt;
        }
        public List<Cities> Convert(List<CitiesDTO> lsdt)
        {
            List<Cities> list = new List<Cities>();
            foreach (CitiesDTO city in lsdt)
            {
                list.Add(Convert(city));
            }
            return list;
        }
    }
}
