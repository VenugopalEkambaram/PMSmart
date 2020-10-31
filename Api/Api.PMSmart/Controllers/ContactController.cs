using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using Api.PMSmart.Models.DTOS;
using Api.PMSmart.Services;

namespace Api.PMSmart.Controllers
{
    [EnableCors("http://localhost:57905", "*", "*")]
    public class ContactController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IHttpActionResult Get()
        {
            var contacts = _contactService.GetContactItems();
            if (contacts.Count == 0)
            {
                return new NotFoundResult(this);
            }

            return Ok(contacts);
        }

        [HttpGet]
        [Route("contactsforassignation")]
        public IHttpActionResult ContactsForAssignation(int projectId)
        {
            var contacts = _contactService.GetContactsForAssignation(projectId);
            if (contacts.Count == 0)
            {
                return new NotFoundResult(this);
            }

            return Ok(contacts);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody]ContactItem item)
        {
            var id = _contactService.Create(item);
            if (id > 0)
            {
                return new CreatedNegotiatedContentResult<int>(new Uri(Request.RequestUri + id.ToString()), id, this);
            }

            return new BadRequestResult(this);
        }

        public IHttpActionResult Put([FromBody]ContactItem item)
        {
            var id = _contactService.Update(item);
            if (id > 0)
            {
                return Ok(id);
            }

            return new NotFoundResult(this);
        }
    }
}