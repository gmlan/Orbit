using Com.Qualcomm.Qswat.Model.Common;
using System.Collections.Generic;

namespace Com.Qualcomm.Qswat.Core.Interface
{
    public interface IIssueService : IGenericBusinessService<Issue>
    {
        IList<Issue> GetIssueByAssignee(int assigneeId);

        IList<Issue> GetIssueByCreator(int creatorId);
    }
}
