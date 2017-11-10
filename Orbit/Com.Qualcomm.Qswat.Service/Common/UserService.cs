using Com.Qualcomm.Qswat.Core.Exception;
using Com.Qualcomm.Qswat.Core.Interface;
using Com.Qualcomm.Qswat.Core.Utility;
using Com.Qualcomm.Qswat.Model.Common;
using System;
using System.Linq;

namespace Com.Qualcomm.Qswat.Service.Common
{
    public class UserService : GenericBusinessServices<User>, IUserService
    {
        public UserService(IRepository<User> repository) : base(repository)
        {
        }

        public User GetByEmail(string email)
        {
            return
                Repository.Table.FirstOrDefault(m => m.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase));

        }

        public bool Login(string userName, string password)
        {
            var passwordHash = EncryptHelper.Md5Hex(password);
            var user =
                Repository.Table.FirstOrDefault(
                    m =>
                        m.Email.Equals(userName, StringComparison.CurrentCultureIgnoreCase) &&
                        m.PasswordHash.Equals(passwordHash, StringComparison.CurrentCulture));

            return user != null;
        }

        public bool Register(User user)
        {
            if (GetByEmail(user.Email) != null)
            {
                throw new UserExistsException($"{user.Email} is already taken, please choose another email");
            }

            Insert(user);
            return true;
        }
    }
}
