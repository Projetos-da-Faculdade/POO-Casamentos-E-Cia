using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class FestaEmpresa : Festas
    {
        public FestaEmpresa(TipoEspaco tipoEspaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data) : base( tipoEspaco, tipoCerimonia, quantidadeConvidados, tipoFesta, musica, buffet, data){ }
    }
}
