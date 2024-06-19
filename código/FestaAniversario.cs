using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class FestaAniversario: Festas, IInformacaoFesta, ISalvartxt
    {
        public Decoracao decoracao { get; }
        public ItensMesa itensMesa { get; }
        public Bolo bolo { get;}

        public FestaAniversario(Espaco espaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data, Decoracao decoracao, ItensMesa itensMesa, Bolo bolo) : base( espaco, TipoCerimonia.STANDARD, quantidadeConvidados, tipoFesta, musica, buffet, data)
        {
           this.decoracao = decoracao;
           this.itensMesa = itensMesa;
           this.bolo = bolo;
        }

        public void InformacaoFesta(){
            Console.WriteLine("-----"+tipoFesta+" "+tipoCerimonia+"-----");
            Console.WriteLine("Quantidade de convidados: "+quantidadeConvidados);
            Console.WriteLine("Espaço: "+espaco.tipo+" valor: "+ espaco.valor);
            Console.WriteLine("Data do Evento: "+data.Day+"/"+data.Month+"/"+data.Year);
            Console.WriteLine("Música: "+musica.valorMusica);
            Console.WriteLine("Decoração: "+decoracao.valorDecoracao);
            Console.WriteLine("Itens de Mesa: "+ itensMesa.valorItensMesa);
            Console.WriteLine("Salgados "+tipoCerimonia+" : "+buffet.comida.DefinirPrecoComida(quantidadeConvidados));
            Console.WriteLine("Bebidas: ");
            buffet.MostrarInformacaoBebidas();

            Console.WriteLine("Valor total: "+ (espaco.valor + musica.valorMusica + 
                            decoracao.valorDecoracao + itensMesa.valorItensMesa + 
                            buffet.comida.DefinirPrecoComida(quantidadeConvidados) + buffet.ValorTotalBebidas()));
        }

        public void Salvartxt(){
            StreamWriter sw = null;
            try{
                sw = new StreamWriter(".festas/festas.txt",true);
                sw.Write(data.Day+"/"+data.Month+"/"+data.Year+" "+
                         tipoFesta+" "+quantidadeConvidados+" "+espaco.tipo+" "+espaco.valor+" "+
                         (espaco.valor + musica.valorMusica + decoracao.valorDecoracao + itensMesa.valorItensMesa + buffet.comida.DefinirPrecoComida(quantidadeConvidados) + buffet.ValorTotalBebidas())+" "+
                         tipoCerimonia+" "+musica.valorMusica+" "+buffet.comida.DefinirPrecoComida(quantidadeConvidados)+" "+bolo.valorBolo+" "+decoracao.valorDecoracao+" "+itensMesa.valorItensMesa+" "+buffet.AdicionarFormatotxt());
            }catch(Exception ex){ Console.WriteLine(ex.Message);}
            finally{sw.Close();}
        }
    }
}
