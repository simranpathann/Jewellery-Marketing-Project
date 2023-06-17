using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class ViewMyOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect("UserLogin.aspx");
        }
        if (!IsPostBack)
        {
            ShowOrderDetails();

        }
    }
    /********************************************************************************************************************/
    /*****************************************ShowOrderDetails*******************************************************************/
    /******************************************************************************************************************/
    protected void ShowOrderDetails()
    {
        try
        {
            String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            SqlConnection Con = new SqlConnection(conString);

            SqlCommand Cmd = Con.CreateCommand();
            Cmd.CommandText = "SELECT  TOP 1 Order_Id,Order_Dispatched,order_Canceled,Order_DispatchedDate,Order_Date FROM Order_Manage WHERE User_Id=@User_Id ORDER BY Order_Id DESC";
            //Cmd.CommandText = "Select * from Order_Manage";
            Con.Open();
            Cmd.Parameters.AddWithValue("@User_Id", Session["User_Id"].ToString());
            SqlDataReader dr = Cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    //if (Convert.ToBoolean(dr["Order_Dispatched"]) == true && Convert.ToBoolean(dr["order_Canceled"]) == false && Convert.ToBoolean(dr["Order_Dispatched"]) == false)
                    LblOrderDetails.Text += "<br/>Order No : " + dr["Order_Id"].ToString() + "<br/> On Dated :"
                        + Convert.ToDateTime(dr["Order_Date"].ToString()).Date.ToString("dd/MM/yyyy") + "<br/> POSTED on Date <br/><b>"
                         + Convert.ToDateTime(dr["Order_DispatchedDate"].ToString()).Date.ToString("dd/MM/yyyy") + "<b/><br/> and is on the way! <br/><b>";
                    if (Convert.ToBoolean(dr["Order_Dispatched"]) == false && Convert.ToBoolean(dr["order_Canceled"]) == true && Convert.ToBoolean(dr["Order_Dispatched"]) == false)
                        LblOrderDetails.Text += "<br/>Order No : " + dr["Order_Id"].ToString() + "<br/> On Dated :"
                            + Convert.ToDateTime(dr["Order_Date"].ToString()).Date.ToString("dd/MM/yyyy")
                            + "<br/> Cancel Due To Incomplete Information! <br/><b> Paid Amoun Will Be Refunded Within A Working Day!</b>";
                    else if (Convert.ToBoolean(dr["Order_Dispatched"]) == true)
                        LblOrderDetails.Text += "<br/>Order No : " + dr["Order_Id"].ToString() + "<br/> On Dated :"
                             + Convert.ToDateTime(dr["Order_Date"].ToString()).Date.ToString("dd/MM/yyyy") + "<br/> POSTED on Date <br/><b>"
                             + Convert.ToDateTime(dr["Order_DispatchedDate"].ToString()).Date.ToString("dd/MM/yyyy");
                }
            }
            else
            {
                LblOrderDetails.Text = "Sorry! No Order Present";
            }
        }

        catch (SqlException se)
        {
            LblMessage.Text = se.Message;
        }
    }
}