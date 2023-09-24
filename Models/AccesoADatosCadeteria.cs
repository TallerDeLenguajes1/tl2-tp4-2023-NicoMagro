namespace WebApi
{
    using System.Text.Json;
    public abstract class AccesoADatosCadeteria
    {
        public Cadeteria cadeteria = null;
        public abstract Cadeteria Obtener();
    }

    public class AccesoCadeteriaCSV : AccesoADatosCadeteria
    {
        public override Cadeteria Obtener()
        {
            try
            {
                using (StreamReader reader = new StreamReader("cadeteria.csv"))
                {
                    string[] datos = reader.ReadLine().Split(',');
                    string Nombre = datos[0];
                    string Telefono = datos[1];
                    int NroPedidosCreados = int.Parse(datos[2]);
                    cadeteria = new Cadeteria(Nombre, Telefono, NroPedidosCreados);
                }
            }
            catch (IOException ex)
            {
            }
            return cadeteria;
        }
    }

    public class AccesoCadeteriaJSON : AccesoADatosCadeteria
    {
        public override Cadeteria Obtener()
        {
            string contenido = File.ReadAllText("Models/cadeteria.json");
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(contenido);

            return cadeteria;
        }
    }
}