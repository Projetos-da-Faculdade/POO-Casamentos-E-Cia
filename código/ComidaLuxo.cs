using POOCasamentosECia;

class ComidaLuxo: Comida
{
    public override double DefinirPrecoComida(int quantidadeConvidados)
    {
        return quantidadeConvidados * 48;
    }
}