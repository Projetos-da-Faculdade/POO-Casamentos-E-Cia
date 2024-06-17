using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class Livre
    {
        public TipoEspaco tipoEspaco { get; }
        public int quantidadeConvidados { get; }
        public DateTime data { get; }

        public Livre(TipoEspaco tipoEspaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, DateTime data){
            this.tipoEspaco = tipoEspaco;
            this.quantidadeConvidados = quantidadeConvidados;
            this.data = data;
        }
    }
}