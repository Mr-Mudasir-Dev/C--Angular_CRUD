namespace Angular_CRUD.Data.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public int age { get; set; }
        public bool IsActive { get; set; }
     }
}
