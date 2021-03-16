namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Read onlyler constructorlarda set edilebilir.
        public Result(bool success)
        {
            Success = success;
        }

        //this kendini kastediyor. Result sınıfı
        public Result(bool success,string message):this(success)
        {
            Message = message;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
