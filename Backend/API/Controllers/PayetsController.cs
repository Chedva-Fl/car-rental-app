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
    public class PayetsController:ApiController
    {
        PaymentsBL p=new PaymentsBL();
        [AcceptVerbs("Get", "Post")]

        [Route("getcustemerbyid/id")]
        [HttpGet]
        public PaymentsDTO GetCustemerById(int id)
        {
           return p.GetCustemerById(id);
        }
        //הוספה
        [Route("add")]
        [HttpGet]
        public bool Add(PaymentsDTO c)
        {
           return p.Add(c);
        }

        //עדכון
        [Route("update")]
        [HttpGet]
        public bool Update(PaymentsDTO c)
        {
            return p.Update(c);
        }

        //מחיקה
        [Route("delete")]
        [HttpGet]
        public bool Delete(PaymentsDTO c)
        {
           return p.Delete(c);
        }
        [Route("getall")]
        [HttpGet]
        public List<PaymentsDTO> GetAll()
        {
            return p.GetAll();
        }
    }
}