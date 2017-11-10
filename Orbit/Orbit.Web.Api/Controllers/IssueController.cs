using Com.Qualcomm.Qswat.Model.Common;
using Com.Qualcomm.Qswat.Service.Common;
using Orbit.Web.Api.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace Orbit.Web.Api.Controllers
{

    public class IssueController : BaseApiController
    {
        private readonly IssueService _issueService;

        public IssueController(IssueService issueService)
        {
            _issueService = issueService;
        }
        // GET api/values
        public HttpResponseMessage Get()
        {
            return ExecuteAction(new object[] { }, args =>
             {
                 var issues = _issueService.QueryAll().ToList();
                 return new JsonReponse() { Success = true, Data = issues };
             });
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            return ExecuteAction(new object[] { id }, args =>
            {
                var _id = (int)args[0];
                var issue = _issueService.GetById(id);

                return new JsonReponse() { Success = true, Data = issue };
            });
        }

        [HttpGet]
        [Route("api/issues/assignee/{id:int}")]
        public HttpResponseMessage GetByAssignee(int id)
        {
            return ExecuteAction(new object[] { id }, args =>
            {
                var _id = (int)args[0];
                var issues = _issueService.GetIssueByAssignee(_id);
                return new JsonReponse() { Success = true, Data = issues };
            });
        }
        [HttpGet]
        [Route("api/issues/creator/{id:int}")]
        public HttpResponseMessage GetByCreator(int id)
        {
            return ExecuteAction(new object[] { id }, args =>
            {
                var _id = (int)args[0];
                var issues = _issueService.GetIssueByCreator(_id);
                return new JsonReponse() { Success = true, Data = issues };
            });
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Issue issue)
        {
            return ExecuteAction(new object[] { issue }, args =>
            {
                var _issue = args[0] as Issue;
                _issue.CreateDateTimeUtc = DateTime.UtcNow;
                _issueService.Insert(_issue);

                return new JsonReponse() { Success = true, Data = _issue.Id };
            });
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Issue issue)
        {
            return ExecuteAction(new object[] { id, issue }, args =>
             {
                 var _id = (int)args[0];
                 var _issue = (Issue)args[1];

                 var issueFromDb = _issueService.GetById(_id);
                 if (issueFromDb != null)
                 {
                     issueFromDb.Title = _issue.Title;
                     issueFromDb.Description = _issue.Description;
                     issueFromDb.AssigneeId = _issue.AssigneeId;
                     issueFromDb.CreatedById = _issue.CreatedById;
                     issueFromDb.DueDateUtc = _issue.DueDateUtc;
                     issueFromDb.Severity = _issue.Severity;
                     issueFromDb.Status = _issue.Status;
                     issueFromDb.LastModifiedUtc = DateTime.UtcNow;
                     _issueService.Update(issueFromDb);
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
                var issue = _issueService.GetById(_id);
                if (issue != null)
                    _issueService.Delete(issue);

                return new JsonReponse() { Success = true, Data = _id };
            });


        }
    }
}
