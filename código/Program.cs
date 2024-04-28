using System.Diagnostics;
using POOCasamentosECia;

internal class Program
{
    private static void Main(string[] args)
    {
        Empresa CasamentoECia = new Empresa();
        
        DateTime data = new DateTime(2024,05,30);
        CasamentoECia.AdicionarCerimonias(100,data); 
        CasamentoECia.AdicionarCerimonias(100,data); 
        CasamentoECia.AdicionarCerimonias(50,data); 
        CasamentoECia.AdicionarCerimonias(100,data); 
        CasamentoECia.AdicionarCerimonias(100,data); 
        CasamentoECia.AdicionarCerimonias(100,data); 
        CasamentoECia.AdicionarCerimonias(50,data); 
        CasamentoECia.ListarCerimonias();
       
    }
}
