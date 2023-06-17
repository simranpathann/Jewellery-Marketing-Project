using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewGallery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {

            Response.Redirect("UserLogin.aspx");
        }
        else
        {
            ShowGallery();
        }
    }
    protected void ShowGallery()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            String ConString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = ConString;
            con.Open();
            String SqlQuery = "SELECT * FROM Gallery_Master WHERE Gallery_Show='true';";
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = SqlQuery;
            Cmd.Connection = con;
            SqlDataReader Dr = Cmd.ExecuteReader();

            if (!Dr.HasRows)
            {
                SorryPanel.Visible = true;
            }
            else
            {
                SorryPanel.Visible = false;
            }

            DtlstGallery.DataSource = Dr;
            DtlstGallery.DataBind();

            con.Close();

        }
        catch (SqlException se)
        {
            LblMessage.Text = "Error" + se.Message;

        }
    }
}