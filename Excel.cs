using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace Proyecto_2
{
    static class Excel
    {
        public static Boolean OpenAfterSaved;
        public static string WorkSheetName;

        public static List<int> numeros = new List<int>();


        //METODO PARA EXPORTAR DATOS
        public static void ExportData(DataGridView vista)
        {

            Microsoft.Office.Interop.Excel.Application app; Workbook wb; Worksheet ws;

            app = new Microsoft.Office.Interop.Excel.Application();
            wb = app.Workbooks.Add(Type.Missing);
            ws = null;

            ws = (Worksheet)wb.ActiveSheet;
            if (WorkSheetName == null)
            {
                MessageBox.Show("There's no Worksheet name assigned to the Workbook.");
                return;
            }
            ws.Name = WorkSheetName;

            int cont = 0;

            //Titulos de la hoja de excel
            for (int index = 1; index <= vista.Columns.Count; index++)
            {
                if (numeros.Contains(index - 1))
                {
                    ws.Cells[1, index - cont] = vista.Columns[index - 1].HeaderText;
                    ws.Cells[1, index - cont].Font.Bold = true;
                }
                else
                {
                    cont ++;
                }
            }

            
            //Llena el dataGrid
            for (int row = 0; row <= vista.Rows.Count - 1; row++)
            {
                cont = 0;
                for (int col = 0; col <= vista.Columns.Count - 1; col++)
                {
                    if (numeros.Contains(col))
                    {
                        ws.Cells[row + 2, col + 1 - cont] = vista.Rows[row].Cells[col].Value;
                    }
                    else
                    {
                        cont++;
                    }
                }
            }

            ws.Columns.EntireColumn.AutoFit();
            app.DisplayAlerts = false;
            SaveExcelDialog(wb);
            app.Quit();

        }

        private static void SaveExcelDialog(Workbook WorkBookFile)
        {
            SaveFileDialog save = new SaveFileDialog()
            {
                Title = "Save as Excel File...",
                Filter = "Excel Workbook (2013-2016)|*.xlsx|Excel Workbook (97-2003)|*.xls",
                FileName = "ProductsList",
                DefaultExt = ".xlsx"
            };

            if (save.ShowDialog() == DialogResult.OK)
            {
                WorkBookFile.SaveCopyAs(save.FileName);
                WorkBookFile.Saved = true;
                MessageBox.Show("Saved Successfully!");
            }
            else
            {
                WorkBookFile.Saved = false;
            }

            if (OpenAfterSaved)
            {
                System.Diagnostics.Process.Start(save.FileName);
            }

        }
    }
}


