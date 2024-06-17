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
        public Cerimonia() : base( tipoEspaco, tipoCerimonia, quantidadeConvidados, tipoFesta, musica, buffet, data)
        {
           
        }

        //Métodos
        public override string ToString()
        {
            return $"Quantidade de convidades: {this.quantidadeConvidados}\n" +
                   $"Data da cerimonia: {this.data.Day+"/"+this.data.Month+"/"+this.data.Year} - {this.data.DayOfWeek}\n" +
                   $"Espaço ocupado: {this.espaco.Tipo}";
        }
    }
}
