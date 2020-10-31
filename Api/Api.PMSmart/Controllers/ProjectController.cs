using Api.PMSmart.Services;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Api.PMSmart.Models.DTOS;

namespace Api.PMSmart.Controllers
{
    [EnableCors("http://localhost:57905", "*", "*")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var projects = _projectService.GetProjectItems();
            if (projects.Count == 0)
            {
                return new NotFoundResult(this);
            }

            return Ok(projects);
        }

        [HttpGet]
        [Route("assignationdetails")]
        public IHttpActionResult AssignationDetails()
        {
            var result = _projectService.GetAssignationDetails();
            if (result.Count == 0)
            {
                return new NotFoundResult(this);
            }

            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]ProjectItem item)
        {
            var id = _projectService.Create(item);
            if (id > 0)
            {
                return new CreatedNegotiatedContentResult<int>(new Uri(Request.RequestUri + id.ToString()), id, this);
            }

            return new BadRequestResult(this);
        }
    }
}