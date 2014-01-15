﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Money
{
    public partial class Odhodki : System.Web.UI.Page
    {
        private MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString;
            connectionString = "server=57c4cf97-8eac-4264-93a0-a2b30118bd31.mysql.sequelizer.com;database=db57c4cf978eac426493a0a2b30118bd31;uid=zlzvudsglculkmzm;pwd=rBKMJ5F8Q6UeUVb8QYjgWUNbZJe5LMEeJSKXMXMa45jZuNBPeWTHtWPEWHUaZJvc";

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
                    string write = "INSERT INTO outcome (amount, category, date, account) VALUES (@amount, @category, @date, @account)";

                    MySqlCommand cmd2 = new MySqlCommand(write, connection);
                    cmd2.Parameters.AddWithValue("@amount", balance);
                    cmd2.Parameters.AddWithValue("@category", categoryname);
                    cmd2.Parameters.AddWithValue("@date", datev);
                    cmd2.Parameters.AddWithValue("@account", acc);
                    cmd2.ExecuteNonQuery();
                }
            }

            /*string SQLcommand = "SELECT date, amount AS Znesek, categories.name AS Kategorija, accounts.name AS Racun FROM outcome INNER JOIN accounts ON accounts.id = outcome.account INNER JOIN categories ON categories.id = outcome.category ORDER BY date DESC LIMIT 15";
            MySqlCommand bazaUkaz = new MySqlCommand(SQLcommand, connection);
            MySqlDataReader reader = bazaUkaz.ExecuteReader();
            odhodkiTab.DataSource = reader;
            odhodkiTab.DataBind();

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