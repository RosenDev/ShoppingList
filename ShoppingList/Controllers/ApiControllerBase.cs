using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using ShoppingList.Common;

namespace ShoppingList.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [RequiredScope(AuthScopes.AccessAsUser)]
    public class ApiControllerBase : ControllerBase
    {

    }
}
