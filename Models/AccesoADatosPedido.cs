namespace WebApi
{
    using System.Text.Json;

    public abstract class AccesoADatosPedido
    {
        public List<Pedido> ListaPedidos = new List<Pedido>();
        public abstract List<Pedido> Obtener();
    }

    public class AccesoADatosPedidoCSV : AccesoADatosPedido
    {
        public override List<Pedido> Obtener()
        {
            try
            {
                using (StreamReader reader = new StreamReader("pedido.csv"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        int numeroPedido = int.Parse(line);

                        Pedido pedido = new Pedido(numeroPedido);
                        ListaPedidos.Add(pedido);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return ListaPedidos;
        }
    }

    public class AccesoADatosPedidoJSON : AccesoADatosPedido
    {
        public override List<Pedido> Obtener()
        {
            string contenido = File.ReadAllText("pedidos.json");
            ListaPedidos = JsonSerializer.Deserialize<List<Pedido>>(contenido);

            return ListaPedidos;
        }
    }
}