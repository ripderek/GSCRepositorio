using AppFacturacion2024.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFacturacion2024
{
    public partial class CrearEditarClientes : Form
    {
        Clientes objCliente = new Clientes();
        private bool accion_ = false;
        //si la accion es true entonces se va a crear el cliente 
        //si la accion es falsa entonces se va a editar el cliente 
        public CrearEditarClientes(bool accion,string IDENTIFICACION = "", string NOMBRES="", string CORREO = "", string TELEFONO = "")
        {
            InitializeComponent();
            this.KeyPreview = true;

            if (accion)

                lblEtiqueta.Text = "Crear Cliente";
            else
            {
                txtAceptar.Text = "Editar";
                txtCodigoCliente.Visible = true;
                lblEtiqueta.Text = "Editar Cliente";
                txtIdentificacion.Visible = false;
                lblIdentificacion.Visible = false;
                txtCodigoCliente.Text = IDENTIFICACION;
                txtIdentificacion.Text = IDENTIFICACION;
                txtNombres.Text = NOMBRES;
                txtCorreo.Text = CORREO;
                txtTelefono.Text = TELEFONO;
            }
               
            accion_ = accion;
            //darle los eventos a los txt 
            txtIdentificacion.KeyDown += new KeyEventHandler(TeclaEnter);
            txtNombres.KeyDown += new KeyEventHandler(TeclaEnter);
            txtCorreo.KeyDown += new KeyEventHandler(TeclaEnter);
            txtTelefono.KeyDown += new KeyEventHandler(TeclaEnter);

        }
        private void TeclaEnter(object sender, KeyEventArgs e) 
        {
            //txtAceptar_Click
            if (e.KeyCode == Keys.Enter)
            {
                CrearEditarCliente();

            }
        }

        private void txtAceptar_Click(object sender, EventArgs e)
        {
            CrearEditarCliente();
        }
        private void CrearEditarCliente() 
        {
            objCliente.IDENTIFICACION_ = txtIdentificacion.Text;
            objCliente.NOMBRES_ = txtNombres.Text;
            objCliente.CORREO_ = txtCorreo.Text;
            objCliente.TELEFONO_ = txtTelefono.Text;
            if (accion_)
            {
                try { objCliente.CrearCliente(); this.Close(); }
                catch (Exception ne)
                {
                    MessageBox.Show(ne.Message);
                }


            }
            else
            {
                try { objCliente.Editar_Cliente(); this.Close(); }
                catch (Exception ne)
                {
                    MessageBox.Show(ne.Message);
                }
            }
        }

        private void CrearEditarClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
