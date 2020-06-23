namespace DemoApi.Models
{
    public class User
    {
        public bool IsDeleted { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
