using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class UserLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.Cookies["User_Email"] != null)
                TxtUserEmail.Text = Request.Cookies["User_Email"].Value;
            if (Request.Cookies["User_Password"] != null)
                TxtPassword.Attributes.Add("value", Request.Cookies["User_Password"].Value);
            if (Request.Cookies["User_Email"] != null && Request.Cookies["User_Password"] != null)
                ChkRememberMe.Checked = true;
        } 
    }

    /***************************************************************************************************/
    /********************Check User **************************************************************/
    /**************************************************************************************************/
    protected void CheckUser()
    {
        try
        {
            SqlConnection Con = new SqlConnection();
            string ConString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            Con.ConnectionString = ConString;
            Con.Open();

            string SqlQuerry = "SELECT * FROM User_Master WHERE User_Email=@User_Email AND User_Password=@User_Password";
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = Con;
            Cmd.CommandText = SqlQuerry;
            Cmd.Parameters.Add("@User_Email", SqlDbType.VarChar).Value = TxtUserEmail.Text;
            Cmd.Parameters.Add("@User_Password", SqlDbType.VarChar).Value = TxtPassword.Text;
            SqlDataReader dr = Cmd.ExecuteReader();

            if (dr.Read() && dr.HasRows)
            {
                Session["User_Email"] = dr["User_Email"].ToString();
                Session["User_Name"] = dr["User_name"].ToString();
                Session["User_Id"] = dr["User_Id"].ToString();
                Session["User_Photo"] = dr["User_Photo"].ToString();
                Session["User_Pin"] = dr["User_Pin"].ToString();

                Response.Redirect("Home.aspx");
                dvMessage.Visible = false;
                        if (ChkRememberMe.Checked)
                        {
                            Response.Cookies["User_Id"].Value = dr["User_Id"].ToString();
                            Response.Cookies["User_Email"].Value = TxtUserEmail.Text;
                            Response.Cookies["User_Password"].Value = TxtPassword.Text;
                            Response.Cookies["User_Id"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["User_Email"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["User_Password"].Expires = DateTime.Now.AddDays(15);
                        }
                        else
                        {
                            Response.Cookies["User_Id"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["User_Email"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["User_Password"].Expires = DateTime.Now.AddDays(-1);
                        }

            }
            else
            {
                dvMessage.Visible = true;
                LblMessage.Text = " Invalid user name AND/OR Password";

            }
        }
        catch (SqlException Se)
        {
            LblMessage.Text = Se.Message;
        }
    }
    protected void BtnSignIn_Click(object sender, EventArgs e)
    {
        CheckUser();
    }
}