using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class WorkerRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if request is NOT a post back
        if (!Page.IsPostBack)
        {
            //create instane of middle layer business object
            Department dpt = new Department();
            //retrieve departments from middle layer into a DataTable
            DataTable dt = dpt.getAllDepartments();

            //check if query was successful
            if (dt != null)
            {
                //set DropDownList's data source to the DataTable
                ddlDepartments.DataSource = dt;
                //assign DepartmentID database field to the value property
                ddlDepartments.DataValueField = "DepartmentID";
                //assign DepartmentName database field to the text property
                ddlDepartments.DataTextField = "DepartmentName";
                //bind data
                ddlDepartments.DataBind();
            }
            else
            {
                lblError.Text = "Database connection error - cannot display departments.";
            }

        }
    }

    protected void btnRegister_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("Inside eWOOOOScalar method...");
        //validate input
        if (txtUsername.Text.Length < 5)
        {
            lblError.Text = "Username must be at least 5 characters long.";
        }
        else if (txtPassword.Text.Length < 6)
        {
            lblError.Text = "Password must be at least 6 characters long.";
        }
        else if (!txtConfirmPassword.Text.Equals(txtPassword.Text))
        {
            lblError.Text = "Please confirm password.";
        }
        else if (txtRealName.Text.Equals(""))
        {
            lblError.Text = "Please enter your full name.";
        }
        else
        {
            //create instane of middle layer business object
            Worker user = new Worker();

            //set username property, so it  can be used as a parameter for the query
            user.UserName = txtUsername.Text;

            //check if the username exists
            if (user.userNameExists())
            {
                //already exists so output error
                lblError.Text = "Username already exists, please select another";
            }
            else
            {
                //INSERT NEW WORKER...   

                //set properties, so it can be used as a parameter for the query
                user.UserName = txtUsername.Text;
                user.WorkerPassword = txtPassword.Text;
                user.RealName = txtRealName.Text;
                user.DepartmentId = Int32.Parse(ddlDepartments.SelectedValue);
                user.RoleId = 1; //hard coding the role ID is not ideal

                //attempt to add a worker and test if it is successful
                if (user.addWorker())
                {
                    //redirect user to login page
                    Response.Redirect("~/WorkerLogin.aspx");
                }
                else
                {
                    //exception thrown so display error
                    lblError.Text = "Database connection error - failed to insert record.";
                }           
            }
        }
    }
}
