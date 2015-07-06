using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace Timescape
{
    public partial class HomeScreenws : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLAzureConnection"].ConnectionString;
            string queryString = "SELECT * FROM Shifts Where EmployeeID= 2;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                
                try
                {
                    //format should look like this: {“SourceDigital”:[

                    Response.Write(String.Format("{3}", "\"", "Shifts", "{", "["));
                    int x = 0;
                    while (reader.Read())
                    {
                      
                        if (x == 0)
                        {
                            //format should look like this:  {“sql01”:”sql02”}

                            Response.Write(String.Format("{2}{3}title{3}:{3}{0}{3},{3}start{3}:{3}{1}{3},{3}end{3}:{3}{5}{3}{4}", reader[5], reader[2], "{", "\"", "}", reader[3]));
                        }                         
                        else
                        {
                            //format should look like this: ,{“sql01”:”sql02”}
                            Response.Write(String.Format(",{2}{3}title{3}:{3}{0}{3},{3}start{3}:{3}{1}{3},{3}end{3}:{3}{5}{3}{4}", reader[5], reader[2], "{", "\"", "}", reader[3]));
                        }
                        x = x + 1;

                    }
                    //format should look like this: ]}   

                    Response.Write(String.Format("{0}", "]", "}"));
                }
                finally
                {
                    reader.Close();
                }
            }
        }
    }
}
