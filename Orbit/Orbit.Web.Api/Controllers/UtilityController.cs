using Com.Qualcomm.Qswat.Model.Enums;
using Orbit.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Orbit.Web.Api.Controllers
{

    public class UtilityController : BaseApiController
    {
        static readonly IList<Type> SupportedEnumType = new List<Type>()
        {
            typeof(TicketStatus),
            typeof(SeverityLevel)
        };

        [HttpGet]
        [Route("api/utility/enum/{typeName}")]
        public HttpResponseMessage Get(string typeName)
        {
            return ExecuteAction(new object[] { typeName }, args =>
            {
                var _typeName = args[0] as string;
                var pair = new List<KeyValuePair<int, string>>();

                var type = SupportedEnumType.FirstOrDefault(m => m.Name.Equals(_typeName));
                if (type != null)
                {
                    var values = Enum.GetValues(type);
                    pair.AddRange(from object val in values
                                  select new KeyValuePair<int, string>((int)val, Enum.GetName(type, val)));
                }
                return new JsonReponse() { Success = true, Data = pair };
            });
        }
    }
}
