<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkerAccount.aspx.cs" Inherits="WorkerAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Button ID="btnLogout" runat="server"        
        style="z-index: 1; left: 27px; top: 29px; position: absolute;" 
        Text="Logout" onclick="btnLogout_Click" />
    
    <div>
    
        <asp:Label ID="lblWorkerAccount" runat="server" Font-Bold="True" 
            Font-Size="Larger" Font-Underline="True" 
            style="z-index: 1; left: 119px; top: 69px; position: absolute" 
            Text="Worker Account"></asp:Label>
    
    </div>
    <asp:Label ID="lblWelcome" runat="server" 
        style="z-index: 1; left: 119px; top: 107px; position: absolute"></asp:Label>
        
    <asp:Label ID="lblMessage" runat="server" 
        style="z-index: 1; left: 118px; top: 144px; position: absolute" 
        Text="Please enjoy your visit to our website."></asp:Label>
        
    <asp:Button ID="btnChangePassword" runat="server" 
        style="z-index: 1; top: 29px; position: absolute; left: 280px" 
        Text="Change Password" PostBackUrl="~/UpdatePassword.aspx" />
        
    <asp:Button ID="btnTools" runat="server" 
        PostBackUrl="~/StandardTools.aspx" 
        style="z-index: 1; left: 120px; top: 29px; position: absolute" 
        Text="Standard Tools"/>
        
    <asp:Button ID="btnUpdateAdminDepartment" runat="server" 
        style="z-index: 1; left: 457px; top: 30px; position: absolute" 
        Text="Update Admin Department" Visible="False" 
        PostBackUrl="~/UpdateAdminDepartment.aspx" />
    </div>
        <asp:Label ID="lblSuccess" runat="server" ForeColor="#009900" style="z-index: 1; left: 121px; top: 199px; position: absolute"></asp:Label>
        
    </form>
</body>
</html>
