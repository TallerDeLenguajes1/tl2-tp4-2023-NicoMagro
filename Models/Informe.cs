namespace WebApi
{
    public class Informe
    {
        private int montoTotalGanado;
        private int totalEnvios;
        private double promedioEnviosXCadete;
        public int MontoTotalGanado { get => montoTotalGanado; set => montoTotalGanado = value; }
        public int TotalEnvios { get => totalEnvios; set => totalEnvios = value; }
        public double PromedioEnviosXCadete { get => promedioEnviosXCadete; set => promedioEnviosXCadete = value; }

        public Informe()
        {
        }
        public Informe(List<Pedidos> ListaPedidos, List<Cadete> ListaCadetes)
        {

            foreach (Pedidos pedido in ListaPedidos)
            {
                if (pedido.Estado == "Entregado")
                {
                    totalEnvios++;
                }
            }
            MontoTotalGanado = TotalEnvios * 500;
            if (ListaCadetes != null)
            {
                PromedioEnviosXCadete = TotalEnvios / ListaCadetes.Count;
            }
        }

    }

}