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

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream("GestionServidores.Comandos.xml"))
            {
                XDocument xmlDoc = XDocument.Load(stream);

                foreach (var listaComandosElement in xmlDoc.Root.Elements("ListaComandos"))
                {
                    var nombreLista = (string)listaComandosElement.Attribute("Nombre");

                    ListaComandos lista = new ListaComandos();
                    lista.Nombre = nombreLista;
                    lista.Comandos = new List<string>();

                    foreach (var comandoElement in listaComandosElement.Elements("Comando"))
                    {
                        var comando = (string)comandoElement;
                        lista.Comandos.Add(comando);
                    }

                    listaComandos.Add(lista);
                }
            }
            return listaComandos;
        }
    }
    public class ListaComandos
    {
        public string Nombre { get; set; }
        public List<string> Comandos { get; set; }
    }
}

