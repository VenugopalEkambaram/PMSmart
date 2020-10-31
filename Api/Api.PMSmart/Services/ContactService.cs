using System.Collections.Generic;
using Api.PMSmart.Models.DTOS;
using Api.PMSmart.Repositories;

namespace Api.PMSmart.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<ContactItem> GetContactItems()
        {
            return _contactRepository.GetContacts();
        }

        public List<ContactItem> GetContactsForAssignation(int projectId)
        {
            return _contactRepository.GetContactsForAssignation(projectId);
        }

        public int Create(ContactItem item)
        {
            return _contactRepository.Create(item);
        }

        public int Update(ContactItem item)
        {
            return _contactRepository.Update(item);
        }
    }
}