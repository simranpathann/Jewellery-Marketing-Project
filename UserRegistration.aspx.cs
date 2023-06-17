using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class UserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if(!IsPostBack)
         {
            FillddlCity();
         }
    }
    /***********************************************************************************************/
    /***************************************** Submit Record ****************************************/
    /***********************************************************************************************/
     private void SubmitRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            con = new SqlConnection(conString);
            con.Open();
           
            String SqlQuery = "INSERT INTO User_Master(User_Name,User_Address,User_City,User_Pin,User_Mobile,User_Email,User_Password,Created_Date)" +
                                                     "VALUES (@User_Name,@User_Address,@User_City,@User_Pin,@User_Mobile,@User_Email,@User_Password,@Created_Date)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlQuery;
            cmd.Connection = con;

            cmd.Parameters.Add("@User_Name", SqlDbType.VarChar).Value = TxtUserName.Text;
            cmd.Parameters.Add("@User_Address", SqlDbType.VarChar).Value = TxtAddress.Text;
            cmd.Parameters.Add("@User_City", SqlDbType.VarChar).Value = DdlCity.SelectedItem.ToString();
            cmd.Parameters.Add("@User_Pin", SqlDbType.VarChar).Value = TxtPin.Text;
            cmd.Parameters.Add("@user_Mobile", SqlDbType.VarChar).Value = TxtUserMobile.Text;
            cmd.Parameters.Add("@User_Email", SqlDbType.VarChar).Value = TxtUserEmail.Text;
            cmd.Parameters.Add("@User_Password", SqlDbType.VarChar).Value = TxtPassword.Text;
            cmd.Parameters.Add("@Created_Date", SqlDbType.SmallDateTime).Value = DateTime.Now.ToShortDateString();
           
            cmd.ExecuteNonQuery();
            LblMessage.Text = "Successfully Submitted..";

            con.Close();
        }
        catch (SqlException se)
        {
            LblMessage.Text = se.Message;
        }
    }
     /***********************************************************************************************/
    /*****************************************Fill DdlCity ****************************************/
    /***********************************************************************************************/
      protected void FillddlCity()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            String ConString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = ConString;
            con.Open();
            String SqlQuery = "SELECT*FROM City_Master ORDER BY City_Name";

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = con;
            Cmd.CommandText = SqlQuery;

            SqlDataReader Dr = Cmd.ExecuteReader();
            DdlCity.Items.Add(new ListItem("--SELECT--", "0"));
            while (Dr.Read())
            {
                DdlCity.Items.Add(new ListItem(Dr[1].ToString(), Dr[0].ToString()));
            }
            con.Close();
        }
        catch (SqlException se)
        {
            LblMessage.Text = se.Message;
        }
    }
        /***********************************************************************************************/
    /*****************************************Get Pincode****************************************/
    /***********************************************************************************************/
    protected void getPincode()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            String ConString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = ConString;

            String sqlQuery = "SELECT * From City_Master Where City_Id = @City_Id ;";

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = con;
            con.Open();
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("@City_Id", SqlDbType.Int).Value = DdlCity.SelectedValue.ToString();

            SqlDataReader Dr = Cmd.ExecuteReader();
           
            while (Dr.Read())
            {
                TxtPin.Text = Dr["City_Pincode"].ToString();
            }
            con.Close();
        }
        catch (SqlException se)
        {
            LblMessage.Text = se.Message;
        }
    }
protected void BtnSubmit_Click(object sender, EventArgs e)
{
    SubmitRecord();
}
protected void BtnCancel_Click(object sender, EventArgs e)
{
    Response.Redirect("UserRegistration.aspx");
}
protected void DdlCity_SelectedIndexChanged(object sender, EventArgs e)
{
    getPincode();
}
}