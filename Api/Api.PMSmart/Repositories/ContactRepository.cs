using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Api.PMSmart.Models;
using Api.PMSmart.Models.DTOS;
using AutoMapper;

namespace Api.PMSmart.Repositories
{
    public class ContactRepository : IContactRepository
    {
        public List<ContactItem> GetContacts()
        {
            using (var db = new PMSmartEntities())
            {
                var result = db.Contacts.Select(x => x)
                    .OrderBy(o => o.ContactId)
                    .ToList();

                return Mapper.Map<List<ContactItem>>(result);
            }
        }

        public List<ContactItem> GetContactsForAssignation(int projectId)
        {
            using (var db = new PMSmartEntities())
            {
                var result = db.Contacts.Where(x => x.ProjectId != projectId).ToList();
                return
                    result.Select(
                        x => new ContactItem { ContactId = x.ContactId, FirstName = x.FirstName, LastName = x.LastName })
                        .OrderBy(o => o.ContactId)
                        .ToList();
            }
        }

        public int Create(ContactItem item)
        {
            var contact = Mapper.Map<ContactItem, Contact>(item);
            using (var db = new PMSmartEntities())
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return contact.ContactId;
            }
        }

        public int Update(ContactItem item)
        {
            var updatedContact = Mapper.Map<ContactItem, Contact>(item);
            using (var db = new PMSmartEntities())
            {
                db.Contacts.Attach(updatedContact);
                db.Entry(updatedContact).State = EntityState.Modified;
                db.SaveChanges();
                return updatedContact.ContactId;
            }
        }
    }
}