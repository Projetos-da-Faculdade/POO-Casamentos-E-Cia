using System;
using System.IO;

namespace POOCasamentosECia
{
    internal class FestaEmpresa : Festas, IInformacaoFesta, ISalvartxt
    {
        public FestaEmpresa(Espaco espaco, TipoCerimonia tipoCerimonia, int quantidadeConvidados, TipoFesta tipoFesta, Musica musica, Buffet buffet, DateTime data) : base(espaco, tipoCerimonia, quantidadeConvidados, tipoFesta, musica, buffet, data) { }

        public void InformacaoFesta()
        {
            Console.WriteLine("~~~~~~~~~~~ " + tipoFesta + " " + tipoCerimonia + " ~~~~~~~~~~~");
            Console.WriteLine("Quantidade de convidados: " + quantidadeConvidados);
            Console.WriteLine("Espaço: " + espaco.tipo + " - valor: R$ " + espaco.valor);
            Console.WriteLine("Data do Evento: " + data.ToString("dd/MM/yyyy"));
            Console.WriteLine("Música: R$ " + musica.valorMusica);
            Console.WriteLine("Salgados " + tipoCerimonia + ": R$ " + buffet.comida.DefinirPrecoComida(quantidadeConvidados));
            Console.WriteLine("Bebidas: ");
            buffet.MostrarInformacaoBebidas();

            Console.WriteLine("Valor total: R$ " + (espaco.valor + musica.valorMusica +
                            buffet.comida.DefinirPrecoComida(quantidadeConvidados) + buffet.ValorTotalBebidas()));
        }

        public void Salvartxt()
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("./festas/festas.txt", true);
                sw.Write(data.ToString("dd/MM/yyyy") + " " +
                         tipoFesta + " " + quantidadeConvidados + " " + espaco.tipo + " " + espaco.valor + " " +
                         (espaco.valor + musica.valorMusica + buffet.comida.DefinirPrecoComida(quantidadeConvidados) + buffet.ValorTotalBebidas()) + " " +
                         tipoCerimonia + " " + musica.valorMusica + " " + buffet.comida.DefinirPrecoComida(quantidadeConvidados) + " ");
                string[] texto = buffet.AdicionarFormatotxt();
                for (int i = 0; i < texto.Count(); i++)
                {
                    sw.Write(texto[i]);
                }
                sw.WriteLine();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { sw.Close(); }
        }

    }
}
