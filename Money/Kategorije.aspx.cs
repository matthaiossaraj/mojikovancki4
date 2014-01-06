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
    }
}