using Microsoft.AspNetCore.Mvc;
using ShoppingList.Data.Domain;
using ShoppingList.Model;

namespace ShoppingList.Controllers
{
    public class UsersController : ApiControllerBase<User, UserModel>
    {

        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUserAsync()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserModel userModel)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserInfo(int id, [FromBody] UserModel userModel)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok();
        }
    }
}
