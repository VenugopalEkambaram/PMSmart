using System.Collections.Generic;
using Api.PMSmart.Models.DTOS;
using Api.PMSmart.Repositories;

namespace Api.PMSmart.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<ProjectItem> GetProjectItems()
        {
            return _projectRepository.GetProjects();
            //return result.Select(x => new ProjectItem { ProjectId = x.ProjectId, Name = x.Name, Description = x.Description }).ToList();
        }

        public List<ProjectItem> GetAssignationDetails()
        {
            return _projectRepository.GetAssignationDetails();
        }

        public int Create(ProjectItem item)
        {
            return _projectRepository.Create(item);
        }

        public int Update(ProjectItem item)
        {
            return _projectRepository.Update(item);
        }
    }
}