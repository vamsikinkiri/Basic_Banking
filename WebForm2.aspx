<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Basic_Bank.WebForm2" Theme="Dark" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body style="border: 1px solid #4CAF50">
    <form id="form1" runat="server">
        <div>
            <center>
                <h1 class="Head"><i>Transfer Page</i></h1><br />               
                <hr class="Line" /><br />  
                <div >
                    <asp:Label CssClass="Lab" ID="Label1" runat="server" Text="Sender Details : "></asp:Label>
                    <br />
                    <br />           
                    <asp:GridView ID="GridView1" DataSourceID="SqlDataSource1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id"></asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name"></asp:BoundField>
                            <asp:BoundField DataField="Email Id" HeaderText="Email Id" SortExpression="Email Id"></asp:BoundField>
                            <asp:BoundField DataField="Balance" HeaderText="Balance" SortExpression="Balance"></asp:BoundField>
                        </Columns>
                    </asp:GridView><br /><br />
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"
                        ConnectionString='<%$ ConnectionStrings:ITRConnectionString %>'
                        SelectCommand="SELECT * FROM [Customers] WHERE ([Id] = @Id)">
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="id" Name="Id" Type="Int32"></asp:QueryStringParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <hr class="Line" /><br />
                <div>
                    <asp:Label CssClass="Lab" ID="Label2" runat="server" Text="Select the customer to transfer the money (Receiver) : "></asp:Label>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server"
                        ConnectionString='<%$ ConnectionStrings:ITRConnectionString %>'
                        SelectCommand="SELECT [Name] FROM [Customers] WHERE ([Id] <> @Id)">
                        <SelectParameters>
                            <asp:QueryStringParameter QueryStringField="id" Name="Id" Type="Int32"></asp:QueryStringParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                <asp:DropDownList CssClass="Drop" ID="DropDownList1" AutoPostBack="true" DataSourceID="SqlDataSource2" DataTextField="name" runat="server"></asp:DropDownList><br /><br />
                </div>
                <hr class="Line"/><br />
                <div>
                    <asp:Label CssClass="Lab" ID="Label3" runat="server" Text="Receiver Details : "></asp:Label><br /><br />
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server"
                        ConnectionString='<%$ ConnectionStrings:ITRConnectionString %>' 
                        SelectCommand="SELECT * FROM [Customers] WHERE ([Name] = @Name)">
                        <SelectParameters>
                            <asp:ControlParameter ControlID="DropDownList1" PropertyName="SelectedValue" Name="Name" Type="String"></asp:ControlParameter>
                        </SelectParameters>
                    </asp:SqlDataSource>
                    <asp:GridView ID="GridView2" DataSourceID="SqlDataSource3" runat="server"></asp:GridView>
                    &nbsp;
                    <hr class="Line"/><br />
                    <asp:Button CssClass="Btn" ID="Button1" runat="server" Text="Next" OnClick="Button1_Click" Width="185px" />  
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button CssClass="Btn" ID="Button2" runat="server" OnClick="Button2_Click" Text="Go Back to Home" /> <br />
                    
                </div>
             </center>
        </div>
    </form>
</body>
</html>
