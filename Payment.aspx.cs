using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Payment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LblAmount.Text = Session["Amount_Value"].ToString();
        if (!IsPostBack)
        {


            DdlMonth.Items.Add("Month");
            for (int m = 1; m <= 12; m++)
            {
                DdlMonth.Items.Add(m.ToString());
            }
            DdlYear.Items.Add("Year");
            for (int m = 2010; m <= 2050; m++)
            {
                DdlYear.Items.Add(m.ToString());
            }

            DdlCardType.Items.Add("Master Card");
            DdlCardType.Items.Add("American_Card");
            DdlCardType.Items.Add("Visa_Card");
            DdlCardType.Items.Add("NetBanking Card");
            //LblAmountValue.Text = Session["TotalAmount"].ToString();
        }
    }
    /**************************************************************************************************************/
    /**********************************Submit Payment***************************************************************/
    /**************************************************************************************************************/
    protected void SubmitPayment()
    {
        try
        {
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();

            string SqlQuerry = "INSERT INTO Payment_Master(Card_Type,Card_No,Name_OnCard,Expire_Date,CVV_No,Issuing_Bank,Amount)VALUES(@Card_Type,@Card_No,@Name_OnCard,@Expire_Date,@CVV_No,@Issuing_Bank,@Amount)SELECT Scope_Identity()";
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = SqlQuerry;


            Cmd.Parameters.Add("@Card_Type", SqlDbType.VarChar).Value = DdlCardType.SelectedItem.ToString();
            Cmd.Parameters.Add("@Card_No", SqlDbType.VarChar).Value = TxtCardNumber.Text;
            Cmd.Parameters.Add("@Name_OnCard", SqlDbType.VarChar).Value = TxtNameOnCard.Text;
            Cmd.Parameters.Add("@Expire_Date", SqlDbType.VarChar).Value = DdlMonth.SelectedItem.ToString() + "-" + DdlYear.SelectedItem.ToString();
            Cmd.Parameters.Add("@CVV_No", SqlDbType.VarChar).Value = TxtCVVNumber.Text;
            Cmd.Parameters.Add("@Issuing_Bank", SqlDbType.VarChar).Value = TxtCardIssuingBank.Text;
            Cmd.Parameters.Add("@Amount", SqlDbType.VarChar).Value = LblAmount.Text;

            Session["Payment_Id"] = Cmd.ExecuteScalar();
            LblMessage.Text = "Successfully Submited Payment Record";
            Con.Close();

            SubmitOrderManage();
            UpdatePaymentId();
            SubmitOrder();
            UpdateStock();
            DeleteCart();

        }
        catch (SqlException Se)
        {
            LblMessage.Text = "Sub Pay" + Se.Message;
        }
    }
    /**************************************************************************************************************/
    /**********************************Submit Payment***************************************************************/
    /**************************************************************************************************************/
    protected void SubmitOrder()
    {
        try
        {
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();

            string SqlQuerry = "INSERT INTO Order_Master(User_Id,Jewellery_Id,Jewellery_Name,Jewellery_Image,Jewellery_Quantity,Jewellery_Price,Jewellery_Total,Order_Date,Payment_Id,Order_Id) SELECT User_Id,Jewellery_Id,Jewellery_Name,Jewellery_Image,Jewellery_Quantity,Jewellery_Price,Jewellery_Total,Order_Date,Payment_Id,Order_Id FROM Cart_Master WHERE User_Id=@User_Id";

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = SqlQuerry;

            Cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();



            Cmd.ExecuteNonQuery();

        }
        catch (SqlException Se)
        {
            LblMessage.Text = "Error SubOrd :" + Se.Message;
        }
    }
    protected void UpdatePaymentId()
    {
        try
        {
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();

            String SqlQuery = "UPDATE Cart_Master SET Payment_Id=@Payment_Id,Order_Id=@Order_Id";
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = SqlQuery;


            Cmd.Parameters.Add("@Payment_Id", SqlDbType.Int).Value = Session["Payment_Id"].ToString();
            Cmd.Parameters.Add("@Order_Id", SqlDbType.Int).Value = Session["Order_Id"].ToString();


            Cmd.ExecuteNonQuery();

        }
        catch (SqlException Se)
        {

        }

    }
    /**********************************************************************************************************************/
    /*********************************Delete Cart*************************************************************************/
    /*********************************************************************************************************************/
    protected void DeleteCart()
    {

        try
        {
            SqlConnection con;
            String conString, SqlQuery;

            conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(conString);
            con.Open();
            SqlQuery = "DELETE  FROM Cart_Master WHERE User_Id=@User_Id";
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = con;
            Cmd.CommandText = SqlQuery;
            Cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();
            Cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (SqlException se)
        {

        }

    }
    /**********************************************************************************************************************/
    /*********************************Update Stock***********************************************************************/
    /*********************************************************************************************************************/
    protected void UpdateStock()
    {

        try
        {
            SqlConnection con;
            String conString, SqlQuery;

            conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(conString);
            con.Open();
            SqlQuery = "SELECT * FROM Cart_Master WHERE User_Id=@User_Id";
            SqlCommand Cmd = con.CreateCommand();

            Cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();
            Cmd.CommandText = SqlQuery;
            SqlDataReader Dr = Cmd.ExecuteReader();
            while (Dr.Read())
            {
                int Jewellery_Id = Int32.Parse(Dr["Jewellery_Id"].ToString());
                int Jewellery_Quantity = Int32.Parse(Dr["Jewellery_Quantity"].ToString());
                GetStock(Jewellery_Id, Jewellery_Quantity);
            }
        }
        catch (SqlException se)
        {
            LblMessage.Text = se.Message;
        }
    }
    protected void GetStock(int Jewellery_Id, int Jewellery_Quantity)
    {
        SqlConnection con;
        String conString, SqlQuery;

        conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        con = new SqlConnection(conString);
        con.Open();
        SqlQuery = "SELECT Jewellery_Stock FROM Jewellery_Master WHERE Jewellery_Id=@Jewellery_Id";
        SqlCommand Cmd = con.CreateCommand();
        Cmd.CommandText = SqlQuery;
        Cmd.Parameters.Add("Jewellery_Id", SqlDbType.Int).Value = Jewellery_Id;
        int Jewellery_Stock = Int32.Parse(Cmd.ExecuteScalar().ToString());
        Cmd.CommandText = "UPDATE Jewellery_Master SET Jewellery_Stock='" + (Jewellery_Stock - Jewellery_Quantity) + "'WHERE Jewellery_Id='" + Jewellery_Id + "'";
        Cmd.ExecuteNonQuery();
    }
    /**********************************************************************************************************************/
    /*********************************Order Manage*************************************************************************/
    /*********************************************************************************************************************/
    protected void SubmitOrderManage()
    {

        SqlCommand Cmd;
        String ConString, SqlQuery;
        try
        {
            SqlConnection con;
            ConString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con = new SqlConnection(ConString);
            con.Open();

            SqlQuery = "INSERT INTO Order_Manage (Payment_Id,Order_Dispatched,Order_DispatchedDate,Order_Viewed,Order_Canceled,Order_CancelCause,Order_Date,User_Id)VALUES(@Payment_Id,@Order_Dispatched,@Order_DispatchedDate,@Order_Viewed,@Order_Canceled,@Order_CancelCause,@Order_Date,@User_Id)SELECT Scope_Identity()";
            Cmd = new SqlCommand();
            Cmd.Connection = con;
            Cmd.CommandText = SqlQuery;

            Cmd.Parameters.Add("Payment_Id", SqlDbType.Int).Value = Session["Payment_Id"].ToString();
            Cmd.Parameters.Add("@Order_Dispatched", SqlDbType.Bit).Value = false;
            Cmd.Parameters.Add("@Order_DispatchedDate", SqlDbType.SmallDateTime).Value = DateTime.Today.ToShortDateString();
            Cmd.Parameters.Add("@Order_Date", SqlDbType.SmallDateTime).Value = DateTime.Today.ToShortDateString();
            Cmd.Parameters.Add("@Order_Viewed", SqlDbType.Bit).Value = false;
            Cmd.Parameters.Add("@Order_Canceled", SqlDbType.Bit).Value = false;
            Cmd.Parameters.Add("@Order_CancelCause", SqlDbType.VarChar).Value = "-";
            Cmd.Parameters.Add("User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();

            Session["Order_Id"] = Cmd.ExecuteScalar();
            con.Close();
            LblMessage.Text = "Your Order Is Successfully Placed !!!";
        }
        catch (SqlException se)
        {
            LblMessage.Text = "Order Manage Error !" + se.Message;
        }
    }
    protected void BtnPayNow_Click(object sender, EventArgs e)
    {
        SubmitPayment();
    }
}