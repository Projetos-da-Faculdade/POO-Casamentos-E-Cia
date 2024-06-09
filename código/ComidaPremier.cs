using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class ComidaPremier : Comida
    {
        // Atributos
        private double valor;

        // Construtor
        public ComidaPremier(string tipo)
        {
            this.valor = DefinirPrecoComida(tipo);
        }

        // Propriedades
        public double Valor { get => valor; }

        // Métodos
        public double RetornarPrecoComida()
        {
            return valor;
        }

        private double DefinirPrecoComida(string tipo)
        {
            double valorComida = 0;
            string[] vetorComidaPreco;
            string linha;
            try
            {
                using (StreamReader ler = new StreamReader("./precos/valorComidaPremier.txt", true))
                {
                    while ((linha = ler.ReadLine()) != null)
                    {
                        vetorComidaPreco = linha.Split(" ");
                        if (vetorComidaPreco[0] == tipo)
                        {
                            valorComida = double.Parse(vetorComidaPreco[1]);
                            break;
                        }
                    }
                }
                ler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return valorComida;
        }
    }
}
