using IFatec.Factories;

namespace IFatec.Products.Japonesa
{
    //Produto Concreto

    public class Yakisoba : IPratoPrincipal
    {
        private string _ingredienteRemovido = "";

        public void RetirarIngrediente(string ingrediente)
        {
            _ingredienteRemovido = ingrediente;
        }
        public string BuscarDescrição()
        {
            string descricao = "YAKISOBA:\n Macarrão selado na chapa com mix de legumes frescos, carnes [bovina e frango] e molho à base de shoyu e especiarias orientais.\n";

            if (!string.IsNullOrEmpty(_ingredienteRemovido))
            {
                descricao += $" [Modificação: Sem {_ingredienteRemovido}]";
            }

            return descricao;
        }
    }
}
