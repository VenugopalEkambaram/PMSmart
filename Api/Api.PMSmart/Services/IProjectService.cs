using System.Collections.Generic;
using Api.PMSmart.Models.DTOS;

namespace Api.PMSmart.Services
{
    public interface IProjectService
    {
        int Create(ProjectItem item);

        List<ProjectItem> GetProjectItems();

        List<ProjectItem> GetAssignationDetails();

        int Update(ProjectItem item);
    }
}