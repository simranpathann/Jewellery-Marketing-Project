using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewJewellery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String category = Request.QueryString["Category"];

            viewJewellery(category);

        }
    }
    /***********************************************************************************************/
    /*****************************************View Jewellery ****************************************/
    /***********************************************************************************************/
    protected void viewJewellery(String category)
    {
        try
        {
             
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();
            string SqlQuery = "";
            if (category.Equals("Male") || category.Equals("Female") || category.Equals("Kids"))
                SqlQuery = "SELECT * FROM Jewellery_Master WHERE Jewellery_Gender = @Jewellery_Category; ";

            else if (category.Equals("Gold") || category.Equals("Silver"))
                SqlQuery = "SELECT * FROM Jewellery_Master WHERE Jewellery_Type = @Jewellery_Category; ";

            else if (category.Equals("All"))
                SqlQuery = "SELECT * FROM Jewellery_Master";

            else if (category.Equals("Kalyan") || category.Equals("PNG") || category.Equals("Tanishq") || category.Equals("PrajaktRaj"))
                SqlQuery = "SELECT * FROM Jewellery_Master WHERE Jewellery_Brand = @Jewellery_Category; ";       
            else
                SqlQuery = "SELECT * FROM Jewellery_Master WHERE Jewellery_Category = @Jewellery_Category; ";

            SqlCommand Cmd = new SqlCommand();
            Cmd.Parameters.AddWithValue("@Jewellery_Category", category);
            Cmd.Connection = Con;
            Cmd.CommandText = SqlQuery;
            SqlDataReader dr = Cmd.ExecuteReader();

            DtLstJewellery.DataSource = dr;
            DtLstJewellery.DataBind();
            if (dr.HasRows)
            {
                PnlNoProductFound.Visible = false;
            }
            else
            {
                PnlNoProductFound.Visible = true;
            }
            Con.Close();
        }

        catch (SqlException Se)
        {
            Response.Write("<script> alert ('Error!'" + Se.Message + ")</script>");
        }
    }
    protected void DtLstJewellerys_ItemCommand(object source, DataListCommandEventArgs e)
    {
        ImageButton ib = (ImageButton)e.Item.FindControl("ImgBtnAddToCart");
        string Jewellery_Id = ib.AlternateText;
        Session["Jewellery_Id"] = Jewellery_Id;
        ImageButton ibd = (ImageButton)e.Item.FindControl("ImgBtnDetails");

        if ((string)e.CommandArgument == ("AddToCart"))
        {

            if (Session["User_Id"] == null)
            {
                Response.Redirect("UserLogin.aspx");
            }
            Label LblJewelleryName = (Label)e.Item.FindControl("lblJewelleryName");
            Session["Jewellery_Name"] = LblJewelleryName.Text;

            Image ImgJewelleryImage = (Image)e.Item.FindControl("ImgBtnJewelleryImage");
            Session["Jewellery_Image"] = ImgJewelleryImage.ImageUrl;

            Label LblPrice = (Label)e.Item.FindControl("lblJewellerysellsPrice");
            Session["Jewellery_Price"] = LblPrice.Text;

            if (!IsPresent())
            {
                SubmitCart();
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                //LblMessage.Text = "Jewellery Already Added";
                Response.Write("<script> alert ('this Jewellery already added ! please select another Jewellery.')</script>");
            }
        }
        else if ((string)e.CommandArgument == ("ViewJewelleryDetails"))
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("UserLogin.aspx");
            }
            Label LblJewelleryName = (Label)e.Item.FindControl("lblJewelleryName");
            Session["Jewellery_Name"] = LblJewelleryName.Text;
            Response.Redirect("JewelleryDetails.aspx");
        }
        else if ((string)e.CommandArgument == ("BuyNow"))
        {
            if (Session["User_Id"] == null)
            {
                Response.Redirect("UserLogin.aspx");
            }
            Label LblJewelleryName = (Label)e.Item.FindControl("lblJewelleryName");
            Session["Jewellery_Name"] = LblJewelleryName.Text;
            Label LblJewelleryPrice = (Label)e.Item.FindControl("lblJewelleryPrice");
            Session["Amount_Value"] = LblJewelleryPrice.Text;
            Response.Redirect("Payment.aspx");
        }
    }
    public bool IsPresent()
    {
        try
        {
            String ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection Con = new SqlConnection(ConString);
            Con.Open();
            SqlCommand cmd = Con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) as cnt FROM Cart_Master WHERE Jewellery_Id=@Jewellery_Id AND User_Id=@User_Id";
            cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();
            cmd.Parameters.Add("@Jewellery_Id ", SqlDbType.Int).Value = Session["Jewellery_Id"].ToString();
            int i = Int16.Parse(cmd.ExecuteScalar().ToString());

            if (i > 0)
                return true;
            else
                return false;
        }
        catch (SqlException se)
        {
            //   LblMessage.Text = se.Message;
            return false;
        }
    }
    /**************************************************************************************************************/
    /***************************************Submit Cart************************************************************/
    /**************************************************************************************************************/
    protected void SubmitCart()
    {
        try
        {
            SqlConnection Con = new SqlConnection();
            String ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();
            String SqlQuery = "INSERT INTO Cart_Master(User_Id,Jewellery_Id,Jewellery_Name,Jewellery_Image,Jewellery_Quantity,Jewellery_Price,Jewellery_Total,Order_Date)VALUES" +
                "(@User_Id,@Jewellery_Id,@Jewellery_Name,@Jewellery_Image,@Jewellery_Quantity,@Jewellery_Price,@Jewellery_Total,@Order_Date)";
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = SqlQuery;
            Cmd.Connection = Con;
            Cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();
            Cmd.Parameters.Add("@Jewellery_Id", SqlDbType.Int).Value = Session["Jewellery_Id"].ToString();
            Cmd.Parameters.Add("@Jewellery_Name", SqlDbType.VarChar).Value = Session["Jewellery_Name"].ToString();
            Cmd.Parameters.Add("@Jewellery_Image", SqlDbType.VarChar).Value = Session["Jewellery_Image"].ToString();
            Cmd.Parameters.Add("@Jewellery_Quantity", SqlDbType.Int).Value = "1";
            Cmd.Parameters.Add("@Jewellery_Price", SqlDbType.Float).Value = Session["Jewellery_Price"].ToString();
            Cmd.Parameters.Add("@Jewellery_Total", SqlDbType.Float).Value = Session["Jewellery_Price"].ToString();
            Cmd.Parameters.Add("@Order_Date", SqlDbType.SmallDateTime).Value = DateTime.Today.Date.ToShortDateString();

            Cmd.ExecuteNonQuery();

            Con.Close();
            Response.Redirect("Home.aspx");
        }
        catch (SqlException Se)
        {
            // LblMessage.Text = Se.Message;
        }
    }

}