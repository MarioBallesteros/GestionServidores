using GestionServidores;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace InterfazGestionServidores
{
    public partial class EditarServidorForm : Form
    {
        private Servidor servidor;
        private List<ListaServidores> listaServidores;
        private GestionServidores.GestionServidores gestionServidores;

        public EditarServidorForm(Servidor servidor,List<ListaServidores> listaServidores, GestionServidores.GestionServidores gestionServidores)
        {
            InitializeComponent();
            this.servidor = servidor;
            this.gestionServidores = gestionServidores;
            this.listaServidores = listaServidores;
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

            // Guardar los cambios en el archivo XML
            gestionServidores.GuardarServidoresEnXml(listaServidores);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            gestionServidores.GuardarServidoresEnXml(listaServidores);
            Close();
        }
    }
}
