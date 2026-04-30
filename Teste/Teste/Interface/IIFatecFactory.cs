namespace IFatec.Factories
{
    
    // Abstract Factory
    public interface IIFatecFactory
    {
        IBebida BuscarBebida();
        IPratoPrincipal BuscarPratoPrincipal();
        ISobremesa BuscarSobremesa();
    }
}
