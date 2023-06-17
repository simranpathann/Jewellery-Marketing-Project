using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class JewelleryDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect("UserLogin.aspx");
        }
        if (!IsPostBack)
        {

            DdlJewelleryQuantity.Items.Add(new ListItem("Select Quantity", "0"));
            for (int i = 1; i <= 10; i++)
            {
                DdlJewelleryQuantity.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            viewRecoord();
            ViewModels();

            int stock = Convert.ToInt16(HfQuantity.Value);
            if (stock == 0)
            {
                Response.Write("<script>alert('Out of Stock !')</script>");
                DdlJewelleryQuantity.Enabled = false;
            }
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
            String SqlQuery = "SELECT * FROM Jewellery_Master WHERE Jewellery_Id= @Jewellery_Id";
            SqlCommand Cmd = new SqlCommand();
            Cmd.Parameters.Add("@Jewellery_Id", SqlDbType.Int).Value = Session["Jewellery_Id"].ToString();
            Cmd.CommandText = SqlQuery;
            Cmd.Connection = Con;
            SqlDataReader Dr = Cmd.ExecuteReader();


            while (Dr.Read())
            {
                TxtJewelleryName.Text = Dr["Jewellery_Name"].ToString();

                TxtJewelleryBrand.Text = Dr["Jewellery_Brand"].ToString();
                TxtJewelleryType.Text = Dr["Jewellery_Type"].ToString();
                TxtJewelleryPrice.Text = Dr["Jewellery_Brand"].ToString();
                TxtJewelleryDetails.Text = Dr["Jewellery_Details"].ToString();
                TxtJewelleryMrp.Text = Dr["Jewellery_MRP"].ToString();
                TxtJewellerySellsPrice.Text = Dr["Jewellery_SellsPrice"].ToString();
                TxtStock.Text = Dr["Jewellery_Stock"].ToString();
                TxtJewelleryRating.Text = Dr["Jewellery_Ratings"].ToString();
                HfQuantity.Value = Dr["Jewellery_Stock"].ToString();
                TxtJewelleryCategory.Text = Dr["Jewellery_Category"].ToString();

                url = Dr["Jewellery_Image"].ToString();
                ImgPhoto.ImageUrl = url;
                Session["Jewellery_Image"] = url;

            }
            double Mrp = Convert.ToDouble(TxtJewelleryMrp.Text);
            double SellsPrice = Convert.ToDouble(TxtJewellerySellsPrice.Text);
            double YouSave = Mrp - SellsPrice;
            LblYouSave1.Text = YouSave.ToString();

            Con.Close();
        }
        catch (SqlException se)
        {
            LblMessage.Text = "View Record " + se.Message;
        }
    }
    
    /*********************** View Models******************/
    protected void ViewModels()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            String ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.ConnectionString = ConString;
            con.Open();
            String sqlQuery = "SELECT * FROM Jewellery_Master WHERE Jewellery_Id=@Jewellery_Id";
            SqlCommand cmd = new SqlCommand(sqlQuery);
            cmd.CommandText = sqlQuery;
            cmd.Connection = con;
            cmd.Parameters.Add("@Jewellery_Id",SqlDbType.Int).Value=Session["Jewellery_Id"].ToString();


            SqlDataReader dr = cmd.ExecuteReader();

            DtLstModel.DataSource = dr;
            DtLstModel.DataBind();


            con.Close();
        }
        catch (SqlException se)
        {
            Response.Write("<script> alert ('Error!'" + se.Message + ")</script>");


        }
    }

    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("JewelleryDetails.aspx");
    }




    /*****************************************/
    /**********Add to Cart*****************/
    /*****************************************/
    protected void AddToCart()
    {
        try
        {
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();


            String SqlQuery = "INSERT INTO Cart_Master(User_Id,Jewellery_Id,Jewellery_Name,Jewellery_Image,Jewellery_Quantity,Jewellery_Price,Jewellery_Total,Order_Date)VALUES(@User_Id,@Jewellery_Id,@Jewellery_Name,@Jewellery_Image,@Jewellery_Quantity,@Jewellery_Price,@Jewellery_Total,@Order_Date)";
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = SqlQuery;
            Cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();
            Cmd.Parameters.Add("@Jewellery_Id", SqlDbType.Int).Value = Session["Jewellery_Id"].ToString();
            Cmd.Parameters.Add("@Jewellery_Name", SqlDbType.VarChar).Value = TxtJewelleryName.Text;
            Cmd.Parameters.Add("@Jewellery_Image", SqlDbType.VarChar).Value = Session["Jewellery_Image"].ToString();
            Cmd.Parameters.Add("@Jewellery_Quantity", SqlDbType.Int).Value = DdlJewelleryQuantity.SelectedItem.ToString();
            Cmd.Parameters.Add("@Jewellery_Price", SqlDbType.VarChar).Value = TxtJewellerySellsPrice.Text;
            Cmd.Parameters.Add("@Jewellery_Total", SqlDbType.VarChar).Value = LblSubTotalAmountValue.Text;
            Cmd.Parameters.Add("@Order_Date", SqlDbType.SmallDateTime).Value = DateTime.Today.Date.ToShortDateString();
            Cmd.ExecuteNonQuery();
            LblMessage.Text = "Succesfully Submitted Record";
        }
        catch (SqlException Se)
        {
            LblMessage.Text = "Submit Record" + Se.Message;
        }
    }

    public Boolean isPresent()
    {
        string ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlConnection Con = new SqlConnection();
        Con = new SqlConnection(ConString);
        Con.Open();
        SqlCommand Cmd = Con.CreateCommand();
        Cmd.CommandText = "SELECT Count (*) FROM Cart_Master WHERE Jewellery_Id=@Jewellery_Id AND User_Id=@User_Id";
        Cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();
        Cmd.Parameters.Add("@Jewellery_Id", SqlDbType.Int).Value = Session["Jewellery_Id"].ToString();
        int i = Int16.Parse(Cmd.ExecuteScalar().ToString());
        if (i > 0)
            return true;
        else
            return false;
    }

    protected void ImgbtnAddToCart_Click(object sender, ImageClickEventArgs e)
    {

        if (!isPresent())
        {
            AddToCart();
            Response.Redirect("Home.aspx");
        }
        else
        {
            Response.Write("<Script>alert/'This Jewellery is Already Added !Plese Select Another Jewellery'/</Script>");
        }

    }


    protected void DdlJewelleryQuantity_SelectedIndexChanged(object sender, EventArgs e)
    {
        int Quantity = Convert.ToInt16(DdlJewelleryQuantity.SelectedItem.ToString());
        double SalesPrice = Convert.ToDouble(TxtJewellerySellsPrice.Text);
        double SubTotal = Quantity * SalesPrice;
        LblSubTotalAmountValue.Text = SubTotal.ToString();
        Session["Quantity"] = Quantity;
        int stock = int.Parse(HfQuantity.Value);
        if (Quantity > stock)
        {
            Response.Write("<script>alert('Out of Stock !')</script>");
        }
        else
        {
            stock = stock - Quantity;
            TxtStock.Text = stock.ToString();
            Session["Stock"] = stock;

        }
    }
}