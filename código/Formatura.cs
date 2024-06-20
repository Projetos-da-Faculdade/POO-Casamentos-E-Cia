using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class Formatura : Festas, IInformacaoFesta, ISalvartxt
    {
        //Atributos
        public Decoracao decoracao { get; }
        public ItensMesa itensMesa { get; }

        //Construtor
        public Formatura(Espaco espaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data, Decoracao decoracao, ItensMesa itensMesa) : base( espaco, tipoCerimonia, quantidadeConvidados, tipoFesta, musica, buffet, data)
        {
           this.decoracao = decoracao;
           this.itensMesa = itensMesa;
        }

        public void InformacaoFesta(){
            Console.WriteLine("~~~~~~~~~~~ "+tipoFesta+" "+tipoCerimonia+" ~~~~~~~~~~~");
            Console.WriteLine("Quantidade de convidados: "+quantidadeConvidados);
            Console.WriteLine("Espaço: "+espaco.tipo+" - valor: R$ "+ espaco.valor);
            Console.WriteLine("Data do Evento: "+data.ToString("dd/MM/yyyy"));
            Console.WriteLine("Música: R$ "+musica.valorMusica);
            Console.WriteLine("Decoração: R$ "+decoracao.valorDecoracao);
            Console.WriteLine("Itens de Mesa: R$ "+ itensMesa.valorItensMesa);
            Console.WriteLine("Salgados "+tipoCerimonia+": R$ "+buffet.comida.DefinirPrecoComida(quantidadeConvidados));
            Console.WriteLine("Bebidas: ");
            buffet.MostrarInformacaoBebidas();

            Console.WriteLine("Valor total: R$ "+ (espaco.valor + musica.valorMusica + 
                            decoracao.valorDecoracao + itensMesa.valorItensMesa + 
                            buffet.comida.DefinirPrecoComida(quantidadeConvidados) + buffet.ValorTotalBebidas()));
        }

        public void Salvartxt(){
            StreamWriter sw = null;
            try{
                sw = new StreamWriter("./festas/festas.txt",true);
                sw.Write(data.ToString("dd/MM/yyyy")+" "+
                         tipoFesta+" "+quantidadeConvidados+" "+espaco.tipo+" "+espaco.valor+" "+
                         (espaco.valor + musica.valorMusica + decoracao.valorDecoracao + itensMesa.valorItensMesa + buffet.comida.DefinirPrecoComida(quantidadeConvidados) + buffet.ValorTotalBebidas())+" "+
                         tipoCerimonia+" "+musica.valorMusica+" "+buffet.comida.DefinirPrecoComida(quantidadeConvidados)+" "+decoracao.valorDecoracao+" "+itensMesa.valorItensMesa+" ");
                string []texto = buffet.AdicionarFormatotxt();
                for (int i = 0; i < texto.Count(); i++)
                {
                    sw.Write(texto[i]);
                }      
                sw.WriteLine();   
            }catch(Exception ex){ Console.WriteLine(ex.Message);}
            finally{sw.Close();}
        }
    }
}
