using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class DealOfTheDay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //String category = Request.QueryString["Category"];

            viewJewellery();

        }
    }
    protected void DtLstJewellerys_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect("UserLogin.aspx");
        }
        Label LblJewelleryName = (Label)e.Item.FindControl("lblJewelleryName");
        Image imgJewellery = (Image)e.Item.FindControl("ImgBtnJewelleryImage");
        Session["Jewellery_Id"] = imgJewellery.AlternateText;
        Session["Jewellery_Name"] = LblJewelleryName.Text;
        Response.Redirect("JewelleryDetails.aspx");
    }
    /***********************************************************************************************/
    /*****************************************View Jewellery ****************************************/
    /***********************************************************************************************/
    protected void viewJewellery()
    {
        try
        {

            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();


            String SqlQuery = "SELECT * FROM Jewellery_Master WHERE Jewellery_DealOfTheDay = 'true' ; ";
            SqlCommand Cmd = new SqlCommand();

            Cmd.Connection = Con;
            Cmd.CommandText = SqlQuery;
            SqlDataReader dr = Cmd.ExecuteReader();
            DtLstJewellery.DataSource = dr;
            DtLstJewellery.DataBind();
            Con.Close();
        }

        catch (SqlException Se)
        {
            Response.Write("<script> alert ('Error!'" + Se.Message + ")</script>");
        }
    }


}