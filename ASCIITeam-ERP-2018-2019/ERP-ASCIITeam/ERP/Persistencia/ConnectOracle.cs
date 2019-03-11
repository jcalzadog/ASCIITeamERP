
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERP
{
    class ConnectOracle
    {

        ////////////////////////////////////////////////////////////
        ////////////////////  DRIVER //////////////////////
        ////////////////////////////////////////////////////////////
        const String driver = "Data Source=(DESCRIPTION ="
        + "(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = LOCALHOST )(PORT = 1521)))"
        + "(CONNECT_DATA = (SERVICE_NAME = xe))); "
        + "User Id=VideogamesERP; Password=88888888;";

        ////////////////////////////////////////////////////////////

        /**
         * Method to retrieve a set of data
         * Parameter: Query
         * Parameter: Table
         */
         
        public DataSet getData(String query, String table)
        {
            OracleConnection objConexion;
            OracleDataAdapter objComando;
            DataSet requestQuery = new DataSet();
            //try
            //{
                objConexion = new OracleConnection(driver);
                objConexion.Open();
                objComando = new OracleDataAdapter(query, objConexion);
                objComando.Fill(requestQuery, table);
                objConexion.Close();
            //} catch (Exception e)
            //{
            //    MessageBox.Show("Error on query:\n"+query);
            //}
            

            

            return requestQuery;
        }

        /**
         * Method to insert data in a table
         * Parameter: Sentence 
         */
         
        public void setData(String sentencia)
        {
            OracleConnection objConexion;
            OracleCommand objComando;

            objConexion = new OracleConnection(driver);
            objConexion.Open();
            objComando = new OracleCommand(sentencia, objConexion);
            //MessageBox.Show(sentencia);
            objComando.ExecuteNonQuery();
            objComando.Connection.Close();
        }

        /**
         * Method to retrieve only one value
         * Parameter: column
         * Parameter: Table
         * Parameter: Condition
         */
         
        public Object DLookUp(String columna, String tabla, String condicion)
        {
            String SQLErrores = "";
            OracleConnection objConexion;
            OracleDataAdapter objComando;
            DataSet requestQuery = new DataSet();
            Object resultado;

            objConexion = new OracleConnection(driver);
            objConexion.Open();

            if (condicion.Equals(""))
            {
                objComando = new OracleDataAdapter("Select " + columna + " from " + tabla, objConexion);
                SQLErrores = "Select " + columna + " from " + tabla;
            }
            else
            {
                objComando = new OracleDataAdapter("Select " + columna + " from " + tabla + " where " + condicion, objConexion);
                SQLErrores = "Select " + columna + " from " + tabla +" where " + condicion;
                //MessageBox.Show(SQLErrores);
            }
            objComando.Fill(requestQuery);

            try
            {
                resultado = requestQuery.Tables[0].Rows[0][requestQuery.Tables[0].Columns.IndexOf(columna)];
            }
            catch (Exception a)
            {
                //MessageBox.Show(a.ToString() + " ^^^^" + SQLErrores);
                resultado = -1;
            }
            objConexion.Close();
            return resultado;

        }
        

    }
}
