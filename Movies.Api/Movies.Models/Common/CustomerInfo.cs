namespace Movies.Models.Common
{
    public class CustomerInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DatabaseName { get; set; }
        public string DatabaseConnectionString { get; set; }
    }
}
