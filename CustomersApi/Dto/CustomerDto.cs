namespace CustomerApi
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public DateTime Updated { get; set; }
        public DateTime Created { get; set; }
    }
}
