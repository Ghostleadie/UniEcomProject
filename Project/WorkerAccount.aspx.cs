using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkerAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //check if Session has expired or user has not logged in
        if (Session.Count == 0)
        {
            Response.Redirect("~/WorkerLogin.aspx");
        }
        else
        {
            if (Request.QueryString.HasKeys())
            {
                if (Request.QueryString["change"].Equals("success"))
                {
                    lblSuccess.Text = "You successfully changed your password";
                }
            }

            if (Page.IsPostBack)
            {
                lblSuccess.Text = "";
            }
            
            //retrieve nesseccary session data, casting into variables
            string RealName = (string) Session["RealName"];
            int RoleID = Int32.Parse(Session["RoleID"].ToString());

            //assign the worker's real name to the welcome label
            lblWelcome.Text = "Welcome " + RealName + ".";
            
            if (RoleID == 2) //i.e. Admin worker
            {
                //make admin only button visible
                btnUpdateAdminDepartment.Visible = true;

                //change Text and PostBack Url properties for admin
                btnTools.Text = "Admin Tools";
                btnTools.PostBackUrl = "~/AdminTools.aspx";
            }
        }
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        //remove all Session data for this worker
        Session.Abandon();
        //redirect worker to the login page
        Response.Redirect("~/WorkerLogin.aspx");
    }
}
