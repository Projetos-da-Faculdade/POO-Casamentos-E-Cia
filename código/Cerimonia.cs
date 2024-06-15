using System;

namespace POOCasamentosECia
{
    internal class Cerimonia
    {
        //Atributos
        private static int codigoCerimonia = 9000;
        private int codigo; 
        private DateTime data;
        internal int quantidadeConvidados { get; }
        private Espaco espaco;
        internal TipoCerimonia tipo { get; }
        private Buffet buffet;

        //propriedades
        public Espaco Espaco { get => espaco; }
        public DateTime Data { get => data; }

        //Construtor
        public Cerimonia(int quantidadeConvidados, DateTime data, Espaco espaco)
        {
            this.codigo = Cerimonia.codigoCerimonia++;
            this.quantidadeConvidados = quantidadeConvidados;
            this.data = data;
            this.espaco = espaco;
        }

        //Métodos
        public override string ToString()
        {
            return $"Código: {codigo}\n" +
                   $"Quantidade de convidades: {this.quantidadeConvidados}\n" +
                   $"Data da cerimonia: {this.data.Day+"/"+this.data.Month+"/"+this.data.Year} - {this.data.DayOfWeek}\n" +
                   $"Espaço ocupado: {this.espaco.Tipo}";
        }
    }
}
