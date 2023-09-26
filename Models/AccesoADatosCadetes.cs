namespace WebApi
{
    using System.Text.Json;
    public abstract class AccesoADatosCadetes
    {
        public List<Cadete> ListaCadetes = new List<Cadete>();

        public abstract List<Cadete> Obtener();

        public void Guardar(Cadeteria _cadeteria)
        {
            _cadeteria.ListaCadetes = ListaCadetes;
        }
    }

    public class AccesoADatosCadetesCSV : AccesoADatosCadetes
    {
        public override List<Cadete> Obtener()
        {
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
                        ListaCadetes.Add(cadete);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return ListaCadetes;
        }
    }

    public class AccesoADatosCadetesJSON : AccesoADatosCadetes
    {
        public override List<Cadete> Obtener()
        {
            string contenido = File.ReadAllText("Models/cadetes.json");
            ListaCadetes = JsonSerializer.Deserialize<List<Cadete>>(contenido);

            return ListaCadetes;
        }
    }
}