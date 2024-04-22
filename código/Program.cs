using System.Diagnostics;
using POOCasamentosECia;

internal class Program
{
    private static void Main(string[] args)
    {
        Empresa CasamentoECia = new Empresa();
        
        DateTime data = DateTime.Now;
        CasamentoECia.cerimonia.Add( new Cerimonia(100,data,TipoEspaco.ESPACO_A)); 
        CasamentoECia.ListarCerimonias();
    }
}
