using System.Collections.Generic;
using Api.PMSmart.Models.DTOS;

namespace Api.PMSmart.Repositories
{
    public interface IContactRepository
    {
        List<ContactItem> GetContacts();

        List<ContactItem> GetContactsForAssignation(int projectId);

        int Create(ContactItem item);

        int Update(ContactItem item);
    }
}