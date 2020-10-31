using System.Collections.Generic;
using Api.PMSmart.Models.DTOS;

namespace Api.PMSmart.Repositories
{
    public interface IProjectRepository
    {
        List<ProjectItem> GetProjects();

        List<ProjectItem> GetAssignationDetails();

        int Create(ProjectItem item);

        int Update(ProjectItem item);
    }
}