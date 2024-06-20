public class ValorNegativoException : Exception{
    public ValorNegativoException(){}
    public ValorNegativoException(string message) : base(message){}
    public ValorNegativoException(string message, Exception innerException) : base(message, innerException){}
}
