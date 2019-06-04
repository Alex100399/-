using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsAuthorization
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0) // проверяем введён ли логин
            {
                if (textBox2.Text.Length > 0) // проверяем введён ли пароль
                { 
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=G:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\DatabaseAuthorization.mdf;Integrated Security=True");
                    con.Open();
            string query = "SELECT * FROM [UserAuthoriz] WHERE [Логин]= '" + textBox1.Text + "' AND [Пароль] = '" + textBox2.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con); //("SELECT * FROM user WHERE [Пользователи]= '"+ textBox1.Text +"' and [Пароль] = '" + textBox2.Text + "'", con);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
                    if (dtbl.Rows.Count > 0) // если такая запись существует
                    {
                        MessageBox.Show("Пользователь авторизовался"); // говорим, что авторизовался
                        this.Hide();
                        Form2 f = new Form2();
                        f.Show();

                    }
                    else MessageBox.Show("Пользователя не найден"); // выводим ошибку
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку
        }
           

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 f1 = new Form1();
            Form t = new Form3(sqlConnection);
            f1.Close();
            t.Show();
            
   
        }
    } 
}
