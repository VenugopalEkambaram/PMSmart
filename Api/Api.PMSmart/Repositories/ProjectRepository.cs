using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Api.PMSmart.Models;
using Api.PMSmart.Models.DTOS;
using AutoMapper;

namespace Api.PMSmart.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public List<ProjectItem> GetProjects()
        {
            using (var db = new PMSmartEntities())
            {
                var result = db.Projects.Select(x => x)
                    .OrderBy(o => o.ProjectId)
                    .ToList();
                
                return Mapper.Map<List<ProjectItem>>(result);
            }
        }

        public List<ProjectItem> GetAssignationDetails()
        {
            using (var db = new PMSmartEntities())
            {
                var result = db.Projects.Include(x => x.Contacts).ToList();

                return result.Select(x => new ProjectItem
                {
                    ProjectId = x.ProjectId,
                    Name = x.Name,
                    Description = x.Description,
                    Contacts = x.Contacts.Select(y => new ContactItem
                    {
                        ContactId = y.ContactId,
                        FirstName = y.FirstName,
                        LastName = y.LastName,
                        ProjectId = y.ProjectId
                    })
                    .OrderBy(o => o.ContactId)
                    .ToList()
                })
                .OrderBy(o => o.ProjectId)
                .ToList();
            }
        }

        public int Create(ProjectItem item)
        {
            var project = Mapper.Map<ProjectItem, Project>(item);
            using (var db = new PMSmartEntities())
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return project.ProjectId;
            }
        }

        public int Update(ProjectItem item)
        {
            var updatedProject = Mapper.Map<ProjectItem, Project>(item);
            using (var db = new PMSmartEntities())
            {
                db.Projects.Attach(updatedProject);
                db.Entry(updatedProject).State = EntityState.Modified;
                db.SaveChanges();
                return updatedProject.ProjectId;
            }
        }
    }
}