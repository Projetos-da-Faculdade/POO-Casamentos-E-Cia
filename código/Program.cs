using System.Diagnostics;
using POOCasamentosECia;

internal class Program
{
    private static void Main(string[] args)
    {
        Espaco e = new Espaco(TipoEspaco.ESPACO_G);
        Console.WriteLine(e.RetornarPrecoEspaco());
       
    }
}
