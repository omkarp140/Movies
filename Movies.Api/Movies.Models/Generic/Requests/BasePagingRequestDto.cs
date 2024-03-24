namespace Movies.Models.Generic.Requests
{
    public class BasePagingRequestDto
    {
        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; } = 1;
    }
}
