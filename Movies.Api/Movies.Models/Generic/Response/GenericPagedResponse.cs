namespace Movies.Models.Generic.Response
{
    public class GenericPagedResponse<T> : GenericResponse<T>
    {
        public PageInfoDto PageInfo { get; private set; }

        public GenericPagedResponse(T result, int totalRecords, int pageSize)
            : base(result)
        {
            PageInfo = new PageInfoDto(totalRecords, pageSize);
        }
    }
}
