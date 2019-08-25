using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService;

        public UserController()
        {
            this.userService = new UserService();
        }

        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return Ok(this.userService.GetUsers());
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(long id)
        {
            return Ok(this.userService.GetUserBySymbolNumber(id));
        }

        // POST api/user
        [HttpPost]
        public ActionResult<bool> Post([FromBody] User user)
        {
            return Ok(this.userService.AddUser(user));
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(long id, [FromBody] User user)
        {
            return Ok(this.userService.UpdateUser(user));
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(long symbolNumber)
        {
            return Ok(this.userService.DeleteUser(symbolNumber));
        }
    }
}
