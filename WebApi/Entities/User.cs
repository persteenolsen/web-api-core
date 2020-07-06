namespace WebApi.Entities
{

    // The Class members of this Model / Entity is matching the columns in the MS SQL Database
    public class User
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string email { get; set; }
        public string Role { get; set; }

        // Note: In the MSSQL Database the data type must be [varbinary](max) 
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}