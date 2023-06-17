using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class ContactUs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SubmitRecord()
    {

        try
        {
            SqlConnection con = new SqlConnection();
            String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            con = new SqlConnection(conString);
            con.Open();


            String SqlQuery = "INSERT INTO ContactUs_Master(User_Name, User_Email, User_Message, User_Id, Message_Date)" +
                                                     "VALUES (@User_Name, @User_Email, @User_Message, @User_Id, @Message_Date)";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = SqlQuery;
            cmd.Connection = con;

            cmd.Parameters.Add("@User_Name", SqlDbType.VarChar).Value = TxtUserFullName.Text;
            cmd.Parameters.Add("@User_Email", SqlDbType.VarChar).Value = TxtUserEmail.Text;
            cmd.Parameters.Add("@User_Message", SqlDbType.VarChar).Value = TxtMessage.Text;
            cmd.Parameters.Add("@User_Id", SqlDbType.Int).Value = Session["User_Id"];
            cmd.Parameters.Add("Message_Date", SqlDbType.SmallDateTime).Value = DateTime.Today.Date.ToShortDateString();

            cmd.ExecuteNonQuery();
            LblMessage1.Text = "Successfully Submitted..";

            con.Close();
        }
        catch (SqlException se)
        {
            LblMessage1.Text = se.Message;
        }
    }
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        SubmitRecord();
    }
}