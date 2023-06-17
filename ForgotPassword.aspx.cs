using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using System.Net;
using System.Net.Mail;
using System.Drawing;
public partial class ForgotPassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SendEmail(object sender, EventArgs e)
    {
        string username = string.Empty;
        string password = string.Empty;
        string constr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT User_Name, User_Password FROM User_Master WHERE User_Email = @User_Email"))
            {
                cmd.Parameters.AddWithValue("@User_Email", TxtEmail.Text.Trim());
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.Read())
                    {
                        username = sdr["User_Name"].ToString();
                        password = sdr["User_Password"].ToString();
                    }
                }
                con.Close();
            }
        }
        if (!string.IsNullOrEmpty(password))
        {
            MailMessage mm = new MailMessage("sender@gmail.com", TxtEmail.Text.Trim());
            mm.Subject = "Password Recovery";
            mm.Body = string.Format("Hi {0},<br /><br />Your password is {1}.<br /><br />Thank You.", username, password);
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "sender@gmail.com";
            NetworkCred.Password = "<Password>";
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mm);
            LblMessage.ForeColor = Color.Green;
            LblMessage.Text = "Password has been sent to your email address.";
        }
        else
        {
            LblMessage.ForeColor = Color.Red;
            LblMessage.Text = "This email address does not match our records.";
        }
    }
    protected void BtnSend_Click(object sender, EventArgs e)
    {
        SendEmail(sender, e);
    }
}