using BL.ClassesBL;
using BL.NewFolder1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/cars")]
    public class CarsController: ApiController
    {
        CarsBL ca=new CarsBL();
        [AcceptVerbs("Get", "Post")]

        [Route("getcustemerbyid/{id}")]
        [HttpGet]
        public CarsDTO GetCustemerById(int id)
        {
            return ca.GetCustemerById(id);
        }
        //הוספה
        [Route("add")]
        [HttpGet]
        public bool Add(CarsDTO c)
        {
            return ca.Add(c);
        }

        //עדכון
        [Route("update")]
        [HttpGet]
        public bool Update(CarsDTO c)
        {
           return ca.Update(c);
        }

        //מחיקה
        [Route("delete/{c}")]
        [HttpGet]
        public bool Delete(CarsDTO c)
        {
           return ca.Delete(c);
        }

        [Route("getall")]
        [HttpGet]
        public List<CarsDTO> GetAll()
        {
            return ca.GetAll();
        }
    }
}