#region IncudedNamespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using UserManagement.Domain;
#endregion IncudedNamespaces

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {

        // GET api/values
        [HttpGet]
        public JsonResult Get()
        {
            List<User> userList = new UserManagement.BLL.UserManagementBLL().SelectAllUsers();
            return this.Json(userList, new JsonSerializerSettings());
        }


        // POST api/values
        [HttpPost]
        public bool Post([FromBody]User objUsers)
        {
            bool status = false;

            try
            {
                status = new UserManagement.BLL.UserManagementBLL().AddNewUser(objUsers.Name, objUsers.DateOfBirth);
            }
            catch (Exception ex)
            {
                status = false;
            }

            return status;
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
