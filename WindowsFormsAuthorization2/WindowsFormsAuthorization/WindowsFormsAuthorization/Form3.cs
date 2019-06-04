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
using System.Windows;
using System.Configuration;



namespace WindowsFormsAuthorization
{

    public partial class Form3 : Form
    {
        private SqlConnection sqlConnection = null;

        
        public Form3(SqlConnection con )
        {
            InitializeComponent();

            sqlConnection = con;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            

            if (textBox1.Text.Length > 0) // проверяем логин
            {

            }
            else MessageBox.Show("Укажите логин");

                if (textBox2.Text.Length > 0) // проверяем пароль
                {

                }
                else MessageBox.Show("Укажите пароль");
            
                
                    if (textBox4.Text.Length > 0) // проверяем второй пароль
                    {

                    }
                    else MessageBox.Show("Повторите пароль");

            //if (textBox2.TextLength > 6)
            //{

            //}
            //else
            //{
            //    MessageBox.Show("Длина пароля меньше допустимой. Минимальная длина 6 символа.");
            //}
          


            if (textBox2.TextLength < 32)
            {

            }
            else
            {
                MessageBox.Show("Длина пароля превышает допустимую. Максимальная длина 32 символов.");
            }

            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Одно из полей не заполнено");
            }
            else
            if (textBox2.TextLength > 6)
            {
                if (textBox2.TextLength < 32)
                {
                    if (textBox2.Text == textBox4.Text) // проверка на совпадение паролей
                    {
                        MessageBox.Show("Пользователь зарегистрирован");
                    }

                    else MessageBox.Show("Пароли не совподают");
                }
               else MessageBox.Show("Длина пароля превышает допустимую. Максимальная длина 32 символов.");
            }
            else MessageBox.Show("Длина пароля меньше допустимой. Минимальная длина 6 символа.");




            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-IJHI4LO\SQLEXPRESS;Initial Catalog=AUTHORIZATION;Integrated Security=True");
            string sql = "INSERT INTO [UserAuthoriz] (Логин, Пароль, [Имя_пользователя]) VALUES (@Логин, @Пароль, @Имя_пользователя)";
            SqlCommand insertUserNameCommand = new SqlCommand(sql, con);
            insertUserNameCommand.Parameters.AddWithValue("Логин", textBox1.Text);
                insertUserNameCommand.Parameters.AddWithValue("Пароль", textBox2.Text);
                insertUserNameCommand.Parameters.AddWithValue("Имя_пользователя", textBox3.Text);

            try
            {
                con.Open();
                int n = insertUserNameCommand.ExecuteNonQuery();
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            this.Hide();
            Form1 y = new Form1();
            y.Show();

            //try
            //{
            //    await insertUserNameCommand.ExecuteNonQueryAsync();

            //    Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        
    }
}
