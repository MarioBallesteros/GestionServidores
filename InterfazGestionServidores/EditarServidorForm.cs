using GestionServidores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static GestionServidores.GestionServidores;

namespace InterfazGestionServidores
{
    public partial class EditarServidorForm : Form
    {
        private Servidor servidor;
        private List<ListaServidores> servidores;

        public EditarServidorForm(Servidor servidor, List<ListaServidores> servidores)
        {
            InitializeComponent();
            this.servidor = servidor;
            this.servidores = servidores;
            CargarDatosServidor();
        }

        private void CargarDatosServidor()
        {
            txtNombre.Text = servidor.Nombre;
            txtCarpetaEjecutar.Text = servidor.MetodoEjecutar.Carpeta;
            txtComandoEjecutar.Text = servidor.MetodoEjecutar.Comando;
            txtCarpetaBorrar.Text = servidor.MetodoBorrar.Carpeta;
            txtComandoBorrar.Text = servidor.MetodoBorrar.Comando;
        }

        private void GuardarCambios()
        {
            servidor.Nombre = txtNombre.Text;
            servidor.MetodoEjecutar.Carpeta = txtCarpetaEjecutar.Text;
            servidor.MetodoEjecutar.Comando = txtComandoEjecutar.Text;
            servidor.MetodoBorrar.Carpeta = txtCarpetaBorrar.Text;
            servidor.MetodoBorrar.Comando = txtComandoBorrar.Text;

            // Guardar los servidores actualizados en el archivo XML
            GestionServidores.GestionServidores gestionServidores = new GestionServidores.GestionServidores();
            gestionServidores.GuardarServidoresEnXml(servidores);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            Close();
        }
    }
}
