using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Id"] == null)
        {
            Response.Redirect("UserLogin.aspx");
        }

    }
    protected void BtnChange_Click(object sender, EventArgs e)
    {
            changePassword();
    }
    /**********************************************************************************************************/
    /********************************************Change Password************************************************/
    /**********************************************************************************************************/
    protected void changePassword()
    {
        try
        {            
            SqlConnection con = new SqlConnection();
            string conSting = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = conSting;
            con.Open();
          
         
            String sqlQuery = "UPDATE User_Master SET User_Passwrod=@User_Password WHERE User_Id=@User_Id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@User_Password", TxtNewPassword.Text);
            cmd.Parameters.AddWithValue("@User_Id", Session["User_Id"].ToString());

            cmd.ExecuteNonQuery();
            LblMessage.Text = "Successfully Changed Password";
            con.Close();

        }
        catch (SqlException se)
        {
            LblMessage.Text = se.Message;
        }
    }
}