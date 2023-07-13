using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace GestionServidores
{
    public class GestionServidores
    {
        public List<ListaServidores> CargarServidoresDesdeXml()
        {
            List<ListaServidores> listaServidores = new List<ListaServidores>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("GestionServidores.Servidores.xml"))
            {
                XDocument xmlDoc = XDocument.Load(stream);

                foreach (var elementoListaServidores in xmlDoc.Root.Elements("ListaServidores"))
                {
                    ListaServidores lista = new ListaServidores();
                    lista.Nombre = elementoListaServidores.Attribute("NombreLista")?.Value;
                    lista.Servidores = new List<Servidor>();

                    foreach (var elementoServidor in elementoListaServidores.Elements("Servidor"))
                    {
                        Servidor servidor = new Servidor();
                        servidor.Nombre = elementoServidor.Attribute("Nombre")?.Value;
                        servidor.MetodoEjecutar = new Metodo();
                        servidor.MetodoBorrar = new Metodo();

                        var elementoMetodoEjecutar = elementoServidor.Element("MetodoEjecutar");
                        if (elementoMetodoEjecutar != null)
                        {
                            servidor.MetodoEjecutar.Carpeta = elementoMetodoEjecutar.Element("Carpeta")?.Value;
                            servidor.MetodoEjecutar.Comando = elementoMetodoEjecutar.Element("Comando")?.Value;
                        }

                        var elementoMetodoBorrar = elementoServidor.Element("MetodoBorrar");
                        if (elementoMetodoBorrar != null)
                        {
                            servidor.MetodoBorrar.Carpeta = elementoMetodoBorrar.Element("Carpeta")?.Value;
                            servidor.MetodoBorrar.Comando = elementoMetodoBorrar.Element("Comando")?.Value;
                        }

                        lista.Servidores.Add(servidor);
                    }

                    listaServidores.Add(lista);
                }
            }

            return listaServidores;
        }

        public class ListaServidores
        {
            public string Nombre { get; set; }
            public List<Servidor> Servidores { get; set; }
        }

        public class Servidor
        {
            public string Nombre { get; set; }
            public Metodo MetodoEjecutar { get; set; }
            public Metodo MetodoBorrar { get; set; }
        }

        public class Metodo
        {
            public string Carpeta { get; set; }
            public string Comando { get; set; }
        }
    }
}
