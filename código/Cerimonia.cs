public class Cerimonia
{
    private DateTime data; 
    public int quantidadeConvidados; 
    private List<Espaco> espacos; 

    public Cerimonia(int quantConvidados, DateTime data, List<Espaco> espacos)
    {
        this.quantidadeConvidados = quantConvidados;
        this.data = data;
        this.espacos = espacos;
    }
    public bool VerificaSextaSabado(DateTime data)
    {
        DayOfWeek dia = data.DayOfWeek;
        return dia == DayOfWeek.Friday || dia == DayOfWeek.Saturday;
    }
    public bool PrazoMinimo30Dias(DateTime data)
    {
        double diasNoFuturo = (data - DateTime.Today).TotalDays;
        return diasNoFuturo >= 30 && VerificaSextaSabado(data);
    }

}