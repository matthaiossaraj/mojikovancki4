﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Money
{
    public partial class Prihodki : System.Web.UI.Page
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        protected void Page_Load(object sender, EventArgs e)
        {
            server = "localhost";
            database = "money";
            uid = "root";
            password = "";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            connection.Open();

            if (IsPostBack)
            {
                string categoryname = category.Text;
                string datev = date.Text;
                double balance;
                bool result = double.TryParse(amount.Text, out balance);
                string acc = account.Text;

                if (result)
                {
                    string write = "INSERT INTO income (amount, category, date, account) VALUES (@amount, @category, @date, @account)";

                    MySqlCommand cmd2 = new MySqlCommand(write, connection);
                    cmd2.Parameters.AddWithValue("@amount", balance);
                    cmd2.Parameters.AddWithValue("@category", categoryname);
                    cmd2.Parameters.AddWithValue("@date", datev);
                    cmd2.Parameters.AddWithValue("@account", acc);
                    cmd2.ExecuteNonQuery();
                }
            }

            /*string SQLcommand = "SELECT income.amount AS Znesek, income.`date` AS Datum, accounts.name AS Racun, categories.name AS Kategorija FROM income INNER JOIN accounts ON accounts.id = income.account INNER JOIN categories ON categories.id = income.category";
            MySqlCommand bazaUkaz = new MySqlCommand(SQLcommand, connection);
            MySqlDataReader reader = bazaUkaz.ExecuteReader();
            GridView1.DataSource = reader;
            GridView1.DataBind();
            reader.Close();*/

            connection.Close();
        }
        protected void Validate_Numeric(object sender, ServerValidateEventArgs e)
        {
            double number;
            bool result = double.TryParse(amount.Text, out number);
            if (result)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }
        }
    }
}