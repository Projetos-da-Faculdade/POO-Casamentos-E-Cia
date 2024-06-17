using System;
using System.IO;
using FestaEcia;

namespace POOCasamentosECia
{
    internal class Buffet
    {
        List<Bebida> bebidas;
        Comida comida; 
        
        public Buffet(List<Bebida> bebidas, Comida comida){
            this.bebidas = bebidas;
            this.comida = comida;
        }
    }
}