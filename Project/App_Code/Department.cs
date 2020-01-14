using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Department
/// </summary>
public class Department
{
	public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }

    private DatabaseConnection dataConn;

    public Department()
    {
        dataConn = new DatabaseConnection();
    }

    public DataTable getAllDepartments()
    {
        string command = "Select * FROM Departments";
        return dataConn.executeReader(command);
    }
}
