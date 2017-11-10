using Com.Qualcomm.Qswat.Core.Interface;
using Com.Qualcomm.Qswat.Model.Common;
using System.Collections.Generic;
using System.Linq;

namespace Com.Qualcomm.Qswat.Service.Common
{
    public class IssueService : GenericBusinessServices<Issue>, IIssueService
    {
        public IssueService(IRepository<Issue> repository) : base(repository)
        {
        }

        public IList<Issue> GetIssueByAssignee(int assigneeId)
        {
            return Repository.Table.Where(m => m.AssigneeId == assigneeId).ToList();
        }

        public IList<Issue> GetIssueByCreator(int creatorId)
        {
            return Repository.Table.Where(m => m.CreatedById == creatorId).ToList();
        }
    }
}
