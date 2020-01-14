using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdatePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session.Count == 0)
        {
            Response.Redirect("~/WorkerLogin.aspx");
        }
    }

    protected void btnUpdatePassword_Click(object sender, EventArgs e)
    {
        if (txtCurrentPassword.Text.Length < 6)
        {
            lblError.Text = "Current password is invalid length.";
        }
        else if (txtNewPassword.Text.Length < 6)
        {
            lblError.Text = "New password is invalid length.";
        }
        else if (!txtConfirmPassword.Text.Equals(txtNewPassword.Text))
        {
            lblError.Text = "Please confirm new password.";
        }
        else
        {
            Worker user = new Worker();
            user.WorkerId = Int32.Parse(Session["WorkerID"].ToString());
            
            string password = user.getPasswordUsingID();
            
            if (password.Equals(txtCurrentPassword.Text))
            {
                user.WorkerPassword = txtNewPassword.Text; //WorkerId already set

                if (user.updatePasswordByUserId())
                {
                    Response.Redirect("~/WorkerAccount.aspx?change=success");
                }
                else
                {
                    lblError.Text = "Database connection error - could not update password";
                }
            }
            else
            {
                lblError.Text = "Current password is incorrect";
            }

        } 
    }
}
