using GestionServidores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GestionServidores.GestionServidores;

namespace InterfazGestionServidores
{
    public partial class Form1 : Form
    {
        private List<ListaServidores> servidores;
        private GestionServidores.GestionServidores gestionServidores;
        private Button botonSeleccionado;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gestionServidores = new GestionServidores.GestionServidores();
            servidores = gestionServidores.CargarServidoresDesdeXml();
            var panelLista = new FlowLayoutPanel();
            panelLista.FlowDirection = FlowDirection.TopDown;
            panelLista.AutoSize = true;

            var cont = servidores.Count;
            foreach (var lista in servidores)
            {
                var buttonLista = new Button();
                buttonLista.Text = lista.Nombre;
                buttonLista.AutoSize = true;

                panelLista.Controls.Add(buttonLista);

                buttonLista.Click += (sender1, e1) =>
                {
                    txtMetodos.Controls.Clear();
                    MostrarServidores(lista.Servidores);
                };

                txtLog.Controls.Add(panelLista);
                txtLog.AppendText("\r\n");
            }
        }

        private void MostrarServidores(List<Servidor> servidores)
        {
            txtMetodos.Clear();
            var panelLista = new FlowLayoutPanel();
            panelLista.FlowDirection = FlowDirection.TopDown;
            panelLista.AutoSize = true;
            foreach (var servidor in servidores)
            {
               
                var buttonServidor = new Button();
                buttonServidor.Text = servidor.Nombre;
                buttonServidor.AutoSize = true;
                panelLista.Controls.Add(buttonServidor);

                buttonServidor.Click += (sender, e) =>
                {
                    botonSeleccionado = (Button)sender;
                    var metodoEjecutar = servidor.MetodoEjecutar;
                    var metodoBorrar = servidor.MetodoBorrar;

                    txtInfo.Clear();
                    txtInfo.AppendText($"Método Ejecutar:\r\n");
                    txtInfo.AppendText($"Carpeta: {metodoEjecutar.Carpeta}\r\n");
                    txtInfo.AppendText($"Comando: {metodoEjecutar.Comando}\r\n");

                    txtInfo.AppendText($"\r\n");

                    txtInfo.AppendText($"Método Borrar:\r\n");
                    txtInfo.AppendText($"Carpeta: {metodoBorrar.Carpeta}\r\n");
                    txtInfo.AppendText($"Comando: {metodoBorrar.Comando}\r\n");
                };
            }
            txtMetodos.Controls.Add(panelLista);
            txtMetodos.AppendText("\r\n");

        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            txtMetodos.Clear();
        }

        private void btnEditarServidor_Click(object sender, EventArgs e)
        {
            if (botonSeleccionado != null)
            {
                var servidorNombre = botonSeleccionado.Text;
                var servidor = servidores.SelectMany(l => l.Servidores).FirstOrDefault(s => s.Nombre == servidorNombre);

                if (servidor != null)
                {
                    EditarServidorForm editarServidorForm = new EditarServidorForm(servidor, servidores);
                    editarServidorForm.ShowDialog();

                    // Actualizar los datos del servidor en el txtInfo después de cerrar el formulario de edición
                    var metodoEjecutar = servidor.MetodoEjecutar;
                    var metodoBorrar = servidor.MetodoBorrar;

                    txtInfo.Clear();
                    txtInfo.AppendText($"Método Ejecutar:\r\n");
                    txtInfo.AppendText($"Carpeta: {metodoEjecutar.Carpeta}\r\n");
                    txtInfo.AppendText($"Comando: {metodoEjecutar.Comando}\r\n");

                    txtInfo.AppendText($"\r\n");

                    txtInfo.AppendText($"Método Borrar:\r\n");
                    txtInfo.AppendText($"Carpeta: {metodoBorrar.Carpeta}\r\n");
                    txtInfo.AppendText($"Comando: {metodoBorrar.Comando}\r\n");

                    // Guardar los servidores en el archivo XML
                    GestionServidores.GestionServidores gestionServidores = new GestionServidores.GestionServidores();
                    gestionServidores.GuardarServidoresEnXml(servidores);

                    // Recargar los servidores desde el archivo XML
                    servidores = gestionServidores.CargarServidoresDesdeXml();

                    // Actualizar los datos en txtLog y txtMetodos
                    txtLog.Clear();
                    txtMetodos.Clear();
                }
            }
        }


        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (txtLog.SelectionLength > 0)
            {
                string selectedCommand = txtLog.SelectedText.Trim();

                if (!string.IsNullOrEmpty(selectedCommand))
                {
                    ListaServidores listaServidores = servidores.FirstOrDefault(l => l.Nombre == selectedCommand);

                    if (listaServidores != null)
                    {
                        // Ejecuta el método de ejecución del servidor seleccionado
                    }
                }
            }
        }
    }
}
