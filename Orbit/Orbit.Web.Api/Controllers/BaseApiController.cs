using Orbit.Web.Api.Models;
using System;
using System.Net.Http;
using System.Web.Http;
using Com.Qualcomm.Qswat.Core.Extension;

namespace Orbit.Web.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        //Put base operation here:  such as Log, Exception handler

        protected HttpResponseMessage ExecuteAction(object[] args, Func<object[], JsonReponse> callback)
        {
            var response = new JsonReponse { Success = false };
            try
            {
                return Request.CreateResponse(callback(args));
            }
            catch (Exception ex)
            {
                response.Data = ex.ToJson();
            }

            return Request.CreateResponse(response);
        }
    }
}
