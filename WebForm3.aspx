<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Basic_Bank.WebForm3" Theme="Dark" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
                <h1 class="Head"><i>Transaction Page</i></h1><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><br />
            <asp:Label CssClass="Lab" ID="Label1" runat="server" Text="Enter the Amount to transfer  : "></asp:Label>
            &nbsp;
            <asp:TextBox CssClass="Txt" ID="TextBox1" runat="server"></asp:TextBox>  
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="TextBox1" ErrorMessage="Amount cannot be blank"  Text="*" ForeColor="Red"></asp:RequiredFieldValidator> 
            <br /><br /> 
            <asp:Button CssClass="Btn" ID="Button1" runat="server" Text="Transfer" OnClick="Button1_Click" />
            <br />
            <br />
            <asp:Label CssClass="Lab" ID="Label2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Button CssClass="Btn" ID="Button2" runat="server" OnClick="Button2_Click" Text="Get Transaction Details" Visible="false"/>&nbsp;&nbsp;
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" />
                <br />
                <asp:Label CssClass="Lab" ID="Label3" runat="server" Text=""></asp:Label>
                <br />
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                ConnectionString='<%$ ConnectionStrings:ITRConnectionString %>' 
                SelectCommand="SELECT * FROM [Transfers] WHERE ([Id] = @Id)">
                <SelectParameters>
                    <asp:SessionParameter SessionField="tid" Name="Id" Type="Int32"></asp:SessionParameter>
                </SelectParameters>
            </asp:SqlDataSource><br />
            <asp:GridView ID="GridView1" Visible="false" DataSourceID="SqlDataSource1" runat="server"></asp:GridView>
                <br />
                <asp:Button CssClass="Btn" ID="Button4" runat="server" OnClick="Button4_Click" Text="Go Back to Transfer Page" Width="249px" />
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button CssClass="Btn" ID="Button3" runat="server" OnClick="Button3_Click" Text="Go Back to Home" Width="254px" />           
            </center>
            
        </div>
    </form>
</body>
</html>
