using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Money
{
    public partial class Racuni : System.Web.UI.Page
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
                string accname = name.Text;
                double balance;
                bool result = double.TryParse(initialAmount.Text, out balance);
                double acclimit;
                bool result2 = double.TryParse(limit.Text, out acclimit);

                if (result && result2)
                {
                    string write = "INSERT INTO accounts (name, balance, type, positive, acclimit, goal, lastMonth) VALUES (@name, @balance, @type, @positive, @limit, @goal, @lastMonth)";

                    MySqlCommand cmd2 = new MySqlCommand(write, connection);
                    cmd2.Parameters.AddWithValue("@name", accname);
                    cmd2.Parameters.AddWithValue("@balance", balance);
                    cmd2.Parameters.AddWithValue("@type", 1);
                    cmd2.Parameters.AddWithValue("@positive", 1);
                    cmd2.Parameters.AddWithValue("@limit", acclimit);
                    cmd2.Parameters.AddWithValue("@goal", balance * 2);
                    cmd2.Parameters.AddWithValue("@lastMonth", 0);
                    cmd2.ExecuteNonQuery();
                }
            }

            string query = "SELECT * FROM accounts";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            racuniLoadDash.InnerHtml = @"<ul class='listWithBudget'>";

            while (dataReader.Read())
            {
                double limitNew;

                int columnIndex = dataReader.GetOrdinal("positive");
                int positive = dataReader.GetInt32(columnIndex);

                int columnIndex2 = dataReader.GetOrdinal("balance");
                double balance = dataReader.GetDouble(columnIndex2);

                int columnIndex3 = dataReader.GetOrdinal("goal");
                double goal = dataReader.GetDouble(columnIndex3);

                int columnIndex4 = dataReader.GetOrdinal("acclimit");
                double limit = dataReader.GetDouble(columnIndex4);

                int columnIndex5 = dataReader.GetOrdinal("name");
                string name = dataReader.GetString(columnIndex5);

                if (positive == 1)
                {
                    if (positive >= 0)
                    {
                        if (balance > goal)
                        {
                            limitNew = goal * 1.5;
                        }
                        else
                            limitNew = goal;
                    }
                    else
                    {
                        limitNew = limit;
                    }
                }
                else
                {
                    limitNew = limit;
                }

                racuniLoadDash.InnerHtml += @"<li>
						<h4><a href=''>";
                racuniLoadDash.InnerHtml += name;
                racuniLoadDash.InnerHtml += @"</a></h4>
						<div class='outerBar'>
						    <div class='innerBar'>";
                racuniLoadDash.InnerHtml += balance.ToString("F2");
                racuniLoadDash.InnerHtml += @"</div>
						</div>
						<input type='text' name='budget' value='";
                racuniLoadDash.InnerHtml += limitNew.ToString("F2");
                racuniLoadDash.InnerHtml += @"'/>
						<span>€</span>
					    </li>";

            }

            racuniLoadDash.InnerHtml += @"</ul>";
        }

        protected void Validate_Numeric(object sender, ServerValidateEventArgs e)
        {
            double number;
            bool result = double.TryParse(limit.Text, out number);
            if (result)
            {
                e.IsValid = true;
            }
            else
            {
                e.IsValid = false;
            }
        }
        protected void Validate_Numeric2(object sender, ServerValidateEventArgs e)
        {
            double number;
            bool result = double.TryParse(initialAmount.Text, out number);
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