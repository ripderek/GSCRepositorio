using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFacturacion2024.Clases
{
    internal class Factura : ConexionBD
    {
        private string COD_FACTURA;
        private string COD_CLIENTE;
        private string ESTABLECIMIENTO;
        private string SUCURSAL;
        private string FECHA_EMISION;
        private string NUMERO_AUTORIZACION;
        private string NOMBRE_CLIENTE;
        private string IDENTIFICACION_CLIENTE;
        private string CORREO_CLIENTE;
        private string DIRECCION_CLIENTE;
        private string DESCUENTO;
        private string IVA;
        private string XML_Factura;

        public string XML_Factura1 { get => XML_Factura; set => XML_Factura = value; }
        public string COD_FACTURA_ { get => COD_FACTURA; set => COD_FACTURA = value; }
        public string COD_CLIENTE_ { get => COD_CLIENTE; set => COD_CLIENTE = value; }
        public string ESTABLECIMIENTO_ { get => ESTABLECIMIENTO; set => ESTABLECIMIENTO = value; }
        public string SUCURSAL_ { get => SUCURSAL; set => SUCURSAL = value; }
        public string FECHA_EMISION_ { get => FECHA_EMISION; set => FECHA_EMISION = value; }
        public string NUMERO_AUTORIZACION_ { get => NUMERO_AUTORIZACION; set => NUMERO_AUTORIZACION = value; }
        public string NOMBRE_CLIENTE_ { get => NOMBRE_CLIENTE; set => NOMBRE_CLIENTE = value; }
        public string IDENTIFICACION_CLIENTE_ { get => IDENTIFICACION_CLIENTE; set => IDENTIFICACION_CLIENTE = value; }
        public string CORREO_CLIENTE_ { get => CORREO_CLIENTE; set => CORREO_CLIENTE = value; }
        public string DIRECCION_CLIENTE_ { get => DIRECCION_CLIENTE; set => DIRECCION_CLIENTE = value; }
        public string DESCUENTO_ { get => DESCUENTO; set => DESCUENTO = value; }
        public string IVA_ { get => IVA; set => IVA = value; }
        

        //Funcion para guardar la factura
        public void CrearFactura()
        {
            ConcatenacionCadena("EXEC sp_RegistrarFactura '" + XML_Factura1 + "'");
        }
        public void Eliminar_Factura()
        {
            ConcatenacionCadena("EXEC SP_EliminarFactura '" + COD_FACTURA_ + "'");
        }
        public void Listar_Cod_Factura()
        {
            ConcatenacionCadena("EXEC SP_Listar_Cod_Factura");
        }
        public DataTable Listar_Facturas()
        {
            return Cargar_Data_Table("EXEC SP_ListarFacturas;");
        }
        public string ObtenerFacturaXML(int codFactura)
        {
            return ObtenerXML("EXEC SP_Datos_FacturaXML '" + codFactura + "'");
        }
        //funcion que devuelve la ultima factura genera por el cliente 
        public int ObtenerUltimaFactura(string CodCliente)
        {
            return int.Parse(ObtenerXML("EXEC SP_UltimaFacturaCliete '" + CodCliente + "'"));
        }
        //funcion para buscar el producto por palabra clave
        public DataTable Buscar_Factura(string Palabra_Clave)
        {
            return Cargar_Data_Table("EXEC [SP_Buscar_Factura] '" + Palabra_Clave + "'");

        }
    }
}

