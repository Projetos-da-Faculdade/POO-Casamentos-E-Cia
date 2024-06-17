using System;
using System.IO;

class ComidaPremier : IComida
{
    public double precoSalgados { get; } 
    public ComidaPremier(int quantidadeConvidados){
        this.precoSalgados = DefinirPrecoComida(quantidadeConvidados); 
    }

    public double DefinirPrecoComida(int quantidadeConvidados)
    {
        return quantidadeConvidados * 60;
    }
}
