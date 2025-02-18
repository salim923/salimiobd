namespace OBD.Models
{
    public class User
    {
        public int Id { get; set; }
        public  string Username { get; set; }  // Ensure uniqueness in the DB
        public  string Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}
