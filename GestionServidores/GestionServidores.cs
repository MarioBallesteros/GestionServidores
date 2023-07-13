using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GestionServidores
{
    public class GestionServidores
    {
        public List<ListaComandos> CargarComandosDesdeXml()
        {
            List<ListaComandos> listaComandos = new List<ListaComandos>();


            // Accede al archivo XML
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("GestionServidores.Comandos.xml"))
            {
                // Carga el archivo XML en un objeto XDocument
                XDocument xmlDoc = XDocument.Load(stream);

                // Obtiene la lista de comandos del XML
                foreach (var elementoListaComandos in xmlDoc.Root.Elements("ListaComandos"))
                {
                    ListaComandos lista = new ListaComandos();
                    lista.Nombre = elementoListaComandos.Attribute("NombreLista")?.Value;
                    lista.Comandos = new List<Comando>();

                    foreach (var elementoComando in elementoListaComandos.Elements("Comando"))
                    {
                        Comando comando = new Comando();
                        comando.Nombre = elementoComando.Attribute("Nombre")?.Value;

                        lista.Comandos.Add(comando);
                    }

                    listaComandos.Add(lista);
                }
                return listaComandos;
            }
        }
        public class ListaComandos
        {
            public string Nombre { get; set; }
            public List<Comando> Comandos { get; set; }
        }
    }
}