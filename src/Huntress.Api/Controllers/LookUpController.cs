using Huntress.Api.Features;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace Huntress.Api.Controllers
{
    public class NameValueDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class LookUpController
    {

        [HttpGet("content-names", Name = "GetContentNamesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetOrders.Response), (int)HttpStatusCode.OK)]
        public ActionResult<List<NameValueDto>> Get()
        {
            return new List<NameValueDto>()
            {
                new NameValueDto
                {
                    Name = "Landing",
                    Value = "landing"
                },
                new NameValueDto
                {
                    Name = "Shell",
                    Value = "shell"
                }
            };
        }


    }
}
