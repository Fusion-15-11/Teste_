using IFatec.Factories;

namespace IFatec.Products.Japonesa
{
    //Produto Concreto

    public class Mochi : ISobremesa
    {
        public string BuscarDescrição()
        {
            return "MOCHI:\n Delicada massa japonesa de arroz glutinoso com textura macia e elástica. Recheado com pasta de feijão azuki ou sorvete.\n";
        }
    }
}
