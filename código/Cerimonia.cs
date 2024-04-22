using System;

namespace POOCasamentosECia
{
    internal class Cerimonia
    {
        //Atributos
        private static int codigoCerimonia = 9000;
        private int codigo;
        private DateTime data;
        private int quantidadeConvidados;
        private TipoEspaco espaco;

        //Construtor
        public Cerimonia(int quantidadeConvidados, DateTime data, TipoEspaco espaco)
        {
            this.codigo = Cerimonia.codigoCerimonia++;
            this.quantidadeConvidados = quantidadeConvidados;
            this.data = data;
            this.espaco = espaco;
        }

        //Métodos
        public bool VerificaSextaSabado(DateTime data)
        {
            DayOfWeek dia = data.DayOfWeek;
            return dia == DayOfWeek.Friday || dia == DayOfWeek.Saturday;
        }

        public bool PrazoMinimo30Dias(DateTime data)
        {
            double diasNoFuturo = (data - DateTime.Today).TotalDays;
            return diasNoFuturo >= 30 && VerificaSextaSabado(data);
        }

        public void MelhorEspaco(int quantidadeConvidados)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return $"Código: {codigo}\n" +
                   $"Quantidade de convidades: {this.quantidadeConvidados}\n" +
                   $"Data da cerimonia: R$ {this.data}\n" +
                   $"Espaço ocupado: {this.espaco}";
        }
    }
}
