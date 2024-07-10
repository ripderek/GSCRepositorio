using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AppFacturacion2024.Clases
{
     class ConexionBD
    {
        public System.Data.SqlClient.SqlConnection Conexion = new System.Data.SqlClient.SqlConnection();
        public SqlConnection con;
       
        public bool Abrir()
        {
            string Servidor = "";
            string NombreBaseDatos = "";
            string Usuario = "";
            string Password = "";
            //Ruta del archivo de configuracion 
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.xml");
            // Cargar el archivo XML y leer los valores
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            XmlNode configNode = xmlDoc.SelectSingleNode("Config");
            if (configNode != null)
            {
                Servidor = configNode.SelectSingleNode("Servidor")?.InnerText;
                NombreBaseDatos = configNode.SelectSingleNode("NombreBaseDatos")?.InnerText;
                Usuario = configNode.SelectSingleNode("Usuario")?.InnerText;
                Password = configNode.SelectSingleNode("Password")?.InnerText;
            }
            //Conexion.ConnectionString = "Data Source=26.149.171.238;Initial Catalog=FacturaAPP;Persist Security Info=true;User ID=sa; password=123456";
            Conexion.ConnectionString = "Data Source="+Servidor+";Initial Catalog="+ NombreBaseDatos + ";Persist Security Info=true;User ID="+ Usuario + "; password="+ Password + "";
            try
            {
                if (this.Conexion.ConnectionString.Length == 0) return false;

                //= 5000;
                this.Conexion.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido lo siguiente:: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        public void Cerrar()
        {
            DialogResult oResult;

            try
            {
                if (Object.Equals(this.Conexion, null)) return;

                if (this.Conexion.State == System.Data.ConnectionState.Open)
                {
                    this.Conexion.Close();
                    this.Conexion.Dispose();
                }
                else if ((this.Conexion.State == System.Data.ConnectionState.Executing) || (this.Conexion.State == System.Data.ConnectionState.Fetching))
                {
                    oResult = MessageBox.Show("La conexión actual esta ejecutando una tarea, desea cerrarla...?", "...?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                    if (oResult == DialogResult.Yes)
                    {
                        this.Conexion.Close();
                        this.Conexion.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido lo siguiente:: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Hacer una funcion para que concantene todas las conexiones por medio de esta clase 
        public void ConcatenacionCadena(string SQL, List<System.Data.SqlClient.SqlParameter> parametros)
        {
            try
            {
                System.Data.SqlClient.SqlDataReader oReader = null;
                if (Abrir() == true)
                {
                    oReader = EjecutarConsulta( SQL, parametros);
                    if (oReader != null && oReader.HasRows)
                    {
                        oReader.Close();
                    }
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Información: " + ex.Message + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //Sobrecarga 
        public void ConcatenacionCadena(string SQL)
        {
            try
            {
                System.Data.SqlClient.SqlDataReader oReader = null;
                if (Abrir() == true)
                {
                    oReader = EjecutarConsulta(SQL);
                    if (oReader != null && oReader.HasRows)
                    {
                        oReader.Close();
                    }
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Información: " + ex.Message + "", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public System.Data.SqlClient.SqlDataReader EjecutarConsulta(String CadenaSQL, List<System.Data.SqlClient.SqlParameter> parametros) // = "EXEC SP_Mostrar_Clientes;"
        {
           // System.Data.SqlClient.SqlCommand oCommand = new System.Data.SqlClient.SqlCommand();
            try
            {   /*
                if (Conexion.State == System.Data.ConnectionState.Open)
                {
                    oCommand = new System.Data.SqlClient.SqlCommand(CadenaSQL, Conexion);
                    oCommand.CommandTimeout = 5000;
                    return oCommand.ExecuteReader();
                }*/
                if (Conexion.State == System.Data.ConnectionState.Open)
                {
                    using (var oCommand = new System.Data.SqlClient.SqlCommand(CadenaSQL, Conexion))
                {
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure; // Indica que es un procedimiento almacenado
                    oCommand.CommandTimeout = 5000;

                    if (parametros != null)
                    {
                        foreach (var parametro in parametros)
                        {
                            oCommand.Parameters.Add(parametro);
                        }
                    }

                    return oCommand.ExecuteReader();
                }
                }
                
            }
            catch (Exception ex)
            {
                if (ex.Message.Substring(0, 34) == "Valor de tiempo de espera caducado")
                {
                    MessageBox.Show("Vuelva  a Intentar ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
                else
                    MessageBox.Show("Vuelva  a Intentar..: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }
        //sobrecarga 
        public System.Data.SqlClient.SqlDataReader EjecutarConsulta(String CadenaSQL) // = "EXEC SP_Mostrar_Clientes;"
        {
            System.Data.SqlClient.SqlCommand oCommand = new System.Data.SqlClient.SqlCommand();
            try
            {
                if (Conexion.State == System.Data.ConnectionState.Open)
                {
                    oCommand = new System.Data.SqlClient.SqlCommand(CadenaSQL, Conexion);
                    oCommand.CommandTimeout = 5000;
                    return oCommand.ExecuteReader();
                }           

            }
            catch (Exception ex)
            {
                if (ex.Message.Substring(0, 34) == "Valor de tiempo de espera caducado")
                {
                    MessageBox.Show("Vuelva  a Intentar ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }
                else
                    MessageBox.Show("Vuelva  a Intentar..: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            return null;
        }
        //funcion para CargarDatos para un datagridview o un cmb skere modo diablo
        public DataTable Cargar_Data_Table(string cadenaSQL)
        {
            SqlCommand oCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            try
            {
                //Server.Abrir()
                if (Abrir() == true)
                {
                    oCommand = new SqlCommand(cadenaSQL, Conexion);
                    using (SqlDataReader reader = oCommand.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Valor de tiempo de espera caducado"))
                {
                    MessageBox.Show("Vuelva a Intentar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Vuelva a Intentar..: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return dataTable;
        }
        //sobrecarcga
        public DataTable Cargar_Data_Table(string cadenaSQL,List<System.Data.SqlClient.SqlParameter> parametros)
        {
            SqlCommand oCommand = new SqlCommand();
            DataTable dataTable = new DataTable();
            try
            {
                if (Abrir() == true)
                {
                    oCommand = new SqlCommand(cadenaSQL, Conexion);
                    oCommand.CommandType = System.Data.CommandType.StoredProcedure; // Indica que es un procedimiento almacenado
                    oCommand.CommandTimeout = 5000;

                    if (parametros != null)
                    {
                        foreach (var parametro in parametros)
                        {
                            oCommand.Parameters.Add(parametro);
                        }
                    }

                    using (SqlDataReader reader = oCommand.ExecuteReader())
                    {
                        dataTable.Load(reader);
                    }
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Valor de tiempo de espera caducado"))
                {
                    MessageBox.Show("Vuelva a Intentar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Vuelva a Intentar..: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            return dataTable;
        }
        //obtener un xml de la consulta ejecutada
        public string ObtenerXML(string cadenaSQL)
        {
            string XML_Factura = null;
            try
            {
                if (Abrir() == true)
                {
                    using (SqlCommand command = new SqlCommand(cadenaSQL, Conexion))
                    {
                        XML_Factura = command.ExecuteScalar().ToString();
                    }
                    Cerrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Información: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return XML_Factura;
        }
        public string ObtenerXML(string cadenaSQL, List<System.Data.SqlClient.SqlParameter> parametros)
        {
            string XML_Factura = null;
            try
            {
                if (Abrir() == true)
                {
                    using (SqlCommand command = new SqlCommand(cadenaSQL, Conexion))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure; // Indica que es un procedimiento almacenado

                        if (parametros != null)
                        {
                            foreach (var parametro in parametros)
                            {
                                command.Parameters.Add(parametro);
                            }
                        }

                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            XML_Factura = result.ToString();
                        }

                        Cerrar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Información: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return XML_Factura;
        }
    }
}
