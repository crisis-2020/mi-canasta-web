namespace MiCanasta.MiCanasta
{
    public class ExceptionDto
    {
        public string Exception { get; set; }
        public string Message { get; set; }

        public ExceptionDto(string Exception, string Message) {
            this.Exception = Exception;
            this.Message = Message;
        }
    }

}
