namespace WebApi
{
    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente infoCliente;
        private string estado;

        private int? idCadeteEncargado;

        public string Obs { get => obs; set => obs = value; }

        public string Estado { get => estado; set => estado = value; }
        public int Nro { get => nro; }
        public int? IdCadeteEncargado { get => idCadeteEncargado; set => idCadeteEncargado = value; }
        public Cliente InfoCliente { get => infoCliente; set => infoCliente = value; }

        public Pedido(int nro)
        {
            this.nro = nro;
            this.InfoCliente = CrearClienteAleatorio(); // Crear cliente aleatorio
            this.estado = "EnPreparacion";
            this.idCadeteEncargado = null;
        }

        public Cliente CrearClienteAleatorio()
        {
            Random random = new Random();
            string nombre = "Cliente" + random.Next(1, 100);
            string direccion = "Dirección" + random.Next(1, 100);
            string telefono = Convert.ToString(random.Next(100000000, 999999999));
            string datosReferenciaDireccion = "Referencia" + random.Next(1, 100);
            Cliente clienteNuevo = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
            return clienteNuevo;
        }
    }
}