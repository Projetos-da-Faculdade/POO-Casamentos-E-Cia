using System;
using System.Collections.Generic;

namespace POOCasamentosECia
{
    internal class Empresa
    {
        //Atributo 
        public List<Cerimonia> cerimonia;
        public Empresa()
        {
            this.cerimonia = new List<Cerimonia>();
        }

        //Métodos
        public void ListarCerimonias()
        {
            if (cerimonia.Count() != 0)
            {
                for (int i = 0; i < cerimonia.Count(); i++)
                {
                    Console.WriteLine(cerimonia[i].ToString() + "\n");
                }
            }
            else
            {
                Console.WriteLine("Não possuí cerimonias cadastradas.");
            }
        }
    }
}
