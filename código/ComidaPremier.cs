using System;
using System.IO;


internal class ComidaPremier : Comida
{
    public override double DefinirPrecoComida(int quantidadeConvidados)
    {
        return quantidadeConvidados * 60;
    }
}

