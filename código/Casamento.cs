using System;

namespace POOCasamentosECia
{
    internal class Casamento : Festas
    {
        //Atributos
        public Bolo bolo;
        public Decoracao decoracao;
        public ItensMesa itensMesa;

        //Construtor
        public Casamento(TipoEspaco tipoEspaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data, Bolo bolo, Decoracao decoracao, ItensMesa itensMesa) : base( tipoEspaco, tipoCerimonia, quantidadeConvidados, tipoFesta, musica, buffet, data)
        {
           this.bolo = bolo;
           this.decoracao = decoracao;
           this.itensMesa = itensMesa;
        }
        
    }
}
