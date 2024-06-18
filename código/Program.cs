using System.Diagnostics;
using POOCasamentosECia;

internal class Program
{
    private static void Main(string[] args)
    {
        Espaco e = new Espaco(TipoEspaco.ESPACO_G);
        Console.WriteLine(e.RetornarPrecoEspaco());
        
    }

    public static void MostrarDatasFestas(){
        string[] InformacaoFesta;
        string linha;
        StreamReader ler = null;
        try
        {
            ler = new StreamReader("./festas/festas.txt", true);
            while ((linha = ler.ReadLine()) != null)
            {
                InformacaoFesta = linha.Split(" ");
                Console.WriteLine("Data: ",InformacaoFesta[0],", ",InformacaoFesta[1]," ", InformacaoFesta[2], ", Espaço ocupado: ",InformacaoFesta[3]);
            }
        }
        catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
        finally{ler.Close();}
    }
}
