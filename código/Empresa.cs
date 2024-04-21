using System;
using System.Collections.Generic;
class Empresa {
    //Atributo 
    private List<Cerimonia> cerimonia;
    public Empresa(){
        this.cerimonia = new List<Cerimonia>(); 
    }

    //Métodos
    public void ListarCerimonias(){
        if(cerimonia.Count() !=0 ){
            for(int i = 0; i < cerimonia.Count(); i++){
                Console.WriteLine("Cerimonia: "+(i+1)+"");
            }
        }
        else{
            Console.WriteLine("Não possuí cerimonias cadastradas.");
        }
    }
}