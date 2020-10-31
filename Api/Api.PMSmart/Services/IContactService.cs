using System.Collections.Generic;
using Api.PMSmart.Models.DTOS;

namespace Api.PMSmart.Services
{
    public interface IContactService
    {
        int Create(ContactItem item);

        List<ContactItem> GetContactItems();

        List<ContactItem> GetContactsForAssignation(int projectId);

        int Update(ContactItem item);
    }
}