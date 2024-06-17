using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class FestaAniversario: Festas
    {
        public Decoracao decoracao;
        public ItensMesa itensMesa;

        public FestaAniversario(TipoEspaco tipoEspaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data, Decoracao decoracao, ItensMesa itensMesa) : base( tipoEspaco, TipoCerimonia.STANDARD, quantidadeConvidados, tipoFesta, musica, buffet, data)
        {
           this.decoracao = decoracao;
           this.itensMesa = itensMesa;
        }
    }
}
