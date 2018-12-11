using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }

            if (Conceccion.Open() != null)
            {
                dataVista.DataSource = dtUsuario.Fill();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel.WorkSheetName = "Vista DW";
            Excel.OpenAfterSaved = checkBox1.Checked;
            Excel.numeros = new List<int>();
            foreach (int elemento in checkedListBox1.CheckedIndices)
            {
                Excel.numeros.Add(elemento);
            }
            Excel.ExportData(dataVista);
        }
    }
}
