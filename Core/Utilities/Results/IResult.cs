namespace Core.Utilities.Results
{
    //Temel void metotları için interfacedir.
    public interface IResult
    {
        //Get: Sadece okunabilir.
        bool Success { get; }
        string Message { get; }
    }
}
