namespace Movies.Models.EF.Customer
{
    public partial class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DeletedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
