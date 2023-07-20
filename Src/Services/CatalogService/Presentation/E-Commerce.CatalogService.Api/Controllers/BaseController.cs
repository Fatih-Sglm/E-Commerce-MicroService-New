using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {

        protected readonly IMediator _mediator;
        public BaseController()
        {
            _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
        }

    }
}
