using IFatec.Factories;

namespace IFatec.Products.Italiana
{
    //Produto Concreto
    public class SodaItaliana : IBebida
    {
        public string BuscarDescrição()
        {
            return "SODA ITALIANA:\n Bebida refrescante à base de água gaseificada, gelo e xarope de frutas premium. Disponível em diversos sabores.\n";
        }
    }
}
