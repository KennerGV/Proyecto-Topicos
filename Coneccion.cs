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
  //Se crea para enlazar el sistema con la base de datos
   public class Coneccion
   {
       
       public static SqlConnection con = null;
       public static string Ruta
       {
           get {
               return "Data Source=DESKTOP-2P9RKA8;Initial Catalog=DW_VIVERO1;Integrated Security=True";
           }
       }
       public static string Message { get; set; }
       public static SqlConnection Open()
       {
           con = null;
         
         // la funcionalidad de este try es para que compruebe la coneccion realizada
           try
           {
               con = new SqlConnection(Ruta);
               con.Open();
               Message = "[Conección Establecida]";
           }
           catch (Exception ex)
           {
               Message = "Ocurrió un grave error al intentar coenctarse con la base de datos " + ex.Message;
               con = null;
           }
           return con;
       }
       public static void Close() {
           con = null;
           Message = "[Conección Cerrada]";
       }
   }
}

