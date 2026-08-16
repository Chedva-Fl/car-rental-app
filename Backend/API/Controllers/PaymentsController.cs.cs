using System;
using System.Web.Http;
using BL.ClassesBL;
using BL.ClassesDTO;

namespace WebApi.Controllers
{
    [RoutePrefix("api/payments")]
    public class PaymentsController : ApiController
    {
        PaymentsBL pbl = new PaymentsBL();

        [HttpPost]
        [Route("add/{customerId}")] 
        public IHttpActionResult Add([FromBody] PaymentsDTO p, int customerId)
        {
            if (p == null) return BadRequest("נתוני תשלום ריקים");

            bool result = pbl.Add(p, customerId);

            if (result) return Ok(true);
            return InternalServerError();
        }
    }
}