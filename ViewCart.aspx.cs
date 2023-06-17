using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect("UserLogin.aspx");
        }
        if (!IsPostBack)
        {
            if (CartIsEmpty())
            {
                PnlCartDetails.Visible = false;
                PnlEmptyCart.Visible = true;
            }
            else
            {
                PnlCartDetails.Visible = true;
                PnlEmptyCart.Visible = false;
                FillgvCart();
                getShippingCharges();
                getTotal();
            }
        }
    }
    /**************************************************************************************************************/
    /**********************************Fill gvCart***************************************************************/
    /**************************************************************************************************************/
    protected void FillgvCart()
    {
        try
        {
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();
            string SqlQuerry = "SELECT * FROM Cart_Master WHERE User_Id=@User_Id";
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = SqlQuerry;
            Cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();
            SqlDataReader dr = Cmd.ExecuteReader();
            gvCart.DataSource = dr;
            gvCart.DataBind();
        }

        catch (SqlException Se)
        {

        }

    }
    protected void gvCart_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();

            GridViewRow row = (GridViewRow)gvCart.Rows[e.RowIndex];
            Image imgJewellery = (Image)row.FindControl("imgJewelleryImage");
            int CartId = Convert.ToInt32(imgJewellery.AlternateText);
            Label LblJewelleryPrice = (Label)row.FindControl("LblJewelleryPrice");
            decimal Price = Convert.ToDecimal(LblJewelleryPrice.Text);
            TextBox TaxQuantity = (TextBox)row.FindControl("TxtJewelleryQuantity");
            int Quantity = Convert.ToInt16(TaxQuantity.Text);
            decimal ProdTotal = Quantity * Price;
            String SqlQuerry = "UPDATE Cart_Master SET Jewellery_Quantity=@Jewellery_Quantity,Jewellery_Total=@Jewellery_Total WHERE Cart_Id=@Cart_Id";
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = SqlQuerry;
            Cmd.Parameters.AddWithValue("@Jewellery_Quantity", Quantity);
            Cmd.Parameters.AddWithValue("@Jewellery_Total", ProdTotal);
            Cmd.Parameters.AddWithValue("@Cart_Id", CartId);

            Cmd.CommandText = SqlQuerry;
            Cmd.Connection = Con;
            Cmd.ExecuteNonQuery();
            Con.Close();

            gvCart.EditIndex = -1;
            FillgvCart();
        }

        catch (SqlException Se)
        {

        }


    }
    protected void gvCart_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        try
        {
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();

            GridViewRow row = (GridViewRow)gvCart.Rows[e.RowIndex];
            Image imgJewellery = (Image)row.FindControl("imgJewelleryImage");
            int CartId = Convert.ToInt32(imgJewellery.AlternateText.ToString());
            String SqlQuery = "DELETE FROM Cart_Master WHERE Cart_Id='" + CartId.ToString() + "'";
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = SqlQuery;
            Cmd.Connection = Con;
            Cmd.ExecuteNonQuery();
            Con.Close();
            FillgvCart();
            Response.Redirect("ViewCart.aspx");
        }
        catch (SqlException se)
        {
            LblMessage.Text = se.Message;
        }
    }
    /**************************************************************************************************************/
    /*****************************************Get Total***********************************************************/
    /*************************************************************************************************************/
    protected void getTotal()
    {
        SqlConnection con;
        String conString, SqlQuery;
        try
        {
            conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(conString);
            con.Open();

            SqlQuery = "SELECT SUM(Jewellery_Total) as Jewellery_SubTotal FROM Cart_Master";
            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = SqlQuery;
            Cmd.Connection = con;
            SqlDataReader dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                LblSubTotal.Text = dr["Jewellery_SubTotal"].ToString();
            }
            decimal Shipment = Convert.ToDecimal(LblShipmentValue.Text);
            decimal SubTotal = Convert.ToDecimal(LblSubTotal.Text);

            LblTotalToPayValue.Text = (Shipment + SubTotal).ToString();
            con.Close();
        }
        catch (SqlException se)
        {

        }

    }
    /**************************************************************************************************************/
    /*****************************************Cart Is Empty*******************************************************/
    /*************************************************************************************************************/
    protected bool CartIsEmpty()
    {
        SqlConnection con;
        String conString, SqlQuery;
        try
        {
            conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(conString);
            con.Open();

            SqlQuery = "SELECT Count(*) as Total FROM Cart_Master WHERE User_Id=@User_Id";
            SqlCommand Cmd = new SqlCommand();
            Cmd.Parameters.AddWithValue("@User_Id", Session["User_Id"].ToString());
            Cmd.CommandText = SqlQuery;
            Cmd.Connection = con;
            int cnt = Convert.ToInt32(Cmd.ExecuteScalar());
            con.Close();
            if (cnt > 0)
            {
                return (false);
            }
            else
            {
                return (true);
            }
        }

        catch (SqlException se)
        {
            return (true);
        }
    }


    protected void gvCart_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvCart.EditIndex = -1;
        FillgvCart();
    }
    protected void gvCart_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void BtnFinalizeAndPay_Click(object sender, EventArgs e)
    {
        getTotal();
        Session["Amount_Value"] = LblTotalToPayValue.Text;
        Response.Redirect("Payment.aspx");
    }
    protected void gvCart_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCart.EditIndex = e.NewEditIndex;
        FillgvCart();
    }



    /**************************************************************************************************************/
    /*****************************************Get ShippingCharges***********************************************************/
    /*************************************************************************************************************/
    protected void getShippingCharges()
    {
        SqlConnection con;
        String conString, SqlQuery;
        try
        {
            conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(conString);
            con.Open();

            SqlQuery = "SELECT * FROM Shipping_Master WHERE Shipping_Pin=@Shipping_Pin ORDER BY Shipping_Id DESC;";

            SqlCommand Cmd = new SqlCommand();
            Cmd.CommandText = SqlQuery;
            Cmd.Connection = con;
            Cmd.Parameters.AddWithValue("@Shipping_Pin", Session["User_Pin"].ToString());

            SqlDataReader dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                LblShipmentValue.Text = dr["Shipping_Charges"].ToString();
            }
            
            con.Close();
        }
        catch (SqlException se)
        {

        }

    }
}