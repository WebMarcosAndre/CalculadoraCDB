using Investment.API.Models;
using Investment.Domain.Interface;
using System.Net;
using System.Web.Http;

namespace Investment.API.Controllers
{
    public class CalculateCDBController : ApiController
    {
        private ICalculateCDBService _calculateCDBService;

        public CalculateCDBController(ICalculateCDBService calculateCDBService)
        {
            _calculateCDBService = calculateCDBService;
        }

        [Route("run-calculate-cdb")]
        public IHttpActionResult Post([FromBody] CalculateCDBRequest request)
        {
            try
            {
                var calculatedInvestment = _calculateCDBService.CalculateInvestment((CalculateCDBInput)request);

                return Ok(new CalculateCDBResponse(calculatedInvestment));
            }
            catch (System.InvalidOperationException ex)
            {
                //throw new HttpResponseException(
                //     Request.CreateErrorResponse(
                //         (HttpStatusCode)422,
                //         ex.Message));

                return Content((HttpStatusCode)422, ex.Message);

            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
