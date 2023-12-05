<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridEvents.aspx.cs" Inherits="Crudin.net.GridEvents" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <h2>Insert New Record</h2>
            <asp:Label ID="lblMessage" runat="server" Text="" ></asp:Label><br />
            Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" /><br />
            <hr />
            <h2>Update Record</h2>
            ID: <asp:TextBox ID="txtID" runat="server"></asp:TextBox><br />
            New Name: <asp:TextBox ID="txtNewName" runat="server"></asp:TextBox><br />
            New Email: <asp:TextBox ID="txtNewEmail" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" /><br />
            <hr />
            <h2>Delete Record</h2>
            ID: <asp:TextBox ID="txtDeleteID" runat="server"></asp:TextBox><br />
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        </div>
         <br /><br /><br />

        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" DataKeyNames="ID">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" />
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="Email" HeaderText="Email" />
    </Columns>
</asp:GridView>
    </form>
</body>
</html>
