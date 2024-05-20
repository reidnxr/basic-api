namespace Models
{
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        //navigation property
        public List<UserRole> UserRoles { get; set; }
    }
}
