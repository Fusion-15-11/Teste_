using IFatec.Products.Japonesa;

namespace IFatec.Factories
{
    public class FactoryJaponesa : IIFatecFactory
    {
        public IBebida BuscarBebida()
        {
            return new Saque();
        }

        public IPratoPrincipal BuscarPratoPrincipal()
        {
            return new Yakisoba();
        }

        public ISobremesa BuscarSobremesa()
        {
            return new Mochi();
        }
    }
}
