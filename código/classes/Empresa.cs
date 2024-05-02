using System;
using System.Collections.Generic;

namespace POOCasamentosECia
{
    internal class Empresa
    {
        //Atributo 
        private List<Cerimonia> cerimonias;
        public Empresa()
        {
            this.cerimonias = new List<Cerimonia>();
        }

        //Métodos
        public void ListarCerimonias()
        {
            if (cerimonias.Count() != 0)
            {
                for (int i = 0; i < cerimonias.Count(); i++)
                {
                    Console.WriteLine(cerimonias[i].ToString() + "\n");
                }
            }
            else
            {
                Console.WriteLine("Não possuí cerimônias cadastradas.");
            }
        }

        public void AdicionarCerimonias(int quantidadeConvidados, DateTime data)
        {
            if (quantidadeConvidados > 0 && quantidadeConvidados <= 500)
            {
                Espaco espaco = new Espaco(EspacoDisponivel(quantidadeConvidados, data));
                if (PrazoMinimo30Dias(data) && VerificaSextaOuSabado(data) && VerificaEspacoDisponivel(espaco.Tipo, data))
                {
                    cerimonias.Add(new Cerimonia(quantidadeConvidados, data, espaco));
                    Console.WriteLine($"Adicionado com sucesso no dia: {data.Day+"/"+data.Month+"/"+data.Year} - {data.DayOfWeek}");
                }
                else { AdicionarCerimonias(quantidadeConvidados, RetornarProximaDataValida(data)); }
            }
            else { Console.WriteLine("Quantidade de convidados inválidas"); }
        }

        public void RemoverCerimonias(int codigo)
        {
            //Remover uma cerimonia da lista cerimonias a partir do seu código.
            throw new NotImplementedException();
        }

        private bool VerificaEspacoDisponivel(TipoEspaco espaco, DateTime data)
        {
            foreach (Cerimonia cerimonia in cerimonias)
            {
                if (cerimonia.Data == data && cerimonia.Espaco.Tipo == espaco)
                {
                    return false;
                }
            }
            return true;
        }

        private TipoEspaco EspacoDisponivel(int quantidadeConvidados, DateTime data)
        {

            if (quantidadeConvidados > 0 && quantidadeConvidados <= 50 && VerificaEspacoDisponivel(TipoEspaco.ESPACO_G, data))
            {
                return TipoEspaco.ESPACO_G;
            }
            else if (quantidadeConvidados > 50 && quantidadeConvidados <= 100)
            {
                if (VerificaEspacoDisponivel(TipoEspaco.ESPACO_A, data))
                {
                    return TipoEspaco.ESPACO_A;
                }
                else if (VerificaEspacoDisponivel(TipoEspaco.ESPACO_B, data))
                {
                    return TipoEspaco.ESPACO_B;
                }
                else if (VerificaEspacoDisponivel(TipoEspaco.ESPACO_C, data))
                {
                    return TipoEspaco.ESPACO_C;
                }
                else if (VerificaEspacoDisponivel(TipoEspaco.ESPACO_D, data))
                {
                    return TipoEspaco.ESPACO_D;
                }
            }
            else if (quantidadeConvidados > 100 && quantidadeConvidados <= 200)
            {
                if (VerificaEspacoDisponivel(TipoEspaco.ESPACO_E, data))
                {
                    return TipoEspaco.ESPACO_E;
                }
                else if (VerificaEspacoDisponivel(TipoEspaco.ESPACO_F, data))
                {
                    return TipoEspaco.ESPACO_F;
                }
            }
            else if (quantidadeConvidados > 200 && quantidadeConvidados < 500 && VerificaEspacoDisponivel(TipoEspaco.ESPACO_H, data))
            {
                return TipoEspaco.ESPACO_H;
            }

            return EspacoDisponivel(quantidadeConvidados, RetornarProximaDataValida(data));
        }

        private DateTime RetornarProximaDataValida(DateTime data)
        {
            do
            {
                data = data.AddDays(1);
            } while (data.DayOfWeek != DayOfWeek.Friday && data.DayOfWeek != DayOfWeek.Saturday);

            return data;
        }

        private bool VerificaSextaOuSabado(DateTime data)
        {
            DayOfWeek dia = data.DayOfWeek;
            return dia == DayOfWeek.Friday || dia == DayOfWeek.Saturday;
        }

        private bool PrazoMinimo30Dias(DateTime data)
        {
            DateTime hoje = DateTime.Today;
            int diferencaDias = (data - hoje).Days;
            return diferencaDias >= 30;
        }
    }
}
