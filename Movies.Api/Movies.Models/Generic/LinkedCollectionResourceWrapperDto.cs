namespace Movies.Models.Generic
{
    public interface ILinkedCollectionResourceWrapperDto<T> where T : ILinkedResourceBaseDto
    {
        IEnumerable<T> Records { get; set; }

        List<LinkDto> Links { get; set; }
    }

    [Serializable]
    public class LinkedCollectionResourceWrapperDto<T> : LinkedResourceBaseDto, ILinkedCollectionResourceWrapperDto<T> where T : ILinkedResourceBaseDto
    {
        public IEnumerable<T> Records { get; set; }

        public LinkedCollectionResourceWrapperDto(IEnumerable<T> value)
        {
            Records = value;
        }
    }
}
