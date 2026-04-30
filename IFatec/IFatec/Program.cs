/*using IFatec;
using IFatec.Factories;

namespace IFatec
{
    class Program
    {
        static void Main(string[] args)
        {
            IIFatecFactory pedidoItaliano = new FactoryItaliana();
            Cliente italianoCliente = new Cliente(pedidoItaliano);

            Console.WriteLine("**PEDIDO ITALIANO**");
            Console.WriteLine(italianoCliente.BuscarDescricaoPratoPrincipal());
            Console.WriteLine(italianoCliente.BuscarDescricaoSobremesa());
            Console.WriteLine(italianoCliente.BuscarDescricaoBebida());

            IIFatecFactory pedidoJapones = new FactoryJaponesa();
            Cliente japonesCliente = new Cliente(pedidoJapones);

            Console.WriteLine("**PEDIDO JAPONES**");
            Console.WriteLine(japonesCliente.BuscarDescricaoPratoPrincipal());
            Console.WriteLine(japonesCliente.BuscarDescricaoSobremesa());
            Console.WriteLine(japonesCliente.BuscarDescricaoBebida());

            Console.ReadKey();



        }
    }
}

*/

using IFatec.Factories;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();

// ESTA LINHA ABAIXO resolve o erro 404 na página inicial:
app.MapGet("/", context => {
    context.Response.Redirect("/Index");
    return Task.CompletedTask;
});

//Memento
class Pedido //Originator seria uma classe mãe, que utiliza
{
    private string PratoPrincipal; //Declara as varáveis
    private string Sobremesa;
    private string Bebida;
    private DateTime Data;

    public Pedido(string pratoPrincipal, string sobremesa, string bebida, DateTime data_hora)
    {
        this.PratoPrincipal = pratoPrincipal;
        this.Sobremesa = sobremesa;
        this.Bebida = bebida;
        this.Data = data_hora;

        Console.WriteLine("Pedido:\n\n" + PratoPrincipal + Sobremesa + Bebida + Data);
    }

    public IDado_Pedido Save()
    {
        return new Ticket(PratoPrincipal, Sobremesa, Bebida, Data);
    }

    public void Restore(IDado_Pedido dadopedido)
    {
        if (!(dadopedido is Ticket))
        {
            throw new Exception("Pedido Desconhecido: " + dadopedido.ToString());
        }
        this.PratoPrincipal = dadopedido.GetPratoPrincipal();
        this.Sobremesa = dadopedido.GetSobremesa();
        this.Bebida = dadopedido.GetBebida();
        this.Data = dadopedido.GetData();
        Console.Write($"Pedido Mudou Para:\n\n Prato Principal: {PratoPrincipal}\n Sobremesa: {Sobremesa}\n Bebida: {Bebida}");
    }

    public interface IDado_Pedido
    {
        string GetPratoPrincipal();
        string GetSobremesa();
        string GetBebida();
        DateTime GetData();
    }

    class Ticket : IDado_Pedido //Memento
    {
        private string PratoPrincipal;
        private string Sobremesa;
        private string Bebida;
        private DateTime Data;

        public Ticket(string pratoPrincipal, string sobremesa, string bebida, DateTime data_hora)
        {
            this.PratoPrincipal = pratoPrincipal;
            this.Sobremesa = sobremesa;
            this.Bebida = bebida;
            this.Data = DateTime.Now;
        }

        public string GetPratoPrincipal()
        {
            return this.PratoPrincipal;
        }
        public string GetSobremesa()
        {
            return this.Sobremesa;
        }

        public string GetBebida()
        {
            return this.Bebida;
        }

        public DateTime GetData()
        {
            return this.Data;
        }
    }

    class Historico //Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();

        private Originator _originator = null;

        public Caretaker(Originator originator)
        {
            this._originator = originator;
        }

        public void Backup()
        {
            Console.WriteLine("\nCaretaker: Saving Originator's state...");
            this._mementos.Add(this._originator.Save());
        }

        public void Undo()
        {
            if (this._mementos.Count == 0)
            {
                return;
            }

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            Console.WriteLine("Caretaker: Restoring state to: " + memento.GetName());

            try
            {
                this._originator.Restore(memento);
            }
            catch (Exception)
            {
                this.Undo();
            }
        }

        public void ShowHistory()
        {
            Console.WriteLine("Caretaker: Here's the list of mementos:");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
}


app.Run();