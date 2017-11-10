using Com.Qualcomm.Qswat.Core.Utility;
using Com.Qualcomm.Qswat.Model.Common;
using Com.Qualcomm.Qswat.Service.Common;
using Orbit.Web.Api.Models;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Orbit.Web.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        // GET api/values
        public HttpResponseMessage Get()
        {
            return ExecuteAction(null, args =>
            {
                var users = _userService.QueryAll().ToList();
                return new JsonReponse() { Success = true, Data = users };
            });
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            return ExecuteAction(new object[] { id }, args =>
            {
                var _id = (int)args[0];
                var user = _userService.GetById(_id);

                return new JsonReponse() { Success = true, Data = user };
            });
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]User user)
        {
            return ExecuteAction(new object[] { user }, args =>
              {
                  var u = args[0] as User;
                  u.PasswordHash = EncryptHelper.Md5Hex(u.PasswordHash);
                  _userService.Insert(u);

                  return new JsonReponse() { Success = true, Data = u.Id };
              });
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] User user)
        {
            return ExecuteAction(new object[] { id, user }, args =>
              {
                  var _id = (int)args[0];
                  var u = args[1] as User;
                  var userFromDb = _userService.GetById(_id);
                  if (userFromDb != null)
                  {
                      userFromDb.Email = user.Email;
                      userFromDb.PasswordHash = userFromDb.PasswordHash;
                      userFromDb.FirstName = user.FirstName;
                      userFromDb.LastName = user.LastName;
                      userFromDb.Phone = user.Phone;
                      userFromDb.Address = user.Address;
                      _userService.Update(userFromDb);
                  }

                  return new JsonReponse() { Success = true, Data = _id };
              });
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            return ExecuteAction(new object[] { id }, args =>
              {
                  var _id = (int)args[0];
                  var user = _userService.GetById(_id);
                  if (user != null)
                      _userService.Delete(user);

                  return new JsonReponse() { Success = true, Data = _id };
              });
        }
    }
}
