using System;
using System.IO;

class ComidaStandard : IComida
{
    public double precoSalgados { get; } 
    public ComidaStandard(int quantidadeConvidados){
        this.precoSalgados = DefinirPrecoComida(quantidadeConvidados); 
    }

    public double DefinirPrecoComida(int quantidadeConvidados)
    {
        return quantidadeConvidados * 40;
    }
}
