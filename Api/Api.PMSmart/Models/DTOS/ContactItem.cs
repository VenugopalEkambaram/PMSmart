namespace Api.PMSmart.Models.DTOS
{
    public class ContactItem
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ProjectId { get; set; }
    }
}