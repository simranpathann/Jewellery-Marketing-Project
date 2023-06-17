using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ViewUserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["User_Id"] == null)
        {
            Response.Redirect("Userlogin.aspx");
        }
        if (!IsPostBack)
        {
            FillDdlCity();
            ViewRecord();
        }
    }
    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ To View The Record  ~~~~~~~~~~~~~~~~~~~~~~~*/
    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    protected void ViewRecord()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            String ConString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = ConString;
            con.Open();
            String Url = "";
            String SqlQuery = "SELECT * FROM User_Master WHERE User_Id=@User_Id";

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = con;
            Cmd.CommandText = SqlQuery;
            Cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"].ToString();
            SqlDataReader Dr = Cmd.ExecuteReader();
            while (Dr.Read())
            {
                TxtUserFullName.Text = Dr["User_Name"].ToString();
                TxtAddress.Text = Dr["User_Address"].ToString();
                ListItem listitem = DdlCity.Items.FindByText(Dr["User_City"].ToString());
                DdlCity.ClearSelection();
                listitem.Selected = true;
                listitem = null;
                TxtPincode.Text = Dr["User_Pin"].ToString();
                TxtMobile.Text = Dr["User_Mobile"].ToString();
                TxtEmail.Text = Dr["User_Email"].ToString();
                Url = Dr["User_Photo"].ToString();
                LblPhotoPath.Text = Url;
                ImgPhoto.ImageUrl = Url;
            }
            con.Close();
        }
        catch (SqlException se)
        {
            LblMessage1.Text = se.Message;
        }
    }

    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Fill ddl City  ~~~~~~~~~~~~~~~~~~~~~~~*/
    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    protected void FillDdlCity()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            String ConString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = ConString;
            con.Open();
            String SqlQuery = "SELECT * FROM Lookup_Master WHERE Lookup_Type='City'";
            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = con;
            Cmd.CommandText = SqlQuery;
            SqlDataReader Dr = Cmd.ExecuteReader();
            DdlCity.Items.Add(new ListItem("--SELECT--", "0"));
            while (Dr.Read())
            {
                DdlCity.Items.Add(new ListItem(Dr[2].ToString(), Dr[0].ToString()));
            }
            con.Close();
        }
        catch (SqlException se)
        {
            LblMessage1.Text = se.Message;
        }
    }
    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/
    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ Get Pincode  ~~~~~~~~~~~~~~~~~~~~~~~*/
    /*~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~*/


    protected void getPincode()
    {
        try
        {
            SqlConnection con = new SqlConnection();
            String ConString = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = ConString;

            String sqlQuery = "SELECT * From Lookup_Master Where Lookup_Id = @Lookup_Id AND Lookup_Type='City';";

            SqlCommand Cmd = new SqlCommand();
            Cmd.Connection = con;
            Cmd.CommandText = sqlQuery;

            Cmd.Parameters.Add("@Lookup_Id", SqlDbType.Int).Value = DdlCity.SelectedValue.ToString();

            SqlDataReader Dr = Cmd.ExecuteReader();


            while (Dr.Read())
            {
                TxtPincode.Text = Dr["Lookup_Value_2"].ToString();
            }
            con.Close();
        }
        catch (SqlException se)
        {
            LblMessage1.Text = se.Message;
        }
    }
    /******************************************************************************************************************/
    /*************************************Update User*****************************************************************/
    /******************************************************************************************************************/
    protected void UpdateUser()
    {

        try
        {
            SqlConnection con = new SqlConnection();
            string conSting = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = conSting;
            con.Open();


            String sqlQuery = "UPDATE User_Master SET User_Name = @User_Name, User_Address = @User_Address, User_city = @User_City," +
                " User_Pin = @User_Pin,User_Mobile = @User_Mobile, User_Email = @User_Email WHERE User_Id = @User_Id";


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.Connection = con;

            cmd.Parameters.Add("@User_Id", SqlDbType.VarChar).Value = Session["User_Id"].ToString();
            cmd.Parameters.Add("@User_Name", SqlDbType.VarChar).Value = TxtUserFullName.Text;
            cmd.Parameters.Add("@User_Address", SqlDbType.VarChar).Value = TxtAddress.Text;
            cmd.Parameters.Add("@User_City", SqlDbType.VarChar).Value = DdlCity.SelectedItem.ToString();
            cmd.Parameters.Add("@User_Pin", SqlDbType.VarChar).Value = TxtPincode.Text;
            cmd.Parameters.Add("@User_Mobile", SqlDbType.VarChar).Value = TxtMobile.Text;
            cmd.Parameters.Add("@User_Email", SqlDbType.VarChar).Value = TxtEmail.Text;

            cmd.ExecuteNonQuery();
            LblMessage2.Text = "Successfully Updated";
            con.Close();

        }
        catch (SqlException se)
        {
            LblMessage2.Text = se.Message;
        }
    }

    protected void BtnUpdate_Click(object sender, EventArgs e)
    {
        UpdateUser();
    }

    /************************************************************************************/
    /*****************************************To Update Image*********************************/
    /*****************************************************************************************/
    protected void UpdateImage()
    {

        try
        {
            SqlConnection con = new SqlConnection();
            string conSting = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = conSting;
            con.Open();
            ;
            FUImages.SaveAs(Server.MapPath("~/images/") + FUImages.FileName.ToString());
            String Url = ("~/images/") + FUImages.FileName.ToString();

            String sqlQuery = "UPDATE User_Master SET User_Photo=@User_Photo WHERE User_Id=@User_Id";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.Connection = con;

            cmd.Parameters.AddWithValue("@User_Photo", Url);
            cmd.Parameters.AddWithValue("@User_Id", Session["User_Id"].ToString());

            cmd.ExecuteNonQuery();
            LblMessage1.Text = "Successfully Updated Your Photo";
            con.Close();

        }
        catch (SqlException se)
        {
            LblMessage1.Text = se.Message;
        }
    }
    /******************************************************************************************************************/
    /*************************************Delete User*****************************************************************/
    /******************************************************************************************************************/
    protected void DeleteUser()
    {

        try
        {
            SqlConnection con = new SqlConnection();
            string conSting = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
            con.ConnectionString = conSting;
            con.Open();


            String sqlQuery = "DELETE  FROM User_Master WHERE User_Id = @User_Id";


            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sqlQuery;
            cmd.Connection = con;

            cmd.Parameters.Add("@User_Id", SqlDbType.VarChar).Value = Session["User_Id"].ToString();
            cmd.ExecuteNonQuery();
            LblMessage1.Text = "Successfully Updated";
            con.Close();

        }
        catch (SqlException se)
        {
            LblMessage1.Text = se.Message;
        }
    }
    protected void BtnUploadPhoto_Click(object sender, EventArgs e)
    {
        UpdateImage();
    }
    protected void DdlCity_SelectedIndexChanged(object sender, EventArgs e)
    {
        getPincode();
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewUserProfile.aspx");
    }

    protected void LnkBtnDeleteProfile_Click(object sender, EventArgs e)
    {
        DeleteUser();
    }
}