using Com.Qualcomm.Qswat.Model.Common;

namespace Com.Qualcomm.Qswat.Core.Interface
{
    public interface IUserService : IGenericBusinessService<User>
    {
        User GetByEmail(string email);

        bool Login(string userName, string password);

        bool Register(User user);

    }
}
