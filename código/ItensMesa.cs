using POOCasamentosECia;

class ItensMesa
{
    public double valorItensMesa { get; }

    public ItensMesa(TipoCerimonia tipoItensMesa){
        valorItensMesa = DefinirPrecoItensMesa(tipoItensMesa);
    }
    
    private double DefinirPrecoItensMesa(TipoCerimonia tipoItensMesa)
    {
        double valorItensMesa = 0;
        string[] vetorItensMesaPreco;
        string linha;
        try
        {
            StreamReader ler = new StreamReader("./precos/valorItens.txt", true);

            while ((linha = ler.ReadLine()) != null)
            {
                vetorItensMesaPreco = linha.Split(" ");
                if (tipoItensMesa == TipoCerimonia.STANDARD && vetorItensMesaPreco[0] == "ITENS_MESA")
                {
                    valorItensMesa = double.Parse(vetorItensMesaPreco[3]);
                    break;
                }
                else if(tipoItensMesa == TipoCerimonia.LUXO && vetorItensMesaPreco[0] == "ITENS_MESA")
                {
                    valorItensMesa = double.Parse(vetorItensMesaPreco[2]);
                    break;
                }
                else if(tipoItensMesa == TipoCerimonia.PREMIER && vetorItensMesaPreco[0] == "ITENS_MESA")
                {
                    valorItensMesa = double.Parse(vetorItensMesaPreco[1]);
                    break;
                }
            }
            ler.Close();
        }
        catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
        return valorItensMesa;
    }
}
