using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Faq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            viewRecoord();
        
        }

    }


    /************************************************/
    /***************To View Record***********/
    /************************************************/
    protected void viewRecoord()
    {
        try
        {
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();
            String url = "";
            String SqlQuery = "SELECT * FROM FAQ_Master";
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = SqlQuery;
            Cmd.Connection = Con;
            SqlDataReader Dr = Cmd.ExecuteReader();

            DtLstFaq.DataSource = Dr;
            DtLstFaq.DataBind();
           
           
            Con.Close();
        }
        catch (SqlException se)
        {
           // lblmessage.Text =se.Message;
        }
    }
}