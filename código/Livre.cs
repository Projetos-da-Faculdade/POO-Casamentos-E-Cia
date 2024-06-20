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
            this.tipoFesta = tipoFesta;
            this.espaco = espaco;
            this.quantidadeConvidados = quantidadeConvidados;
            this.data = data;
        }

        public void InformacaoFesta(){
            Console.WriteLine("~~~~~~~~~~~ "+tipoFesta+" ~~~~~~~~~~~");
            Console.WriteLine("Quantidade de convidados: "+quantidadeConvidados);
            Console.WriteLine("Espaço: "+espaco.tipo+" - valor: R$ "+ espaco.valor);
            Console.WriteLine("Data do Evento: "+data.ToString("dd/MM/yyyy"));

            Console.WriteLine("Valor total: R$ "+espaco.valor);
        }

        public void Salvartxt(){
            StreamWriter sw = null;
            try{
                sw = new StreamWriter("./festas/festas.txt",true);
                sw.WriteLine(data.ToString("dd/MM/yyyy")+" "+tipoFesta+" "+quantidadeConvidados+" "+espaco.tipo+" "+espaco.valor+" "+espaco.valor);
            }catch(Exception ex){ Console.WriteLine(ex.Message);}
            finally{sw.Close();}
        }
    }
}