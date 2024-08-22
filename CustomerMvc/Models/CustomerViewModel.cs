using System.ComponentModel.DataAnnotations;

namespace CustomerMvc.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [StringLength(32)]
        public string Name { get; set; }
        [StringLength(32)]
        public string Company { get; set; }
        [Range(1,100)]
        public int CompanyId { get; set; } //Can be used as Foreign Key to different table
        [StringLength(14)]
        public string PhoneNumber { get; set; }
        [StringLength(32)]
        public string? Email { get; set; }
        [StringLength(100)]
        public string? Address { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
        public bool IsDeleted { get; set; } //Can be used instead of deleting from database
    }
}
