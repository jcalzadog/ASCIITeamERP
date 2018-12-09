using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.Persistencia
{
    class Logs
    {
        static readonly String ruta = "log.txt";
        public static Object idUser { get; set; }
        public static void write(String desc)
        {
            //bloque que coresponde a log en fichero
            /*StreamWriter writer = File.AppendText(ruta);
            writer.WriteLine(DateTime.Now.ToString("G") + "-" + Dominio.Permissions.usuario+ "-" + desc);
            writer.Close();*/

            //bloque que corresponde a log en bbdd
            ConnectOracle connect = new ConnectOracle();
            //int idUser = Convert.ToInt32(connect.DLookUp("COUNT(*)", "users", "name = '" + Dominio.Permissions.usuario + "' "));
            String sql = "INSERT INTO LOGS" +
                " VALUES (SYSDATE," + idUser + ",'" + desc.Replace("'", "") + "')";
            connect.setData(sql);
        }

        //public static DataTable ConvertirTable()
        //{
        //    DataTable tbl = new DataTable();

        //    //Hablar mañana para meter el usuario tambien
        //    tbl.Columns.Add(new DataColumn("Date"));
        //    tbl.Columns.Add(new DataColumn("User"));
        //    tbl.Columns.Add(new DataColumn("Change"));

        //    string[] lines = System.IO.File.ReadAllLines(ruta);

        //    foreach (string line in lines)
        //    {
        //        String[] s = line.Split('-');
        //        //Hablar mañana para meter el usuario tambien
        //        DataRow dr = tbl.NewRow();
        //        for (int cIndex = 0; cIndex < s.Count(); cIndex++)
        //        {
        //            dr[cIndex] = s[cIndex];
        //        }

        //        tbl.Rows.Add(dr);
        //    }
        //    return tbl;
        //}
    }
}
