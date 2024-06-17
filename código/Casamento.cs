using System;

namespace POOCasamentosECia
{
    class Casamento : Festas, IInformacaoFesta
    {
        //Atributos
        public Bolo bolo;
        public Decoracao decoracao;
        public ItensMesa itensMesa;

        //Construtor
        public Casamento(Espaco espaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data, Bolo bolo, Decoracao decoracao, ItensMesa itensMesa) : base( espaco, tipoCerimonia, quantidadeConvidados, tipoFesta, musica, buffet, data)
        {
           this.bolo = bolo;
           this.decoracao = decoracao;
           this.itensMesa = itensMesa;
        }
        
        public void InformacaoFesta(){
            Console.WriteLine("-----",tipoFesta," ",tipoCerimonia,"-----");
            Console.WriteLine("Quantidade de convidados: ",quantidadeConvidados);
            Console.WriteLine("Espaço: ",espaco.tipo," valor: ", espaco.valor);
            Console.WriteLine("Data do Evento: ",data.Day,"/",data.Month,"/",data.Year);
            Console.WriteLine("Música: ",musica.valorMusica);
            Console.WriteLine("Bolo: ",bolo.valorBolo);
            Console.WriteLine("Decoração: ",decoracao.valorDecoracao);
            Console.WriteLine("Itens de Mesa: ", itensMesa.valorItensMesa);
            Console.WriteLine("Saldados ",tipoCerimonia," : ",buffet.comida.DefinirPrecoComida(quantidadeConvidados));
            Console.WriteLine("Bebidas: ");
            buffet.MostrarInformacaoBebidas();

            Console.WriteLine("Valor total: ", espaco.valor + musica.valorMusica + bolo.valorBolo + 
                            decoracao.valorDecoracao + itensMesa.valorItensMesa + 
                            buffet.comida.DefinirPrecoComida(quantidadeConvidados) + buffet.ValorTotalBebidas());
        }
    }
}
