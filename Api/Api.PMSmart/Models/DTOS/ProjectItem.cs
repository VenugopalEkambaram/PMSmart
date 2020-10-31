using System.Collections.Generic;

namespace Api.PMSmart.Models.DTOS
{
    public class ProjectItem
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ContactItem> Contacts { get; set; }
    }
}