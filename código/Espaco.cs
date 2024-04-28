using System;

namespace POOCasamentosECia
{
    internal class Espaco
    {
        //Atributos
        private TipoEspaco tipo;
        private double valor;

        //Propriedade
        public TipoEspaco Tipo { get => tipo; }

        //Construtor
        public Espaco(TipoEspaco tipo)
        {
            this.tipo = tipo;
            this.valor = DefinirPrecoEspaco(tipo);
        }

        //Metodos
        public double RetornarPrecoEspaco()
        {
            return valor;
        }

        private double DefinirPrecoEspaco(TipoEspaco tipo)
        {
            double valorEspaco=0;
            string []vetorEspacoPreco;
            string linha;
            try
            {
                StreamReader ler = new StreamReader("./precos/valorEspaco.txt", true);
                
                while ((linha = ler.ReadLine()) != null)
                {
                    vetorEspacoPreco = linha.Split(' ');
                    if(vetorEspacoPreco[0] == tipo.ToString()){
                        valorEspaco = double.Parse(vetorEspacoPreco[1]);
                        break;
                    }
                }
                ler.Close();
            }
            catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
            return valorEspaco;
        }
    }
}
