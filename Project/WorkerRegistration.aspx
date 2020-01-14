<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkerRegistration.aspx.cs" Inherits="WorkerRegistration" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div> 
        <asp:Label ID="lblRegister" runat="server" 
            style="z-index: 1; left: 98px; top: 40px; position: absolute" 
            Text="Standard Worker Registration" Font-Bold="True" Font-Size="Larger"></asp:Label>
    
    <asp:Label ID="lblUsername" runat="server" 
        style="z-index: 1; left: 102px; top: 77px; position: absolute; height: 19px" 
        Text="Username:"></asp:Label>
    <asp:Label ID="lblPassword" runat="server" 
        style="z-index: 1; left: 103px; top: 111px; position: absolute" 
        Text="Password:"></asp:Label>
    <asp:Label ID="lblConfirmPassword" runat="server" 
        style="z-index: 1; left: 50px; top: 148px; position: absolute" 
        Text="Confirm Password:"></asp:Label>
    <asp:Label ID="lblDepartment" runat="server" 
        style="z-index: 1; left: 92px; top: 226px; position: absolute" 
        Text="Department:" width="74"></asp:Label>
    <asp:TextBox ID="txtUsername" runat="server" 
        style="z-index: 1; left: 184px; top: 76px; position: absolute"></asp:TextBox>
    <asp:TextBox ID="txtPassword" runat="server" 
        style="z-index: 1; left: 184px; top: 111px; position: absolute" 
        TextMode="Password"></asp:TextBox>
    <asp:TextBox ID="txtConfirmPassword" runat="server" 
        style="z-index: 1; left: 184px; top: 149px; position: absolute" 
        TextMode="Password"></asp:TextBox>
    <asp:DropDownList ID="ddlDepartments" runat="server" 
        style="z-index: 1; left: 184px; top: 224px; position: absolute;">
    </asp:DropDownList>
    <asp:Button ID="btnRegister" runat="server" 
        style="z-index: 1; left: 184px; top: 265px; position: absolute" 
        Text="Register" onclick="btnRegister_Click" />
    <asp:Label ID="lblError" runat="server" ForeColor="Red" 
        style="z-index: 1; left: 184px; top: 301px; position: absolute"></asp:Label>
     
    <asp:TextBox ID="txtRealName" runat="server" 
        style="z-index: 1; left: 184px; top: 187px; position: absolute"></asp:TextBox>
    <p>
        <asp:Label ID="lblRealName" runat="server" 
            style="z-index: 1; left: 79px; top: 186px; position: absolute" 
            Text="Worker name:"></asp:Label>
    </p>
    </div>
    </form>
</body>
</html>
