using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using UserManagement.Domain;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {

        // POST api/values/AddUser
        [HttpPost]
        [Route("[action]")]
        public bool AddUser(User objUsers)
        {
            return new UserManagement.BLL.UserManagementBLL().AddNewUser(objUsers.Name, objUsers.DateOfBirth);
        }

        [HttpGet]
        [Route("[action]")]
        public JsonResult GetUsers()
        {
            List<User> userList = new UserManagement.BLL.UserManagementBLL().SelectAllUsers();
            return this.Json(userList, new JsonSerializerSettings());
        }

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            //new UserManagement.BLL.UserManagementBLL().AddNewUser("vishnu", DateTime.Now);
            List<User> userList = new UserManagement.BLL.UserManagementBLL().SelectAllUsers();
            return this.Json(userList, new JsonSerializerSettings());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User objUsers)
        {
            new UserManagement.BLL.UserManagementBLL().AddNewUser(objUsers.Name, objUsers.DateOfBirth);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
