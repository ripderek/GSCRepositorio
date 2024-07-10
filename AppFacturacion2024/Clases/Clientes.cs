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
    internal class Clientes : ConexionBD
    {
        private string IDENTIFICACION;
        private string NOMBRES;
        private string CORREO;
        private string TELEFONO;
        private string ESTADO;

        public string IDENTIFICACION_ { get => IDENTIFICACION; set => IDENTIFICACION = value; }
        public string NOMBRES_ { get => NOMBRES; set => NOMBRES = value; }
        public string CORREO_ { get => CORREO; set => CORREO = value; }
        public string TELEFONO_ { get => TELEFONO; set => TELEFONO = value; }
        public string ESTADO_ { get => ESTADO; set => ESTADO = value; }

        //funcion para crear el cliente 
        public void CrearCliente()
        {
            //ConcatenacionCadena("EXEC SP_Insertar_Cliente '" + IDENTIFICACION_ + "' ,'" + NOMBRES_ + "',  '" + CORREO_ + "' , '" + TELEFONO_ + "'"); 
            //string SQL = "EXEC SP_EliminarProducto '" + CODIGO_ + "'";
            //ConcatenacionCadena(SQL);
            string sql = "SP_Insertar_Cliente";

            // Crear los parámetros
            var parametros = new List<System.Data.SqlClient.SqlParameter>
                {
                  new System.Data.SqlClient.SqlParameter("@Identificacion", IDENTIFICACION_),
                  new System.Data.SqlClient.SqlParameter("@Nombres", NOMBRES_),
                  new System.Data.SqlClient.SqlParameter("@Correo", CORREO_),
                  new System.Data.SqlClient.SqlParameter("@Telefono", TELEFONO_),
             };

            ConcatenacionCadena(sql, parametros);
        }
        //funcion para editar el cliente
        public void Editar_Cliente()
        {
            //ConcatenacionCadena("EXEC SP_Actualizar_Cliente '" + IDENTIFICACION_ + "' , '" + NOMBRES_ + "', '" + CORREO_ + "' , '" + TELEFONO_ + "'");
            string sql = "SP_Actualizar_Cliente";
            // Crear los parámetros
            var parametros = new List<System.Data.SqlClient.SqlParameter>
                {
                  new System.Data.SqlClient.SqlParameter("@Identificacion", IDENTIFICACION_),
                  new System.Data.SqlClient.SqlParameter("@Nombres", NOMBRES_),
                  new System.Data.SqlClient.SqlParameter("@Correo", CORREO_),
                  new System.Data.SqlClient.SqlParameter("@Telefono", TELEFONO_),
             };
            ConcatenacionCadena(sql, parametros);
        }
        //funcion para eliminar el cliente 
        public void Eliminar_Cliente()
        {
            //ConcatenacionCadena("EXEC SP_Eliminar_Cliente '" + IDENTIFICACION_ + "'");
            string sql = "SP_Eliminar_Cliente";
            // Crear los parámetros
            var parametros = new List<System.Data.SqlClient.SqlParameter>
                {
                  new System.Data.SqlClient.SqlParameter("@Identificacion", IDENTIFICACION_),
             };
            ConcatenacionCadena(sql, parametros);
        }
        //funcion para listar los clientes 

        public DataTable Listar_Clientes()
        {
            return Cargar_Data_Table("EXEC SP_Mostrar_Clientes;");
        }

        //funcion para buscar el cliente por palabra clave
        public DataTable Buscar_Cliente(string Palabra_Clave)
        {
            //return Cargar_Data_Table("EXEC [SP_Buscar_Cliente] '"+Palabra_Clave+"'");
            string sql = "SP_Buscar_Cliente";

            var parametros = new List<System.Data.SqlClient.SqlParameter>
             {
                      new System.Data.SqlClient.SqlParameter("@Palabra_Clave", Palabra_Clave)
             };
            return Cargar_Data_Table(sql, parametros);
        }
    }
}
