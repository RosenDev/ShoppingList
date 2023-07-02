using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ApiControllerBase : ControllerBase
    {

    }
}
