namespace CustomerApi.Dto
{
    public class CreateCustomerRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Updated = DateTime.Now;

        public DateTime Created = DateTime.Now;
    }
}
