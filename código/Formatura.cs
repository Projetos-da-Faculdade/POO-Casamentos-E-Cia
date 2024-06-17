using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class Formatura : Festas
    {
        public Decoracao decoracao;
        public ItensMesa itensMesa;

        public Formatura(Decoracao decoracao, ItensMesa itensMesa) : base( tipoEspaco, tipoCerimonia, quantidadeConvidados, tipoFesta, musica, buffet, data)
        {
           this.decoracao = decoracao;
           this.itensMesa = itensMesa;
        }
    }
}