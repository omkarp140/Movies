using Movies.Models.Other;

namespace Movies.Models.EF.Customer 
{
    public partial class Genre : IIdEntity, ISoftDeleteEntity, IBasicAuditTrail {   }
}
