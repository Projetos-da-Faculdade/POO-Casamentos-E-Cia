using POOCasamentosECia;

class ComidaLuxo: Comida
{
    public override double DefinirPrecoComida(Cerimonia cerimonia)
    {
        precoSalgados = cerimonia.quantidadeConvidados * 48;
        return precoSalgados;
    }
}