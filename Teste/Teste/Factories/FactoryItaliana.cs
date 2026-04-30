using IFatec.Products.Italiana;

namespace IFatec.Factories
{
    public class FactoryItaliana : IIFatecFactory
    {
        public IBebida BuscarBebida()
        {
            return new SodaItaliana();
        }

        public IPratoPrincipal BuscarPratoPrincipal()
        {
            return new Lasanha();
        }

        public ISobremesa BuscarSobremesa()
        {
            return new Tiramisu();
        }
    }
}
