using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Spending.Api.Controllers.Base
{
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public class BaseAuthController : ControllerBase
    {
    }
}