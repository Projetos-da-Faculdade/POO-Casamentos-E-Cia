public class ValorNuloException : Exception{
    public ValorNuloException(){}
    public ValorNuloException(string message) : base(message){}
    public ValorNuloException(string message, Exception innerException) : base(message, innerException){}
}
