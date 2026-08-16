using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class RenlsService
    {
        public static List<object> GetHistoryByUserId(int userId)
        {
            try
            {
                using (var db = new CarsDBEntities())
                {
                    // מחזיר רשימה כללית כדי למנוע CS1061
                    return db.Renls.Where(x => x.idCustemers == userId)
                                 .ToList()
                                 .Cast<object>()
                                 .ToList();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("DAL Error: " + ex.Message);
                return new List<object>();
            }
        }
    }
}