namespace Movies.Models.Generic
{
    public class PageInfoDto
    {
        public int TotalRecords { get; set; }

        public int TotalPages { get; set; }

        public int PageSize { get; set; }

        public PageInfoDto(int totalRecords, int pageSize)
        {
            TotalRecords = totalRecords;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling((double)TotalRecords / (double)PageSize);
        }
    }
}
