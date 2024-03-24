namespace Movies.Models.Other
{
    public interface IIdEntity
    {
        //TO DO: Change this to Guid
        int Id { get; set; }
    }

    public interface ISoftDeleteEntity
    {
        DateTime DeletedOn { get; set; }
    }

    public interface IBasicAuditTrail
    {
        string CreatedBy { get; set; }
        DateTime? CreatedOn { get; set; }
        string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; }
    }

    public interface IFullAuditTrail
    { }
}
