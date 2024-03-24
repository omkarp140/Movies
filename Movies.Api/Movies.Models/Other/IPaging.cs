namespace Movies.Models.Other
{
    public interface IPaging
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
    }
}
