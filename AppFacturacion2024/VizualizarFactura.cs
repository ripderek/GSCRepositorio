using AppFacturacion2024.Clases;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace AppFacturacion2024
{
    public partial class VizualizarFactura : Form
    {
        private int _codFactura ;
        private Factura _factura;
        Factura obj_facturas = new Factura();

        public VizualizarFactura()
        {
            InitializeComponent();
            _codFactura = 0;
            _factura = new Factura();
           
        }
        public VizualizarFactura(int codFactura)
        {
            InitializeComponent();
            _codFactura = codFactura;
            _factura = new Factura();
        }

        private void VizualizarFactura_Load(object sender, EventArgs e)
        {
            ShowReport();
        }
        private void ShowReport()
        {
            if ( _codFactura!=0)
            {
                //MessageBox.Show(_codFactura.ToString());
                // Obtener los datos de la factura en formato XML
                string xmlData = _factura.ObtenerFacturaXML(_codFactura);

                if (!string.IsNullOrEmpty(xmlData))
                {
                    // Cargar los datos en un DataSet
                    DataSet ds = new DataSet();
                    ds.ReadXml(new System.IO.StringReader(xmlData));

                    // Configurar el ReportViewer
                    reportViewer1.ProcessingMode = ProcessingMode.Local;
                    reportViewer1.LocalReport.ReportPath = "Factura.rdlc"; // Asegúrate de que la ruta sea correcta
                    reportViewer1.LocalReport.DataSources.Clear();

                    // Establecer el DataSource del reporte
                    ReportDataSource rdsFactura = new ReportDataSource("DataSet1", ds.Tables["Factura"]);
                    ReportDataSource rdsDetalle = new ReportDataSource("DataSet2", ds.Tables["Detalle"]);
                    reportViewer1.LocalReport.DataSources.Add(rdsFactura);
                    reportViewer1.LocalReport.DataSources.Add(rdsDetalle);

                    // Refrescar el ReportViewer
                    reportViewer1.RefreshReport();
                }
                else
                {
                    MessageBox.Show("No se pudieron obtener los datos de la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

     

        private void cmb_Cod_Factura_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica que hay un elemento seleccionado
            if (cmb_Cod_Factura.SelectedIndex != -1)
            {
                // Asigna el valor seleccionado a una variable
                _codFactura = int.Parse(cmb_Cod_Factura.SelectedItem.ToString());
                ShowReport();
            }
        }
    }
}

