namespace Movies.Models.Generic.Requests
{
    public class BasePagingWithOrderByRequestDto : BasePagingRequestDto
    {
        public string OrderyByColumn { get; set; } = "";

        public string OrderDirection { get; set; } = "";
    }
}
