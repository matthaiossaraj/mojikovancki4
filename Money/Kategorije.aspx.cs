using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Money
{
    public partial class Kategorije : System.Web.UI.Page
    {
        private MySqlConnection connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString;
            connectionString = "server=57c4cf97-8eac-4264-93a0-a2b30118bd31.mysql.sequelizer.com;database=db57c4cf978eac426493a0a2b30118bd31;uid=zlzvudsglculkmzm;pwd=rBKMJ5F8Q6UeUVb8QYjgWUNbZJe5LMEeJSKXMXMa45jZuNBPeWTHtWPEWHUaZJvc";

            connection = new MySqlConnection(connectionString);

            connection.Open();

            string query = "SELECT * FROM categories";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            kategorijeLoadDash.InnerHtml = @"<ul class='listWithBudget'>";

            while (dataReader.Read())
            {

                int columnIndex = dataReader.GetOrdinal("name");
                string name = dataReader.GetString(columnIndex);

                int columnIndex2 = dataReader.GetOrdinal("monthBalance");
                double balance = dataReader.GetDouble(columnIndex2);

                int columnIndex3 = dataReader.GetOrdinal("budget");
                double goal = dataReader.GetDouble(columnIndex3);

                kategorijeLoadDash.InnerHtml += @"<li>
						<h4><a href=''>";
                kategorijeLoadDash.InnerHtml += name;
                kategorijeLoadDash.InnerHtml += @"</a></h4>
						<div class='outerBar'>
						    <div class='innerBar'>";
                kategorijeLoadDash.InnerHtml += balance.ToString("F2");
                kategorijeLoadDash.InnerHtml += @"</div>
						</div>
						<input type='text' name='budget' value='";
                kategorijeLoadDash.InnerHtml += goal.ToString("F2");
                kategorijeLoadDash.InnerHtml += @"'/>
						<span>€</span>
					    </li>";

            }

            kategorijeLoadDash.InnerHtml += @"</ul>";
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            string connectionString;
            connectionString = "server=57c4cf97-8eac-4264-93a0-a2b30118bd31.mysql.sequelizer.com;database=db57c4cf978eac426493a0a2b30118bd31;uid=zlzvudsglculkmzm;pwd=rBKMJ5F8Q6UeUVb8QYjgWUNbZJe5LMEeJSKXMXMa45jZuNBPeWTHtWPEWHUaZJvc";

            connection = new MySqlConnection(connectionString);

            connection.Open();

            string query = "SELECT * FROM categories ORDER BY budget DESC LIMIT 3";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            string[] accounts = new string[3];
            int i = 0;
            while (dataReader.Read())
            {
                int columnIndex = dataReader.GetOrdinal("name");
                string name = dataReader.GetString(columnIndex);

                accounts[i] = name;

                i++;
            }
            dataReader.Close();

            connection.Close();

            racun1.Text = accounts[0];
            racun2.Text = accounts[1];
            racun3.Text = accounts[2];
        }
    }
}