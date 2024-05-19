namespace Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public enum Role
    {
        Read = 0,
        Write = 1,
    }
}
