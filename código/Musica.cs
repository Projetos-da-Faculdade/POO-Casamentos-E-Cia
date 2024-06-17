using POOCasamentosECia;

class Musica
{
    public double valorMusica { get; }

    public Musica(TipoCerimonia tipoMusica){
        valorMusica = DefinirPrecoBolo(tipoMusica);
    }
    
    private double DefinirPrecoBolo(TipoCerimonia tipoMusica)
    {
        double valorMusica = 0;
        string[] vetorMusicaPreco;
        string linha;
        try
        {
            StreamReader ler = new StreamReader("./precos/valorItens.txt", true);

            while ((linha = ler.ReadLine()) != null)
            {
                vetorMusicaPreco = linha.Split(" ");
                if (tipoMusica == TipoCerimonia.STANDARD && vetorMusicaPreco[0] == "MUSICA")
                {
                    valorMusica = double.Parse(vetorMusicaPreco[3]);
                    break;
                }
                else if(tipoMusica == TipoCerimonia.LUXO && vetorMusicaPreco[0] == "MUSICA")
                {
                    valorMusica = double.Parse(vetorMusicaPreco[2]);
                    break;
                }
                else if(tipoMusica == TipoCerimonia.PREMIER && vetorMusicaPreco[0] == "MUSICA")
                {
                    valorMusica = double.Parse(vetorMusicaPreco[1]);
                    break;
                }
            }
            ler.Close();
        }
        catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
        return valorMusica;
    }
}
