using POOCasamentosECia;

class Decoracao
{
    public double valorDecoracao{ get; }

    public Decoracao(TipoCerimonia tipoDecoracao){
        valorDecoracao = DefinirPrecoDecoracao(tipoDecoracao);
    }
    
    private double DefinirPrecoDecoracao(TipoCerimonia tipoDecoracao)
    {
        double valorDecoracao = 0;
        string[] vetorBoloPreco;
        string linha;
        try
        {
            StreamReader ler = new StreamReader("./precos/valorItens.txt", true);

            while ((linha = ler.ReadLine()) != null)
            {
                vetorBoloPreco = linha.Split(" ");
                if (tipoDecoracao == TipoCerimonia.STANDARD && vetorBoloPreco[0] == "DECORACAO")
                {
                    valorDecoracao = double.Parse(vetorBoloPreco[3]);
                    break;
                }
                else if(tipoDecoracao == TipoCerimonia.LUXO && vetorBoloPreco[0] == "DECORACAO")
                {
                    valorDecoracao = double.Parse(vetorBoloPreco[2]);
                    break;
                }
                else if(tipoDecoracao == TipoCerimonia.PREMIER && vetorBoloPreco[0] == "DECORACAO")
                {
                    valorDecoracao = double.Parse(vetorBoloPreco[1]);
                    break;
                }
            }
            ler.Close();
        }
        catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
        return valorDecoracao;
    }
}
