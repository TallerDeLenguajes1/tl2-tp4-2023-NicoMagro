namespace WebApi
{
    using System.Text.Json;
    using System.Text.Json.Serialization;
    public abstract class AccesoADatos
    {
        public Cadeteria cadeteria = null;
        public abstract Cadeteria CargarInfoCadeteria();
    }

    public class AccesoCsv : AccesoADatos
    {
        public override Cadeteria CargarInfoCadeteria()
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
                    cadeteria.ListaCadetes = CargarCadetes();
                }
            }
            catch (IOException ex)
            {
            }
            return cadeteria;
        }

        public List<Cadete> CargarCadetes()
        {
            List<Cadete> cadetes = new List<Cadete>();

            try
            {
                using (StreamReader reader = new StreamReader("cadetes.csv"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] datosCadete = line.Split(',');
                        int id = int.Parse(datosCadete[0]);
                        string nombre = datosCadete[1];
                        string direccion = datosCadete[2];
                        string telefono = datosCadete[3];

                        Cadete cadete = new Cadete(id, nombre, direccion, telefono);
                        cadetes.Add(cadete);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return cadetes;
        }

    }
    public class AccesoJson : AccesoADatos
    {
        public override Cadeteria CargarInfoCadeteria()
        {
            string contenido = File.ReadAllText("Models/cadeteria.json");
            cadeteria = JsonSerializer.Deserialize<Cadeteria>(contenido);

            return cadeteria;
        }
    }
}