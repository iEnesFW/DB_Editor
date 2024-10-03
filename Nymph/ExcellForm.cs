using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nymph
{
    public partial class ExcellForm : Form
    {
        public ExcellForm()
        {
            InitializeComponent();
        }
        DataSet ds;
        private void addExcell_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Excel Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.Filter = "Excel Worksheets|*.xls;*.xlsx|All files (*.*)|*.*"; 
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelFileReader(openFileDialog1.FileName);
                excellPath.Text = openFileDialog1.FileName;
            }
        }
        private void ExcelFileReader(string path)
        {
            var stream = File.Open(path, FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);
            var result = reader.AsDataSet();
            var tables = result.Tables.Cast<DataTable>();

            foreach (var table in tables)
            {
                dataGridView1.DataSource = table;
            }
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 9);

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

        }


    }
}
