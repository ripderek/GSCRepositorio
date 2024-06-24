using AppFacturacion2024.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFacturacion2024
{
    public partial class CrearEditarProductos : Form
    {

        Productos objProducto = new Productos();
        private bool accion_ = false;
        //si la accion es true entonces se va a crear el cliente 
        //si la accion es falsa entonces se va a editar el cliente 
       
        public CrearEditarProductos(bool accion, string CODIGO = "", string PRODUCTO = "", string PRECIO_UNITARIO = "")
        {
            InitializeComponent();
            if (accion)

                lblEtiqueta.Text = "Crear Producto";
            else
            {
                txtAceptar.Text = "Editar";
                txtCodigoProducto.Visible = true;
                lblEtiqueta.Text = "Editar Producto";
                txtCodigoProducto.Text = CODIGO;
                txtProductos.Text = PRODUCTO;
                txtPrecioUnitario.Text = PRECIO_UNITARIO;
               
            }

            accion_ = accion;
        }

        private void txtAceptar_Click(object sender, EventArgs e)
        {
            objProducto.PRODUCTO_ = txtProductos.Text;
            objProducto.PRECIO_UNITARIO_ = txtPrecioUnitario.Text;
            objProducto.CODIGO_ = txtCodigoProducto.Text;
            if (accion_)
            {
                try { objProducto.CrearProducto(); this.Close(); }
                catch (Exception ne)
                {
                    MessageBox.Show(ne.Message);
                }
            }
            else
            {
                try { objProducto.Editar_Producto(); this.Close(); }
                catch (Exception ne)
                {
                    MessageBox.Show(ne.Message);
                }
            }
        }
    }
}
