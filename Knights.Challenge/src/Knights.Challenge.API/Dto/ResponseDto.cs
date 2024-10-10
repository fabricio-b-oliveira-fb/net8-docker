namespace Knights.Challenge.DTO
{
    public class ResponseDto
    {
        public bool Success { get { return Error.Count == 0; } }
        public object? Result { get; set; }
        public List<string> Error { get; set; }

        public ResponseDto()
        {
            Error = [];
        }
    }
}
