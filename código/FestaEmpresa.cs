using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class FestaEmpresa : Festas, IInformacaoFesta,ISalvartxt
    {
        public FestaEmpresa(Espaco espaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data) : base( espaco, tipoCerimonia, quantidadeConvidados, tipoFesta, musica, buffet, data){ }

        public void InformacaoFesta(){
            Console.WriteLine("-----"+tipoFesta+" "+tipoCerimonia+"-----");
            Console.WriteLine("Quantidade de convidados: "+quantidadeConvidados);
            Console.WriteLine("Espaço: "+espaco.tipo+" valor: "+ espaco.valor);
            Console.WriteLine("Data do Evento: "+data.Day+"/"+data.Month+"/"+data.Year);
            Console.WriteLine("Música: "+musica.valorMusica);
            Console.WriteLine("Salgados "+tipoCerimonia+" : "+buffet.comida.DefinirPrecoComida(quantidadeConvidados));
            Console.WriteLine("Bebidas: ");
            buffet.MostrarInformacaoBebidas();

            Console.WriteLine("Valor total: "+ (espaco.valor + musica.valorMusica + 
                            buffet.comida.DefinirPrecoComida(quantidadeConvidados) + buffet.ValorTotalBebidas()));
        }

        public void Salvartxt(){
            StreamWriter sw = null;
            try{
                sw = new StreamWriter(".festas/festas.txt",true);
                sw.Write(data.Day+"/"+data.Month+"/"+data.Year+" "+
                         tipoFesta+" "+quantidadeConvidados+" "+espaco.tipo+" "+espaco.valor+" "+
                         (espaco.valor + musica.valorMusica + buffet.comida.DefinirPrecoComida(quantidadeConvidados) + buffet.ValorTotalBebidas())+" "+
                         tipoCerimonia+" "+musica.valorMusica+" "+buffet.comida.DefinirPrecoComida(quantidadeConvidados)+" "+buffet.AdicionarFormatotxt());
            }catch(Exception ex){ Console.WriteLine(ex.Message);}
            finally{sw.Close();}
        }

    }
}
