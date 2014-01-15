using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Money
{
    public partial class _Default : System.Web.UI.Page
    {
        private MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString;
            connectionString = "server=57c4cf97-8eac-4264-93a0-a2b30118bd31.mysql.sequelizer.com;database=db57c4cf978eac426493a0a2b30118bd31;uid=zlzvudsglculkmzm;pwd=rBKMJ5F8Q6UeUVb8QYjgWUNbZJe5LMEeJSKXMXMa45jZuNBPeWTHtWPEWHUaZJvc";

            connection = new MySqlConnection(connectionString);

            connection.Open();

            string SQLcommand = "(SELECT date, amount AS Znesek, categories.name AS Kategorija, accounts.name AS Racun FROM income INNER JOIN accounts ON accounts.id = income.account INNER JOIN categories ON categories.id = income.category) UNION  (SELECT date, amount AS Znesek, categories.name AS Kategorija, accounts.name AS Racun FROM outcome INNER JOIN accounts ON accounts.id = outcome.account INNER JOIN categories ON categories.id = outcome.category) ORDER BY date DESC LIMIT 10";
            MySqlCommand bazaUkaz = new MySqlCommand(SQLcommand, connection);
            MySqlDataReader reader = bazaUkaz.ExecuteReader();
            transakcije.DataSource = reader;
            transakcije.DataBind();
            reader.Close();

            string query = "SELECT SUM(balance) AS sredstva FROM accounts WHERE positive = 1";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            dataReader.Read();
            int columnIndex = dataReader.GetOrdinal("sredstva");
            double sredstva = dataReader.GetDouble(columnIndex);

            dataReader.Close();

            string query2 = "SELECT SUM(balance) AS dolgovi FROM accounts WHERE positive = 0";

            MySqlCommand cmd2 = new MySqlCommand(query2, connection);
            MySqlDataReader dataReader2 = cmd2.ExecuteReader();

            dataReader2.Read();
            int columnIndex2 = dataReader2.GetOrdinal("dolgovi");
            double dolgovi = dataReader2.GetDouble(columnIndex2);

            dataReader2.Close();

            double neto = sredstva - dolgovi;

            this.sredstvaVal.Text = sredstva.ToString("F2");
            this.dolgoviVal.Text = dolgovi.ToString("F2");
            this.netoVal.Text = neto.ToString("F2");

            query = "SELECT * FROM accounts";

            cmd = new MySqlCommand(query, connection);
            dataReader = cmd.ExecuteReader();

            racuniList.InnerHtml = @"";

            while (dataReader.Read())
            {
                int columnIndex4 = dataReader.GetOrdinal("balance");
                double balance = dataReader.GetDouble(columnIndex4);

                int columnIndex3 = dataReader.GetOrdinal("lastMonth");
                double last = dataReader.GetDouble(columnIndex3);

                int columnIndex5 = dataReader.GetOrdinal("name");
                string name = dataReader.GetString(columnIndex5);

                racuniList.InnerHtml += @"<li><a href=''>";
                racuniList.InnerHtml += name;
                racuniList.InnerHtml += @"</a><div class='stateChange'><span>";
                racuniList.InnerHtml += balance.ToString("F2");
                racuniList.InnerHtml += @" €</span>";
                if (balance >= last)
                {
                    racuniList.InnerHtml += @"<img alt='arrow' src='images/up_icon.png' />";
                }
                else
                {
                    racuniList.InnerHtml += @"<img alt='arrow' src='images/down_icon.png' />";
                }
                if (balance >= last)
                {
                    racuniList.InnerHtml += @"<span class='upP'> ";
                }
                else
                {
                    racuniList.InnerHtml += @"<span class='dwP'> ";
                }
                double perc = Math.Abs(balance - last) / last * 100;
                racuniList.InnerHtml += perc.ToString("F2");
                racuniList.InnerHtml += @"%</span></div></li>";
            }
            dataReader.Close();

            query = "SELECT SUM(amount) AS budget FROM budgets";

            cmd = new MySqlCommand(query, connection);
            dataReader = cmd.ExecuteReader();

            dataReader.Read();
            columnIndex = dataReader.GetOrdinal("budget");
            double budget = dataReader.GetDouble(columnIndex);

            dataReader.Close();

            query2 = "SELECT SUM(monthBalance) AS used FROM categories INNER JOIN categoriesBudget ON categoriesBudget.category = categories.id";

            cmd2 = new MySqlCommand(query2, connection);
            dataReader2 = cmd2.ExecuteReader();

            dataReader2.Read();
            columnIndex2 = dataReader2.GetOrdinal("used");
            double used = dataReader2.GetDouble(columnIndex2);

            dataReader2.Close();

            this.budgetT.Text = budget.ToString("F2");
            this.budgetU.Text = used.ToString("F2");

            connection.Close();
        }
    }
}
