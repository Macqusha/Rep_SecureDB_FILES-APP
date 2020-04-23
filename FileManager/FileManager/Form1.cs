using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

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
            //Название базы данных: PoemsFileManager
            //Название таблицы: PoemsList
            //Порт: 5432
            //Пароль: 1234
            String connectionParams = "Server=localhost;Port=5432;User ID=postgres;Password=1234;Database=PoemsFileManager;";
            NpgsqlConnection npgSqlConnection1 = new NpgsqlConnection(connectionParams);
            //Открываем соединение с БД
            npgSqlConnection1.Open();            
            //Создаем sql-запрос на чтение данных
            NpgsqlCommand npgSqlCommand1 = new NpgsqlCommand("SELECT * FROM public.\"PoemsTable\"", npgSqlConnection1);
            NpgsqlDataReader npgSqlDataReader1 = npgSqlCommand1.ExecuteReader();

            if (npgSqlDataReader1.HasRows)
            {
                MyDataGridView.RowCount = 1;
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader1)
                {
                    MyDataGridView.RowCount++;
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[0].Value = dbDataRecord["Name"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[1].Value = dbDataRecord["Length"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[2].Value = dbDataRecord["LastWriteTime"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[3].Value = dbDataRecord["CreationTime"];
                }
            }            
            npgSqlDataReader1.Close();
            npgSqlCommand1.Dispose();
            npgSqlConnection1.Close();
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
