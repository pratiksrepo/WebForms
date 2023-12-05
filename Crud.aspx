<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Crud.aspx.cs" Inherits="Crudin.net.Crud" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>User Details</h2>
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label><br />
            Name: <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
<br />
            Email: <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
<br />
            Age: <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
          <br />
            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
        </div>
        <br />

<asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" OnRowEditing="gvUsers_RowEditing"
    OnRowCancelingEdit="gvUsers_RowCancelingEdit" OnRowUpdating="gvUsers_RowUpdating"
    OnRowDeleting="gvUsers_RowDeleting" DataKeyNames="ID">
    <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="true" />
        <asp:TemplateField HeaderText="Name">
            <ItemTemplate>
                <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEditName" runat="server" Text='<%# Bind("Name") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email">
            <ItemTemplate>
                <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEditEmail" runat="server" Text='<%# Bind("Email") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Age">
            <ItemTemplate>
                <asp:Label ID="lblAge" runat="server" Text='<%# Eval("Age") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEditAge" runat="server" Text='<%# Bind("Age") %>'></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>


        

    </form>
</body>
</html>