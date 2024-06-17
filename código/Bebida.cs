using System;
using System.IO;
using FestaEcia;

namespace POOCasamentosECia
{
    internal class Bebida
    {
        public TipoBebida nomeBebida { get; }
        public double valor { get; } 
        public int quantidade { get; }
        
        public Bebida (TipoBebida nomeBebida, int quantidade){
            this.nomeBebida = nomeBebida;
            this.quantidade = quantidade;
            this.valor = DefinirValorBebida(nomeBebida);
        }

        private double DefinirValorBebida(TipoBebida nomeBebida){
            double valorBebida=0;
            string []vetorBebidaPreco;
            string linha;
            try
            {
                StreamReader ler = new StreamReader("./precos/valorBebidas.txt", true);
                
                while ((linha = ler.ReadLine()) != null)
                {
                    vetorBebidaPreco = linha.Split(" ");
                    if(vetorBebidaPreco[0] == nomeBebida.ToString()){
                        valorBebida = double.Parse(vetorBebidaPreco[3]);
                        break;
                    }
                }
            }
            catch (Exception e) { Console.WriteLine("Exception: " + e.Message); }
            return valorBebida;
        }
    }
}
