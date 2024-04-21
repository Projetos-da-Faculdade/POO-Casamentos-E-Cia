public class Cerimonia
{
    private DateTime Data { get; set; }
    public int QuantidadeConvidados { get; set; }
    private List<Espaco> Espacos { get; set; }

    public Cerimonia(int quantConvidados, DateTime data, List<Espaco> espacos)
    {
        QuantidadeConvidados = quantConvidados;
        Data = data;
        Espacos = espacos;
    }
    public bool Prazominimo30dias()
    {
        
    }

}