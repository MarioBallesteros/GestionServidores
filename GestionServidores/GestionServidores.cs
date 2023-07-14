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

        public void GuardarServidoresEnXml(List<ListaServidores> listaServidores)
        {
            XDocument xmlDoc = new XDocument();
            XElement root = new XElement("Servidores");

            foreach (var lista in listaServidores)
            {
                XElement elementoListaServidores = new XElement("ListaServidores");
                elementoListaServidores.SetAttributeValue("NombreLista", lista.Nombre);

                foreach (var servidor in lista.Servidores)
                {
                    XElement elementoServidor = new XElement("Servidor");
                    elementoServidor.SetAttributeValue("Nombre", servidor.Nombre);

                    XElement elementoMetodoEjecutar = new XElement("MetodoEjecutar");
                    elementoMetodoEjecutar.Add(new XElement("Carpeta", servidor.MetodoEjecutar.Carpeta));
                    elementoMetodoEjecutar.Add(new XElement("Comando", servidor.MetodoEjecutar.Comando));
                    elementoServidor.Add(elementoMetodoEjecutar);

                    XElement elementoMetodoBorrar = new XElement("MetodoBorrar");
                    elementoMetodoBorrar.Add(new XElement("Carpeta", servidor.MetodoBorrar.Carpeta));
                    elementoMetodoBorrar.Add(new XElement("Comando", servidor.MetodoBorrar.Comando));
                    elementoServidor.Add(elementoMetodoBorrar);

                    elementoListaServidores.Add(elementoServidor);
                }

                root.Add(elementoListaServidores);
            }

            xmlDoc.Add(root);
            xmlDoc.Save("Servidores.xml");
        }
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