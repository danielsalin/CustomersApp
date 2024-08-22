using System.ComponentModel.DataAnnotations;

namespace CustomerApi
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        //public int CompanyId { get; set; } //Can be used as Foreign Key to different table
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
        //public bool IsDeleted { get; set; } //Can be used instead of deleting from database
    }
}
