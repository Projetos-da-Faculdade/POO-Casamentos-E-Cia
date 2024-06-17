using System;
using System.IO;
using FestaEcia;

namespace POOCasamentosECia
{
    internal class Buffet
    {
        List<Bebida> bebidas;
        IComida comida; 
        
        public Buffet(List<Bebida> bebidas, IComida comida){
            this.bebidas = bebidas;
            this.comida = comida;
        }
    }
}