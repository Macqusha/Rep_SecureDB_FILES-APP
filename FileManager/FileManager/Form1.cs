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
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT * FROM public.\"PoemsTable\";", npgSqlConnection1);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

            MyDataGridView.RowCount = 1;
            if (npgSqlDataReader.HasRows)
            {
                foreach (DbDataRecord dbDataRecord in npgSqlDataReader)
                {
                    MyDataGridView.RowCount++;
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[0].Value = dbDataRecord["Name"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[1].Value = dbDataRecord["Length"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[2].Value = dbDataRecord["LastWriteTime"];
                    MyDataGridView.Rows[MyDataGridView.RowCount - 2].Cells[3].Value = dbDataRecord["CreationTime"];
                }
            }
            else
            {
                MessageBox.Show("Таблица базы данных пуста", "Предупреждение");
            }
            npgSqlDataReader.Close();
            npgSqlCommand.Dispose();
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
            string MessageOfResult = "";

            //Название базы данных: PoemsFileManager
            //Название таблицы: PoemsList
            //Порт: 5432
            //Пароль: 1234
            String connectionParams = "Server=localhost;Port=5432;User ID=postgres;Password=1234;Database=PoemsFileManager;";
            NpgsqlConnection npgSqlConnection2 = new NpgsqlConnection(connectionParams);
            //Открываем соединение с БД
            npgSqlConnection2.Open();
            //Создаем sql-запрос на чтение данных
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand("SELECT * FROM public.\"PoemsTable\";", npgSqlConnection2);
            NpgsqlDataReader npgSqlDataReader = npgSqlCommand.ExecuteReader();

            //Подготовим перечень файлов их дат последнего изменения из базы данных
            List<string> fileNames_DB = new List<string>();
            List<long> fileLength_DB = new List<long>();
            List<DateTime> fileChanged_DB = new List<DateTime>();
            List<DateTime> fileCreated_DB = new List<DateTime>();
            while (npgSqlDataReader.Read())
            {
                fileNames_DB.Add(npgSqlDataReader.GetValue(0).ToString());
                fileLength_DB.Add(Convert.ToInt64(npgSqlDataReader.GetValue(1)));
                fileChanged_DB.Add(Convert.ToDateTime(npgSqlDataReader.GetValue(2)));
                fileCreated_DB.Add(Convert.ToDateTime(npgSqlDataReader.GetValue(3)));
            }
            npgSqlDataReader.Close();
            npgSqlCommand.Dispose();
            
            //Открываем директорию
            DirectoryInfo directory = new DirectoryInfo(@"E:\Rep_SecureDB_FILES-APP\Poems");

            if (!directory.Exists)
            {
                MessageBox.Show("Требуемый каталог не найден", "Ошибка");
                return;
            }

            //Начинаем транзакцию
            npgSqlCommand = new NpgsqlCommand("BEGIN TRANSACTION", npgSqlConnection2);
            npgSqlCommand.ExecuteNonQuery();
            npgSqlCommand.Dispose();

            List<string> fileNames_Dir = new List<string>();
            foreach (var file in directory.GetFiles()) 
            {
                //Подготовим перечень всех файлов в директории
                fileNames_Dir.Add(file.Name);

                if (fileNames_DB.IndexOf(file.Name) == -1) //Файл еще не внесен в БД
                {
                    //Внести файл в БД
                    npgSqlCommand = new 
                        NpgsqlCommand("INSERT INTO public.\"PoemsTable\" (Name,Length,LastWriteTime,CreationTime) VALUES (" + "'" 
                        + file.Name + "','" + file.Length + "','" + file.LastWriteTime + "','" + file.CreationTime 
                        + "');", npgSqlConnection2);
                    if (npgSqlCommand.ExecuteNonQuery() == 1)
                    {
                        MessageOfResult += "Добавлен файл " + file.Name + "\r\n";

                        //Добавление логов
                        NpgsqlCommand npgSqlCommandLOGS = new
                        NpgsqlCommand("INSERT INTO public.\"Logs\" VALUES (now(), 'Добавлен', '"
                        + file.Name + "', null, '" + file.Length + "', null, '" + file.LastWriteTime + "','" + file.CreationTime
                        + "');", npgSqlConnection2);
                        npgSqlCommandLOGS.ExecuteNonQuery();
                        npgSqlCommandLOGS.Dispose();
                    }
                    else
                    {
                        MessageOfResult += "Не удалось добавить файл " + file.Name + "\r\n";
                    }                    
                    npgSqlCommand.Dispose();

                }
                else
                {
                    //Файл уже есть в директории, проверим актуальность даты его последнего изменения
                    int index_DB = fileNames_DB.IndexOf(file.Name);
                    if (fileChanged_DB[index_DB].ToString() != file.LastWriteTime.ToString())
                    {
                        npgSqlCommand = new
                        NpgsqlCommand("UPDATE public.\"PoemsTable\" SET Length = " + file.Length + ", LastWriteTime = '" +
                        file.LastWriteTime + "', CreationTime = '" + file.CreationTime + "' WHERE Name = '" + file.Name + "';", npgSqlConnection2);
                        if (npgSqlCommand.ExecuteNonQuery() == 1)
                        {
                            MessageOfResult += "Изменен файл " + file.Name + "\r\n";

                            //Добавление логов
                            NpgsqlCommand npgSqlCommandLOGS = new
                                NpgsqlCommand("INSERT INTO public.\"Logs\" VALUES (now(), 'Изменен', '" + file.Name +
                                "', '" + fileLength_DB[index_DB] + "', '" + file.Length + "', '"+ fileChanged_DB[index_DB] + "', '" +
                                file.LastWriteTime + "','" + file.CreationTime + "');", npgSqlConnection2);
                            npgSqlCommandLOGS.ExecuteNonQuery();
                            npgSqlCommandLOGS.Dispose();
                        }
                        else
                        {
                            MessageOfResult += "Не удалось изменить файл " + file.Name + "\r\n";
                        }                        
                        npgSqlCommand.Dispose();
                    }
                }
            }

            //Удалим из базы отсутствующие в директории файлы
            for (int i = 0; i < fileNames_DB.Count; i++)
            {
                if (fileNames_Dir.IndexOf(fileNames_DB[i]) == -1)
                {
                    npgSqlCommand = new NpgsqlCommand("DELETE FROM public.\"PoemsTable\" WHERE NAME = '" 
                        + fileNames_DB[i] + "';", npgSqlConnection2);
                    if (npgSqlCommand.ExecuteNonQuery() == 1)
                    {
                        MessageOfResult += "Удален файл " + fileNames_DB[i] + "\r\n";

                        //Добавление логов
                        NpgsqlCommand npgSqlCommandLOGS = new
                                NpgsqlCommand("INSERT INTO public.\"Logs\" VALUES (now(), 'Удален', '" + fileNames_DB[i] +
                                "', '" + fileLength_DB[i] + "', null, '" + fileChanged_DB[i] + "', null,'" +
                                fileCreated_DB[i] + "');", npgSqlConnection2);
                        npgSqlCommandLOGS.ExecuteNonQuery();
                        npgSqlCommandLOGS.Dispose();
                    }
                    else
                    {
                        MessageOfResult += "Не удалось удалить файл " + fileNames_DB[i] + "\r\n";
                    }     
                    npgSqlCommand.Dispose();    
                }

            }

            if (MessageOfResult != "")
            {
                MessageOfResult += "\r\n" + "Синхронизация завершена";
            }
            else
            {
                MessageOfResult += "Синхронизация завершена без измененией";
            }

            //Завершение транзакции
            npgSqlCommand = new NpgsqlCommand("COMMIT;", npgSqlConnection2);
            npgSqlCommand.ExecuteNonQuery();
            npgSqlCommand.Dispose();

            MessageBox.Show(MessageOfResult, "Синхронизация");
            npgSqlConnection2.Close();
        }

        private void but_Logs_Click(object sender, EventArgs e)
        {
            Hide();
            new Form2().ShowDialog();
            Show();
        }
    }
}
