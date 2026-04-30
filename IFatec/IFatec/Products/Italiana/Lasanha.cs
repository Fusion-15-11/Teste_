using IFatec.Factories;

namespace IFatec.Products.Italiana
{
    //Produto Concreto
    public class Lasanha : IPratoPrincipal
    {
        public void RetirarIngrediente(string ingrediente)
        {
            _ingredienteRemovido = ingrediente;
        }
        public string BuscarDescrição()
        {
            string descricao = "LASANHA:\n Massa de ovos, molho bolonhesa rico em sabor, bechamel cremoso e muçarela. Gratinada com parmesão ralado na hora.\n";

            // Se o usuário digitou algo para remover, adicionamos um aviso na descrição
            if (!string.IsNullOrEmpty(_ingredienteRemovido))
            {
                descricao += $" [Modificação: Sem {_ingredienteRemovido}]";
            }

            return descricao;

        }

        private string _ingredienteRemovido = "";

       
    }
}
