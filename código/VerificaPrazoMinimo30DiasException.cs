public class VerificaPrazoMinimo30DiasException : Exception{
    public VerificaPrazoMinimo30DiasException(){}
    public VerificaPrazoMinimo30DiasException(string message) : base(message){}
    public VerificaPrazoMinimo30DiasException(string message, Exception innerException) : base(message, innerException){}
}