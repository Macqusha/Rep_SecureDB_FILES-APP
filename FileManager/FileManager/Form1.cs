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

namespace FileManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void but_Load_from_DB_Click(object sender, EventArgs e)
        {

        }

        private void but_Load_from_Catalog_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(@"E:\Rep_SecureDB_FILES-APP\Poems");

            if (!directory.Exists)
            {
                MessageBox.Show("Требуемый каталог не найден", "Ошибка");
                return;
            }

            MyDataGridView.RowCount = 1;
            foreach (var file in directory.GetFiles()) 
            {
                MyDataGridView.RowCount++;
                MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[0].Value = file.Name;
                MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[1].Value = file.Length;
                MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[2].Value = file.LastWriteTime; 
                MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[3].Value = file.CreationTime;
            }
        }

        private void but_Synchronize_Click(object sender, EventArgs e)
        {

        }
    }
}
