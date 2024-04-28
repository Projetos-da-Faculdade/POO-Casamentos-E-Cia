using System;

namespace POOCasamentosECia
{
    internal class Espaco
    {
        //Atributos
        private TipoEspaco tipo;
        private double valor;

        //Propriedade
        public TipoEspaco Tipo {get => tipo;}

        //Construtor
        public Espaco(TipoEspaco tipo){
            this.tipo = tipo;
            this.valor = DefinirPrecoEspaco(tipo);
        }

        //Metodos
        public double RetornarPrecoEspaco(){
            return valor;
        }

        private double DefinirPrecoEspaco(TipoEspaco tipo){
            switch(tipo){
                case TipoEspaco.ESPACO_A:
                case TipoEspaco.ESPACO_B:
                case TipoEspaco.ESPACO_C:
                case TipoEspaco.ESPACO_D:
                    return 10000;
                case TipoEspaco.ESPACO_E:
                case TipoEspaco.ESPACO_F:
                    return 17000;
                case TipoEspaco.ESPACO_G:
                    return 8000;
                case TipoEspaco.ESPACO_H:
                    return 38000;     
                default:
                    return 0;   
            }
        }
    }
}
