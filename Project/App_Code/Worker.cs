using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Worker
/// </summary>
public class Worker
{
    public int WorkerId { get; set; }
    public string UserName { get; set; }
    public string WorkerPassword { get; set; }
    public string RealName { get; set; }
    public int DepartmentId { get; set; }
    public int RoleId { get; set; }

    private DatabaseConnection dataConn;

    public Worker()
	{
        dataConn = new DatabaseConnection();
	}

    public bool userNameExists()
    {
        dataConn.addParameter("@UserName", UserName);

        string command = "Select COUNT(UserName) FROM Workers WHERE UserName=@UserName";

        int result = dataConn.executeScalar(command); //result of count

        return result > 0 || result == -1; //if record found or exception caught

    }

    public bool addWorker()
    {
        dataConn.addParameter("@UserName", UserName);
        dataConn.addParameter("@WorkerPassword", WorkerPassword);
        dataConn.addParameter("@RealName", RealName);
        dataConn.addParameter("@DepartmentID", DepartmentId);
        dataConn.addParameter("@RoleID", RoleId);
        
        string command = "INSERT INTO Workers (UserName, WorkerPassword, RealName, DepartmentID, RoleID) " +
                        "VALUES (@UserName, @WorkerPassword, @RealName, @DepartmentID, @RoleID)";

        return dataConn.executeNonQuery(command) > 0; //i.e. 1 or more rows affected
    }

    public bool authenticateWorker()
    {
        dataConn.addParameter("@UserName", UserName);
        dataConn.addParameter("@WorkerPassword", WorkerPassword);

        string command = "Select WorkerID, RealName, DepartmentID, RoleID FROM Workers " +
                        "WHERE UserName=@UserName AND WorkerPassword=@WorkerPassword";

        DataTable table = dataConn.executeReader(command);

        if (table.Rows.Count > 0)
        {
            HttpContext.Current.Session["WorkerID"] = table.Rows[0]["WorkerID"].ToString();
            HttpContext.Current.Session["RealName"] = table.Rows[0]["RealName"].ToString();
            HttpContext.Current.Session["DepartmentID"] = table.Rows[0]["DepartmentID"].ToString();
            HttpContext.Current.Session["RoleID"] = table.Rows[0]["RoleID"].ToString();

            return true;
        }
        else
        {
            return false;
        }
    }

    public string getPasswordUsingID()
    {
        dataConn.addParameter("@WorkerID", WorkerId);

        string command = "Select WorkerPassword FROM Workers WHERE WorkerID=@WorkerID";

        DataTable table = dataConn.executeReader(command);

        if (table.Rows.Count > 0)
        {
            return table.Rows[0]["WorkerPassword"].ToString();
        }
        else
        {
            return "";
        }
    }

    public bool updatePasswordByUserId()
    {
        dataConn.addParameter("@WorkerPassword", WorkerPassword);
        dataConn.addParameter("@WorkerID", WorkerId);

        string command = "Update Workers Set WorkerPassword=@WorkerPassword WHERE WorkerID=@WorkerID";

        return dataConn.executeNonQuery(command) > 0; //i.e. 1 or more rows affected
    }

}
