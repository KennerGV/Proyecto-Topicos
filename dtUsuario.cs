using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Linq;
namespace Proyecto_2
{
   
   public class dtUsuario
     {
        // using System.Data;
        // using System.Data.SqlClient;
        public static MessageBoxIcon MessageBoxIcon { get; set; }

       //Método a utilizar
        public static DataTable Fill() 
        {DataTable dt = new DataTable();
        if ( Conceccion.Open() != null)
        { SqlDataAdapter da = new SqlDataAdapter("Select Top 20 * from Datos" , Conceccion.Open()); 
            da.Fill(dt); Conceccion.Close(); }  
        else { dt = null; } return dt; }

    }
}

