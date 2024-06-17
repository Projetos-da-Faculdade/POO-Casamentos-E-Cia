using POOCasamentosECia;

class Comida
{
    internal double precoSalgados;

    public virtual double DefinirPrecoComida(int quantidadeConvidados)
    {
        return quantidadeConvidados * 40;
    }
}

