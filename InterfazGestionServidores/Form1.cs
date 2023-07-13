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
        private List<ListaComandos> comandos;
        private GestionServidores.GestionServidores gestionServidores;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gestionServidores = new GestionServidores.GestionServidores();
            comandos = gestionServidores.CargarComandosDesdeXml();
            txtLog.AppendText($"Nombre de la lista de comandos:");
            foreach (var lista in comandos)
            {
                txtLog.AppendText($"Nombre de la lista de comandos: {lista.Nombre}\r\n");

                foreach (var comando in lista.Comandos)
                {
                    txtLog.AppendText($"Comando: {comando.Nombre}\r\n");
                }

                txtLog.AppendText("\r\n");
            }
        }

        private void txtLog_TextChanged(object sender, EventArgs e)
        {
            txtMetodos.Clear();
        }

        private void txtLog_SelectionChanged(object sender, EventArgs e)
        {
            if (txtLog.SelectionLength > 0)
            {
                string selectedCommand = txtLog.SelectedText.Trim();

                if (!string.IsNullOrEmpty(selectedCommand))
                {
                    ListaComandos listaComandos = comandos.FirstOrDefault(l => l.Nombre == selectedCommand);

                    if (listaComandos != null)
                    {
                        foreach (var comando in listaComandos.Comandos)
                        {
                            txtMetodos.AppendText($"Método: {comando.Nombre}\r\n");
                        }
                    }
                }
            }
        }

        private void btnCargarComandos_Click(object sender, EventArgs e)
        {
            comandos = gestionServidores.CargarComandosDesdeXml();

            foreach (var lista in comandos)
            {
                txtLog.AppendText($"Nombre de la lista de comandos: {lista.Nombre}\r\n");

                foreach (var comando in lista.Comandos)
                {
                    txtLog.AppendText($"Comando: {comando.Nombre}\r\n");
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
                    ListaComandos listaComandos = comandos.FirstOrDefault(l => l.Nombre == selectedCommand);

                    if (listaComandos != null)
                    {
                        string selectedMethod = txtMetodos.SelectedText.Trim();

                        if (!string.IsNullOrEmpty(selectedMethod))
                        {
                            // ComandoGenerico comando = listaComandos.Comandos.FirstOrDefault(c => c.Nombre == selectedMethod);

                            // if (comando != null)
                            // {
                            //     comando.Ejecutar();
                            // }
                        }
                    }
                }
            }
        }

  
    }
}
