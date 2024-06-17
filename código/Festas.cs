using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class Festas 
    {
        public TipoEspaco tipoEspaco { get; }
        public TipoCerimonia tipoCerimonia { get; }
        public int quantidadeConvidados { get; }
        public TipoFesta tipoFesta { get; }
        public Musica musica { get; }
        public Buffet buffet { get; }
        public DateTime data { get; }

        public Festas(TipoEspaco tipoEspaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data){
            this.tipoEspaco = tipoEspaco;
            this.tipoCerimonia = tipoCerimonia;
            this.quantidadeConvidados = quantidadeConvidados;
            this.tipoFesta = tipoFesta;
            this.musica = musica;
            this.buffet = buffet;
            this.data = data;
        }
    }
}
