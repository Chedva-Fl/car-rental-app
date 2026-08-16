using BL.ClassesBL;
using BL.ClassesDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/custemers")]
    public class CustemersController:ApiController
    {
        CustemersBL custemers=new CustemersBL();
        [AcceptVerbs("Get", "Post")]

        [Route("getcustemerbyid/id")]
        [HttpGet]
        public CustemersDTO GetCustemerById(int id)
        {
            return custemers.GetCustemerById(id);
        }
        //הוספה
        //[Route("api/custemers/add")] // כתובת מלאה ומפורשת
        [Route("add")]
        [HttpPost]
        public bool Add([FromBody] CustemersDTO c)
        {
            return custemers.Add(c);
        }

        //עדכון
        [Route("update")]
        [HttpGet]
        public bool Update(CustemersDTO c)
        {
            return custemers.Update(c);
        }

        //מחיקה
        [Route("delete")]
        [HttpGet]
        public bool Delete(CustemersDTO c)
        {
            return custemers.Delete(c);
        }

        [Route("getall")]
        [HttpGet]
        public List<CustemersDTO> GetAll()
        {
            return custemers.GetAll();
        }
    }
}