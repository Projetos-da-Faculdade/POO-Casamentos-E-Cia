using POOCasamentosECia;

class Bolo
{
    public double valorBolo { get; }

    public Bolo(TipoCerimonia tipoBolo){
        valorBolo = DefinirPrecoBolo(tipoBolo);
    }
    
    private double DefinirPrecoBolo(TipoCerimonia tipoBolo)
    {
        double valorBolo = 0;
        string[] vetorBoloPreco;
        string linha;
        try
        {
            StreamReader ler = new StreamReader("./precos/valorItens.txt", true);

            while ((linha = ler.ReadLine()) != null)
            {
                vetorBoloPreco = linha.Split(" ");
                if (tipoBolo == TipoCerimonia.STANDARD && vetorBoloPreco[0] == "BOLO")
                {
                    valorBolo = double.Parse(vetorBoloPreco[3]);
                    break;
                }
                else if(tipoBolo == TipoCerimonia.LUXO && vetorBoloPreco[0] == "BOLO")
                {
                    valorBolo = double.Parse(vetorBoloPreco[2]);
                    break;
                }
                else if(tipoBolo == TipoCerimonia.PREMIER && vetorBoloPreco[0] == "BOLO")
                {
                    valorBolo = double.Parse(vetorBoloPreco[1]);
                    break;
                }
            }
            ler.Close();
        }
        catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
        return valorBolo;
    }
}
