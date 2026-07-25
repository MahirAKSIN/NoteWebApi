namespace NoteWebApi.Common
{
    public class ServiceResult<T>
    {

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public static ServiceResult<T> Fail(List<string> errors)
        {
            return new ServiceResult<T> { Success = false, Errors = errors };
        }
        public static ServiceResult<T> Ok(T data)
        {
            return new ServiceResult<T> { Success = true, Data = data };
        }

    }
}
