using POOCasamentosECia;

class ComidaLuxo: IComida
{
    public double precoSalgados { get; } 
    public ComidaLuxo(int quantidadeConvidados){
        this.precoSalgados = DefinirPrecoComida(quantidadeConvidados); 
    }
    
    public double DefinirPrecoComida(int quantidadeConvidados)
    {
        return quantidadeConvidados * 48;
    }
}
