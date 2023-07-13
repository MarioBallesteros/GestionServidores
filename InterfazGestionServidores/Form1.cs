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

            var panelLista = new FlowLayoutPanel();
            panelLista.FlowDirection = FlowDirection.TopDown;
            panelLista.AutoSize = true;

            foreach (var lista in comandos)
            {
                var labelLista = new Label();
                labelLista.Text = $"Lista de comandos: {lista.Nombre}";
                labelLista.AutoSize = true;

                panelLista.Controls.Add(labelLista);

                foreach (var comando in lista.Comandos)
                {
                    var buttonComando = new Button();
                    buttonComando.Margin = new Padding(20, 5, 0, 0); // Ajustar los margenes aquí
                    buttonComando.Text = $"{comando.Nombre.ToString()}";
                    buttonComando.AutoSize = true;

                    buttonComando.Click += (sender1, e1) =>
                    {
                        txtMetodos.Controls.Clear();

                        var buttonMetodoEjecutar = new Button();
                        buttonMetodoEjecutar.Text = "Ejecutar";
                        buttonMetodoEjecutar.AutoSize = true;
                        buttonMetodoEjecutar.Click += (sender2, e2) =>
                        {
                            comando.Ejecutar();
                        };

                        var buttonMetodoBorrar = new Button();
                        buttonMetodoBorrar.Text = "Borrar";
                        buttonMetodoBorrar.AutoSize = true;
                        buttonMetodoBorrar.Click += (sender2, e2) =>
                        {
                            comando.Borrar();
                        };

                        txtMetodos.Controls.Add(buttonMetodoEjecutar);
                        txtMetodos.Controls.Add(buttonMetodoBorrar);
                    };

                    panelLista.Controls.Add(buttonComando);
                }

                txtLog.Controls.Add(panelLista);
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
                        txtMetodos.Controls.Clear();

                        foreach (var comando in listaComandos.Comandos)
                        {
                            var buttonMetodoEjecutar = new Button();
                            buttonMetodoEjecutar.Text = "Ejecutar";
                            buttonMetodoEjecutar.Click += (sender1, e1) =>
                            {
                                comando.Ejecutar();
                            };
                            txtMetodos.Controls.Add(buttonMetodoEjecutar);
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
                            Comando comando = listaComandos.Comandos.FirstOrDefault(c => c.Nombre == selectedMethod);

                            if (comando != null)
                            {
                                comando.Ejecutar();
                            }
                        }
                    }
                }
            }
        }
    }
}