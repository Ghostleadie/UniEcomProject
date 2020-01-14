using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class WorkerLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //validate input before connecting to database
        if (txtUsername.Text.Length < 5)
        {
            lblError.Text = "Username is invalid length";
        }
        else if (txtPassword.Text.Length < 6)
        {
            lblError.Text = "Password is invalid length";
        }
        else
        {
            Worker user = new Worker();

            user.UserName = txtUsername.Text;
            user.WorkerPassword = txtPassword.Text;

            if (user.authenticateWorker())
            {
                Response.Redirect("~/WorkerAccount.aspx");
            }
            else
            {
                lblError.Text = "Incorrect username and/or password";
            }

        }
    }
}
