using GestionServidores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
                    EditarServidorForm editarServidorForm = new EditarServidorForm(servidor, servidores,this.gestionServidores);
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
            if (botonSeleccionado != null)
            {
                var servidorNombre = botonSeleccionado.Text;
                var servidor = servidores.SelectMany(l => l.Servidores).FirstOrDefault(s => s.Nombre == servidorNombre);

                if (servidor != null)
                {
                    var metodoBorrar = servidor.MetodoBorrar;
                    var metodoEjecutar = servidor.MetodoEjecutar;

                    if (!string.IsNullOrEmpty(metodoBorrar.Carpeta) && !string.IsNullOrEmpty(metodoBorrar.Comando))
                    {
                        string carpetaBorrar = metodoBorrar.Carpeta;
                        string comandoBorrar = metodoBorrar.Comando;

                        // Ejecutar el comando de borrado en la carpeta especificada
                        EjecutarComandoBorrado(carpetaBorrar, comandoBorrar);
                    }

                    if (!string.IsNullOrEmpty(metodoEjecutar.Carpeta) && !string.IsNullOrEmpty(metodoEjecutar.Comando))
                    {
                        string carpetaEjecutar = metodoEjecutar.Carpeta;
                        string comandoEjecutar = metodoEjecutar.Comando;

                        // Ejecutar el comando de ejecución en la carpeta especificada
                        EjecutarComando(carpetaEjecutar, comandoEjecutar);
                    }
                }
            }
        }

        private void EjecutarComando(string carpeta, string comando)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/c {comando}";
                startInfo.WorkingDirectory = carpeta;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    // Puedes hacer algo con la salida del comando si lo necesitas
                    // Por ejemplo, mostrarlo en un TextBox o en un MessageBox
                    // txtOutput.Text = output;
                    MessageBox.Show(error);

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el comando: {ex.Message}");
            }
        }
        private void EjecutarComandoBorrado(string carpeta, string comando)
        {
            try
            {
                string comandoConRuta = $"{comando}\"{carpeta}\"";

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = $"/c {comandoConRuta}";

                // Utilizar una carpeta temporal o una carpeta válida para el WorkingDirectory
                startInfo.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
                    process.Start();

                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    MessageBox.Show(output);

                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al ejecutar el comando: {ex.Message}");
            }
        }

    }
}