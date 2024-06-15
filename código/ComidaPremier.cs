using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class ComidaPremier : Comida
    {
        public override double DefinirPrecoComida(Cerimonia cerimonia)
        {
            precoSalgados = cerimonia.quantidadeConvidados * 60;
            return precoSalgados;
        }
    }
}
