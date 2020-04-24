using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            //Настройка соединения с базой данных
            //Название базы данных: PoemsFileManager
            //Пользователь: postgres
            //Порт: 5432
            //Пароль: 1234
            //Название таблицы: PoemsList
            String connectionParams = "Server=localhost;Port=5432;User ID=postgres;Password=1234;Database=PoemsFileManager;";
            NpgsqlConnection npgSqlConnection3 = new NpgsqlConnection(connectionParams);
            npgSqlConnection3.Open();
            //Создаем sql-запрос на чтение данных из таблицы логов
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT * FROM public.\"Logs\";", npgSqlConnection3);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

            MyDataGridView.RowCount = 1;
            if (npgSqlDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    MyDataGridView.RowCount++;
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[0].Value = dbDataRecord["TransactionTime"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[1].Value = dbDataRecord["Action"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[2].Value = dbDataRecord["Name"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[3].Value = dbDataRecord["Length"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[4].Value = dbDataRecord["LengthNew"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[5].Value = dbDataRecord["LastWriteTime"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[6].Value = dbDataRecord["LastWriteTimeNew"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[7].Value = dbDataRecord["CreationTime"];
                }
            }
            npgSqlDataReader.Close();
            npgSqlCommand.Dispose();
            npgSqlConnection3.Close();
        }
    }
}
