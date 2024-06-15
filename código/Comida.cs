using POOCasamentosECia;

class Comida
{
    internal double precoSalgados;

    public virtual double DefinirPrecoComida(Cerimonia cerimonia)
    {
        precoSalgados = cerimonia.quantidadeConvidados * 40;
        return precoSalgados;
    }
}

