namespace Movies.Models.Generic
{
    public interface ILinkedResourceBaseDto
    {
        List<LinkDto> Links { get; set; }
    }

    [Serializable]
    public abstract class LinkedResourceBaseDto : ILinkedResourceBaseDto
    {
        public List<LinkDto> Links { get; set; } = new List<LinkDto>();

    }
}
