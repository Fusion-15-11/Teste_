using IFatec.Factories;

namespace IFatec.Products.Italiana
{
    //Produto Concreto
    public class Tiramisu : ISobremesa
    {
        public string BuscarDescrição()
        {
            return "TIRAMISU:\n Sobremesa italiana à base de biscoitos ingleses embebidos em café espresso, camadas cremosas de queijo mascarpone e finalizada com cacau em pó polvilhado.\n";
        }
    }
}
