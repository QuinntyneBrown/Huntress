using System.Net;
using System.Threading.Tasks;
using Huntress.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Huntress.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThemeController
    {
        private readonly IMediator _mediator;

        public ThemeController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet("{themeId}", Name = "GetThemeByIdRoute")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetThemeById.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetThemeById.Response>> GetById([FromRoute]GetThemeById.Request request)
        {
            var response = await _mediator.Send(request);
        
            if (response.Theme == null)
            {
                return new NotFoundObjectResult(request.ThemeId);
            }
        
            return response;
        }
        
        [HttpGet(Name = "GetThemesRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetThemes.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetThemes.Response>> Get()
            => await _mediator.Send(new GetThemes.Request());
        
        [HttpPost(Name = "CreateThemeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateTheme.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateTheme.Response>> Create([FromBody]CreateTheme.Request request)
            => await _mediator.Send(request);
        
        [HttpGet("page/{pageSize}/{index}", Name = "GetThemesPageRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetThemesPage.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetThemesPage.Response>> Page([FromRoute]GetThemesPage.Request request)
            => await _mediator.Send(request);
        
        [HttpPut(Name = "UpdateThemeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateTheme.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateTheme.Response>> Update([FromBody]UpdateTheme.Request request)
            => await _mediator.Send(request);
        
        [HttpDelete("{themeId}", Name = "RemoveThemeRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveTheme.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveTheme.Response>> Remove([FromRoute]RemoveTheme.Request request)
            => await _mediator.Send(request);
        
    }
}
