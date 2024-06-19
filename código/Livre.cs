using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class Livre : IInformacaoFesta, ISalvartxt
    {
        public Espaco espaco { get; }
        public int quantidadeConvidados { get; }
        public DateTime data { get; }
        public TipoFesta tipoFesta { get ;}

        public Livre(Espaco espaco, TipoFesta tipoFesta, int quantidadeConvidados, DateTime data){
            this.espaco = espaco;
            this.quantidadeConvidados = quantidadeConvidados;
            this.data = data;
        }

        public void InformacaoFesta(){
            Console.WriteLine("-----"+tipoFesta+"-----");
            Console.WriteLine("Quantidade de convidados: "+quantidadeConvidados);
            Console.WriteLine("Espaço: "+espaco.tipo+" valor: "+ espaco.valor);
            Console.WriteLine("Data do Evento: "+data.Day+"/"+data.Month+"/"+data.Year);

            Console.WriteLine("Valor total: "+espaco.valor);
        }

        public void Salvartxt(){
            StreamWriter sw = null;
            try{
                sw = new StreamWriter(".festas/festas.txt",true);
                sw.Write(data.Day+"/"+data.Month+"/"+data.Year+" "+tipoFesta+" "+quantidadeConvidados+" "+espaco.tipo+" "+espaco.valor+" "+espaco.valor);
            }catch(Exception ex){ Console.WriteLine(ex.Message);}
            finally{sw.Close();}
        }
    }
}