namespace Movies.Models.Generic.Response
{
    public static class ResponseHelper
    {
        public static GenericResponse<TResult> GetResponse<TResult>(TResult result)
        {
            return new GenericResponse<TResult>(result);
        }

        public static GenericResponse<ILinkedCollectionResourceWrapperDto<TResult>> GetResponse<TResult>(ILinkedCollectionResourceWrapperDto<TResult> result) where TResult : ILinkedResourceBaseDto
        {
            return new GenericResponse<ILinkedCollectionResourceWrapperDto<TResult>>(result);
        }

        public static GenericPagedResponse<TResult> GetPagedResponse<TResult>(TResult result, int totalRecords, int pageSize)
        {
            return new GenericPagedResponse<TResult>(result, totalRecords, pageSize);
        }

        public static GenericPagedResponse<ILinkedCollectionResourceWrapperDto<TResult>> GetPagedResponse<TResult>(ILinkedCollectionResourceWrapperDto<TResult> result, int totalRecords, int pageSize) where TResult : ILinkedResourceBaseDto
        {
            return new GenericPagedResponse<ILinkedCollectionResourceWrapperDto<TResult>>(result, totalRecords, pageSize);
        }
    }
}
