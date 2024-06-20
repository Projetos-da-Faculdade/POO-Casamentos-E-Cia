using System;
using System.IO;

namespace POOCasamentosECia
{
    class Festas 
    {
        public Espaco espaco { get; }
        public TipoCerimonia tipoCerimonia { get; }
        public int quantidadeConvidados { get; }
        public TipoFesta tipoFesta { get; }
        public Musica musica { get; }
        public Buffet buffet { get; }
        public DateTime data { get; }

        public Festas(Espaco espaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data){
            this.espaco = espaco;
            this.tipoCerimonia = tipoCerimonia;
            this.quantidadeConvidados = quantidadeConvidados;
            this.tipoFesta = tipoFesta;
            this.musica = musica;
            this.buffet = buffet;
            this.data = data;
        }
    }
}
