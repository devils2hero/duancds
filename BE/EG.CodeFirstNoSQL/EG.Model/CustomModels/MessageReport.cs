namespace EG.Model.CustomModels
{
    public class MessageReport
    {
        public string Message { get; set; }
        public bool Success { get; set; } = false;

    }
    public class MessageReport<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; } = false;
        public T Data { get; set; }
    }
}
