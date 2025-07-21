namespace MvcUnitTestDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        // Additional properties can be added as needed
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
