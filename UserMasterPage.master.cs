using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Configuration;
using System.Data.SqlClient;



public partial class UserMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["User_Id"] != null)
            {
                LblWelcome.Text = "Welcome! " + Session["User_Name"].ToString();
                imgBtnLogout.Enabled = true;
                ImgBtnLogin.Enabled = false;
                imgBtnNew.Enabled = false;
                imgBtnProfile.ImageUrl = Session["User_Photo"].ToString();
             
              
                ShowCart();
            }
            else
            {
                LblWelcome.Text = "Welcome Guest";
                ImgBtnLogin.Enabled = true;
                imgBtnLogout.Enabled = false;
                imgBtnNew.Enabled = true;
             
               
                imgBtnProfile.ImageUrl = "~/images/generaluser.png";
            }
        }
    }
    /**************************************************************************************************************/
    /**********************************Show Cart************************************************************/
    /**************************************************************************************************************/
    protected void ShowCart()
    {
        string ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(ConString);
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "SELECT count(*)as cnt FROM Cart_Master WHERE User_Id=@User_Id;";
        cmd.Parameters.AddWithValue("@User_Id", Session["User_Id"].ToString());

        con.Open();

        string cnt = cmd.ExecuteScalar().ToString();
        LblCartCnt.Text = cnt;
        con.Close();

    }
    protected void imgBtnLogout_Click(object sender, ImageClickEventArgs e)
    {
        Session.RemoveAll();
        Session.Abandon();
        Response.Redirect("~/Home.aspx");
    }
   

}
