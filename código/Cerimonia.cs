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

        //propriedades
        public TipoEspaco Espaco { get => espaco; }
        public DateTime Data { get => data; }

        //Construtor
        public Cerimonia(int quantidadeConvidados, DateTime data, TipoEspaco espaco)
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
                   $"Data da cerimonia: R$ {this.data}\n" +
                   $"Espaço ocupado: {this.espaco}";
        }
    }
}
