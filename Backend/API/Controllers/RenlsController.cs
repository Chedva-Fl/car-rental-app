using BL.ClassesBL;
using BL.ClassesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/payments")]
    public class RenlsController:ApiController
    {
        RenlsBL r=new RenlsBL();
        [AcceptVerbs("Get", "Post")]

        [Route("getcustemerbyid/id")]
        [HttpGet]
        public RenlsDTO GetCustemerById(int id)
        {
           return r.GetCustemerById(id);
        }
        [Route("add")]
        [HttpGet]
        public bool Add(RenlsDTO c)
        {
            return r.Add(c);
        }

        //עדכון
        [Route("update")]
        [HttpGet]
        public bool Update(RenlsDTO c)
        {
           return r.Update(c);
        }

        //מחיקה
        [Route("delete")]
        [HttpGet]
        public bool Delete(RenlsDTO c)
        {
           return r.Delete(c);
        }
        [Route("getall")]
        [HttpGet]
        public List<RenlsDTO> GetAll()
        {
            return r.GetAll();  
        }
    }
}