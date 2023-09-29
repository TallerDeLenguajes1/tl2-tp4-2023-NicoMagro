namespace WebApi
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listaCadetes = new List<Cadete>();
        private int nroPedidosCreados;
        private List<Pedido> listaPedidos = new List<Pedido>();
        //private AccesoADatosCadeteria cargarCadeteria;
        private AccesoADatosPedido cargarPedidos;
        private AccesoADatosCadetes cargarCadetes;

        private Informe cadInforme = new Informe();

        public List<Cadete> ListaCadetes { get => listaCadetes; set => listaCadetes = value; }
        public int NroPedidosCreados { get => nroPedidosCreados; set => nroPedidosCreados = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListaPedidos { get => listaPedidos; set => listaPedidos = value; }
        public Informe CadInforme { get => cadInforme; set => cadInforme = value; }
        //public AccesoADatosCadeteria CargarCadeteria { get => cargarCadeteria; set => cargarCadeteria = value; }
        public AccesoADatosPedido CargarPedidos { get => cargarPedidos; set => cargarPedidos = value; }
        public AccesoADatosCadetes CargarCadetes { get => cargarCadetes; set => cargarCadetes = value; }
        private static Cadeteria instance;  //Campo privado llamado instancia del tipo cadeteria

        public static Cadeteria Instance
        {
            get
            {
                if (instance == null)
                {
                    AccesoADatosCadeteria CargarCadeteria = new AccesoCadeteriaJSON();
                    instance = CargarCadeteria.Obtener();

                    instance.CargarCadetes = new AccesoADatosCadetesJSON();
                    instance.ListaCadetes = instance.CargarCadetes.Obtener();

                    instance.CargarPedidos = new AccesoADatosPedidoJSON();
                    instance.ListaPedidos = instance.CargarPedidos.Obtener();
                }
                return instance;
            }
        }

        public Cadeteria(string nombre, string telefono, int nroPedidosCreados)
        {
            this.nombre = nombre;
            this.telefono = telefono;
            this.nroPedidosCreados = nroPedidosCreados;
            this.listaCadetes = new List<Cadete>();
        }


        public void AgregarPedido()
        {
            Pedido nuevoPedido = new Pedido(nroPedidosCreados + 1);
            NroPedidosCreados += 1;
            listaPedidos.Add(nuevoPedido);
        }

        public void AsignarPedido(int idPedido, int idCadete)
        {
            Cadete cadeteBuscado = listaCadetes.FirstOrDefault(cadete => cadete.Id == idCadete);
            if (cadeteBuscado != null)
            {
                Pedido pedidoBuscado = ListaPedidos.FirstOrDefault(pedido => pedido.Nro == idPedido);
                if (pedidoBuscado != null)
                {
                    //Si el pedido no tiene cadete asignado lo agrega
                    if (pedidoBuscado.IdCadeteEncargado == null)
                    {
                        pedidoBuscado.IdCadeteEncargado = idCadete;
                    }
                }

            }
        }
        public void CambiarCadetePedido(int idPedido, int idCadete)
        {
            Cadete cadeteBuscado = listaCadetes.FirstOrDefault(cadete => cadete.Id == idCadete);
            if (cadeteBuscado != null)
            {
                Pedido pedidoBuscado = ListaPedidos.FirstOrDefault(pedido => pedido.Nro == idPedido);
                if (pedidoBuscado != null)
                {
                    pedidoBuscado.IdCadeteEncargado = idCadete;
                }
            }
        }

        public void CambiarEstadoPedido(int idPedido, int estado)
        {
            Pedido pedidoEncontrado = listaPedidos.FirstOrDefault(pedido => pedido.Nro == idPedido);

            if (pedidoEncontrado != null)
            {
                string nuevoEstado = "";

                switch (estado)
                {
                    case 1:
                        nuevoEstado = "Pendiente";
                        break;
                    case 2:
                        nuevoEstado = "EnCamino";
                        break;
                    case 3:
                        nuevoEstado = "Entregado";
                        break;
                    default:
                        return;
                }
                pedidoEncontrado.Estado = nuevoEstado;

            }
        }
        public void EliminarPedido(int idPedido)
        {
            Pedido pedidoEncontrado = ListaPedidos.FirstOrDefault(pedido => pedido.Nro == idPedido);
            if (pedidoEncontrado != null)
            {
                ListaPedidos.Remove(pedidoEncontrado);
            }
        }
        public double JornalACobrar(int idCadete)
        {
            double cantPedidosEntregados = 0;
            foreach (Pedido pedido in ListaPedidos)
            {
                if (pedido.IdCadeteEncargado == idCadete && pedido.Estado == "Entregado")
                {
                    cantPedidosEntregados++;
                }
            }
            return 500 * cantPedidosEntregados;
        }
        public void CrearInforme()
        {
            var nuevoInforme = new Informe(this.listaPedidos, this.ListaCadetes);
            CadInforme = nuevoInforme;
        }
    }
}