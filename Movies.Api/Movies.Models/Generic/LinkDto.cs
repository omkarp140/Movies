namespace Movies.Models.Generic
{
    public interface ILinkDto
    {
        string Href { get; set; }

        string Rel { get; set; }

        string Method { get; set; }
    }

    [Serializable]
    public class LinkDto : ILinkDto
    {
        public string Href { get; set; }

        public string Rel { get; set; }

        public string Method { get; set; }

        public LinkDto(string href, string rel, string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }
    }
}
