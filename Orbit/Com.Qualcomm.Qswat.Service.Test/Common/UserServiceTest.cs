using Autofac;
using Com.Qualcomm.Qswat.Service.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Com.Qualcomm.Qswat.Service.Test.Common
{
    [TestClass]
    public class UserServiceTest
    {
        public UserServiceTest()
        {
            StaticIoc.Register();
        }

        [TestMethod]
        public void TestCase_Get_User_By_Eamil_Fail()
        {
            var userSvc = StaticIoc.TestContainer.Resolve<UserService>();
            Assert.IsNull(userSvc.GetByEmail("gm.lan.cn@gmail.com"));
        }

        [TestMethod]
        public void TestCase_Get_User_By_Eamil_Success()
        {
            var userSvc = StaticIoc.TestContainer.Resolve<UserService>();
            Assert.IsNotNull(userSvc.GetByEmail("guangming.lan@gmail.com"));
        }

        [TestMethod]
        public void TestCase_User_Login_Fail()
        {
            var userSvc = StaticIoc.TestContainer.Resolve<UserService>();
            Assert.IsFalse(userSvc.Login("guangming.lan@gmail.com", "12345"));

        }

        [TestMethod]
        public void TestCase_User_Login_Success()
        {
            var userSvc = StaticIoc.TestContainer.Resolve<UserService>();
            Assert.IsTrue(userSvc.Login("guangming.lan@gmail.com", "123456"));
        }

        [TestMethod]
        public void TestCase_Get_All_Users()
        {
            var userSvc = StaticIoc.TestContainer.Resolve<UserService>();
            Assert.IsTrue(userSvc.QueryAll().Any());
        }

    }
}
