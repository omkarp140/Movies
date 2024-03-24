namespace Movies.Models.Generic.Response
{
    public class GenericResponse<T>
    {
        public T Result { get; set; }

        public GenericResponse(T result)
        {
            Result = result;
        }
    }
}
