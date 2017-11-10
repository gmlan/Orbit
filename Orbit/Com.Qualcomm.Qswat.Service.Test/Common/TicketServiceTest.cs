using Autofac;
using Com.Qualcomm.Qswat.Service.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Com.Qualcomm.Qswat.Service.Test.Common
{
    [TestClass]
    public class TicketServiceTest
    {
        public TicketServiceTest()
        {
            StaticIoc.Register();
        }

        [TestMethod]
        public void TestCase_Get_Ticket_By_CreatedBy_Fail()
        {
            var ticketSvc = StaticIoc.TestContainer.Resolve<IssueService>();
            var ticket =
                 ticketSvc.QueryAll()
                     .FirstOrDefault(
                         m =>
                             m.Assignee.Email.Equals("gm.lan@gmail.com",
                                 StringComparison.InvariantCultureIgnoreCase));
            Assert.IsNull(ticket);
        }

        [TestMethod]
        public void TestCase_Get_Ticket_By_CreatedBy_Success()
        {
            var ticketSvc = StaticIoc.TestContainer.Resolve<IssueService>();
            var ticket =
                ticketSvc.QueryAll()
                    .FirstOrDefault(
                        m =>
                            m.Assignee.Email.Equals("guangming.lan@gmail.com",
                                StringComparison.InvariantCultureIgnoreCase));
            Assert.IsNotNull(ticket);
        }
    }
}
