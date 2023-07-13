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

                foreach (var comando in lista.Servidores)
                {
                    buttonLista.Click += (sender1, e1) =>
                    {
                        txtMetodos.Controls.Clear();
                        MostrarServidores(lista.Servidores);
                    };
                }

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

            }
            txtMetodos.Controls.Add(panelLista);
            txtMetodos.AppendText("\r\n");

        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            txtMetodos.Clear();
        }

        private void btnCargarComandos_Click(object sender, EventArgs e)
        {
            servidores = gestionServidores.CargarServidoresDesdeXml();

            txtLog.Clear();
            txtMetodos.Clear();

            foreach (var lista in servidores)
            {
                txtLog.AppendText($"Nombre de la lista de servidores: {lista.Nombre}\r\n");

                foreach (var servidor in lista.Servidores)
                {
                    txtLog.AppendText($"Servidor: {servidor.Nombre}\r\n");
                }

                txtLog.AppendText("\r\n");
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