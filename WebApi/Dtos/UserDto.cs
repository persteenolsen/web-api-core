namespace WebApi.Dtos
{

    // The Class members of this Model / Entity is matching the input fields of the GUI / User Interface
    public class UserDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}