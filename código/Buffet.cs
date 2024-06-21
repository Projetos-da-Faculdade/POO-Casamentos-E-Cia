using System;
using System.IO;
using System.Runtime.CompilerServices;
using FestaEcia;

namespace POOCasamentosECia
{
    class Buffet
    {
        public List<Bebida> bebidas { get; }
        public IComida comida { get; } 
    
        public Buffet(List<Bebida> bebidas, IComida comida){
            this.bebidas = bebidas;
            this.comida = comida;
        }

        public void MostrarInformacaoBebidas(){
            foreach(Bebida bebida in bebidas){
                Console.WriteLine("Nome: "+bebida.nomeBebida+
                " - Quantidade: "+bebida.quantidade+
                " - Valor unitário: R$ "+ bebida.valor+
                " - Valor total: R$ "+bebida.valor * bebida.quantidade);
            }
        }

        public string[] AdicionarFormatotxt(){
            string [] formatoTxt = new string[bebidas.Count()];
            for(int i = 0; i < bebidas.Count(); i++){
                formatoTxt[i] = bebidas[i].nomeBebida+
                " "+ bebidas[i].quantidade+
                " "+ bebidas[i].valor+
                " "+ (bebidas[i].valor * bebidas[i].quantidade) +" ";
            }
            return formatoTxt;
        }

        public double ValorTotalBebidas(){
            double soma = 0;
            foreach(Bebida bebida in bebidas){
                soma += bebida.valor * bebida.quantidade;
            }
            return soma;
        }
    }
}
