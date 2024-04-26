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
                if (PrazoMinimo30Dias(data))
                {
                    if (VerificaSextaOuSabado(data))
                    {
                        TipoEspaco espaco = MelhorEspaco(quantidadeConvidados, data);
                        if (espaco != TipoEspaco.NULO)
                        {
                            Cerimonia novaCerimonia = new Cerimonia(quantidadeConvidados, data, espaco);
                            cerimonias.Add(novaCerimonia);
                            Console.WriteLine("Cerimônia adicionada com sucesso!");
                        }
                        else { Console.WriteLine("Espaço indisponível"); }
                    }
                    else { Console.WriteLine("Evento não acontece na Sexta ou no Sábado"); }
                }
                else { Console.WriteLine("Prazo mínimo de 30 dias não foi respeitado."); }
            }
            else { Console.WriteLine("Quantidades de convidados inválidas"); }
        }

        public void RemoverCerimonias(int codigo)
        {
            //Remover uma cerimonia da lista cerimonias a partir do seu código.
            throw new NotImplementedException();
        }

        public TipoEspaco MelhorEspaco(int quantidadeConvidados, DateTime data)
        {
            if (cerimonias.Count() == 0)
            {
                if (quantidadeConvidados > 0 && quantidadeConvidados <= 50) { return TipoEspaco.ESPACO_G; }
                else if (quantidadeConvidados > 50 && quantidadeConvidados <= 100) { return TipoEspaco.ESPACO_A; }
                else if (quantidadeConvidados > 100 && quantidadeConvidados <= 200) { return TipoEspaco.ESPACO_E; }
                else if (quantidadeConvidados > 200 && quantidadeConvidados <= 500) { return TipoEspaco.ESPACO_H; }
            }
            else
            {
                foreach (Cerimonia cerimonia in cerimonias)
                {
                    if (cerimonia.Data == data)
                    {
                        if (quantidadeConvidados > 0 && quantidadeConvidados <= 50 && cerimonia.Espaco != TipoEspaco.ESPACO_G)
                        {
                            return TipoEspaco.ESPACO_G;
                        }
                        else if (quantidadeConvidados > 50 && quantidadeConvidados <= 100)
                        {
                            if (cerimonia.Espaco != TipoEspaco.ESPACO_A)
                            {
                                return TipoEspaco.ESPACO_A;
                            }
                            else if (cerimonia.Espaco != TipoEspaco.ESPACO_B)
                            {
                                return TipoEspaco.ESPACO_B;
                            }
                            else if (cerimonia.Espaco != TipoEspaco.ESPACO_C)
                            {
                                return TipoEspaco.ESPACO_C;
                            }
                            else if (cerimonia.Espaco != TipoEspaco.ESPACO_D)
                            {
                                return TipoEspaco.ESPACO_D;
                            }
                        }
                        else if (quantidadeConvidados > 100 && quantidadeConvidados <= 200)
                        {
                            if (cerimonia.Espaco != TipoEspaco.ESPACO_E)
                            {
                                return TipoEspaco.ESPACO_E;
                            }
                            else if (cerimonia.Espaco != TipoEspaco.ESPACO_F)
                            {
                                return TipoEspaco.ESPACO_F;
                            }
                        }
                        if (quantidadeConvidados > 200 && quantidadeConvidados <= 500 && cerimonia.Espaco != TipoEspaco.ESPACO_H)
                        {
                            return TipoEspaco.ESPACO_H;
                        }
                    }
                }
            }
            return TipoEspaco.NULO;
        }

        public bool VerificaSextaOuSabado(DateTime data)
        {
            DayOfWeek dia = data.DayOfWeek;
            return dia == DayOfWeek.Friday || dia == DayOfWeek.Saturday;
        }

        public bool PrazoMinimo30Dias(DateTime data)
        {
            double diasNoFuturo = (data - DateTime.Today).TotalDays;
            return diasNoFuturo >= 30;
        }
    }
}
