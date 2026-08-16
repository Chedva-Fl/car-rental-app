using BL.ClassesBL;
using BL.ClassesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/cities")]
    public class CitiesController:ApiController
    {
        CitiesBL city=new CitiesBL();
        [AcceptVerbs("Get", "Post")]

        [Route("getcustemerbyid/id")]
        [HttpGet]
        public CitiesDTO GetCustemerById(int id)
        {
            return city.GetCustemerById(id);
        }
        //הוספה
        [Route("add")]
        [HttpGet]
        public bool Add(CitiesDTO c)
        {
            return city.Add(c);
        }

        //עדכון
        [Route("update")]
        [HttpGet]
        public bool Update(CitiesDTO c)
        {
            return city.Update(c);
        }

        //מחיקה
        [Route("delete")]
        [HttpGet]
        public bool Delete(CitiesDTO c)
        {
            return city.Delete(c);
        }
        //קבלת כל הרשימה
        [Route("getall")]
        [HttpGet]
        public List<CitiesDTO> GetAll()
        {
            return city.GetAll();
        }
    }
}