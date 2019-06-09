<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="WebApplication1._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>Tax Return</h1>
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <table style="width:100%;">
    <tr>
        <td class="auto-style6">Step 1: Select your Tax Payer ID</td>
        <td class="auto-style2">Step 2: Verify your Information. If you information has changed, please provide your current information.</td>
        <td>Step 3: Type your Tax Year</td>
    </tr>
    <tr>
        <td class="auto-style3">
            <asp:ListBox ID="lstID" runat="server" DataSourceID="TaxPayerID" DataTextField="TaxPayerID" DataValueField="TaxPayerID" Height="143px" AutoPostBack="True"></asp:ListBox>
            <asp:SqlDataSource ID="TaxPayerID" runat="server" ConnectionString="<%$ ConnectionStrings:TaxReturn %>" SelectCommand="SELECT [TaxPayerID] FROM [tblTaxPayer]"></asp:SqlDataSource>
        </td>
        <td class="auto-style4">
            <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="TaxPayerID" DataSourceID="TaxPayerDetails" Height="50px" Width="125px">
                <Fields>
                    <asp:BoundField DataField="TaxPayerID" HeaderText="TaxPayerID" ReadOnly="True" SortExpression="TaxPayerID" />
                    <asp:BoundField DataField="TaxPayerLastName" HeaderText="TaxPayerLastName" SortExpression="TaxPayerLastName" />
                    <asp:BoundField DataField="TaxPayerFirstName" HeaderText="TaxPayerFirstName" SortExpression="TaxPayerFirstName" />
                    <asp:BoundField DataField="TaxPayerInitial" HeaderText="TaxPayerInitial" SortExpression="TaxPayerInitial" />
                    <asp:BoundField DataField="TaxPayerAddress" HeaderText="TaxPayerAddress" SortExpression="TaxPayerAddress" />
                    <asp:BoundField DataField="TaxPayerCity" HeaderText="TaxPayerCity" SortExpression="TaxPayerCity" />
                    <asp:BoundField DataField="TaxPayerState" HeaderText="TaxPayerState" SortExpression="TaxPayerState" />
                    <asp:BoundField DataField="TaxPayerZip" HeaderText="TaxPayerZip" SortExpression="TaxPayerZip" />
                </Fields>
            </asp:DetailsView>
            <asp:SqlDataSource ID="TaxPayerDetails" runat="server" ConnectionString="<%$ ConnectionStrings:TaxPayerData %>" SelectCommand="SELECT [TaxPayerID], [TaxPayerLastName], [TaxPayerFirstName], [TaxPayerInitial], [TaxPayerAddress], [TaxPayerCity], [TaxPayerState], [TaxPayerZip] FROM [tblTaxPayer] WHERE ([TaxPayerID] = @TaxPayerID2)" ConflictDetection="CompareAllValues" DeleteCommand="DELETE FROM [tblTaxPayer] WHERE [TaxPayerID] = @original_TaxPayerID AND [TaxPayerLastName] = @original_TaxPayerLastName AND [TaxPayerFirstName] = @original_TaxPayerFirstName AND [TaxPayerInitial] = @original_TaxPayerInitial AND [TaxPayerAddress] = @original_TaxPayerAddress AND [TaxPayerCity] = @original_TaxPayerCity AND [TaxPayerState] = @original_TaxPayerState AND [TaxPayerZip] = @original_TaxPayerZip" InsertCommand="INSERT INTO [tblTaxPayer] ([TaxPayerID], [TaxPayerLastName], [TaxPayerFirstName], [TaxPayerInitial], [TaxPayerAddress], [TaxPayerCity], [TaxPayerState], [TaxPayerZip]) VALUES (@TaxPayerID, @TaxPayerLastName, @TaxPayerFirstName, @TaxPayerInitial, @TaxPayerAddress, @TaxPayerCity, @TaxPayerState, @TaxPayerZip)" OldValuesParameterFormatString="original_{0}" UpdateCommand="UPDATE [tblTaxPayer] SET [TaxPayerLastName] = @TaxPayerLastName, [TaxPayerFirstName] = @TaxPayerFirstName, [TaxPayerInitial] = @TaxPayerInitial, [TaxPayerAddress] = @TaxPayerAddress, [TaxPayerCity] = @TaxPayerCity, [TaxPayerState] = @TaxPayerState, [TaxPayerZip] = @TaxPayerZip WHERE [TaxPayerID] = @original_TaxPayerID AND [TaxPayerLastName] = @original_TaxPayerLastName AND [TaxPayerFirstName] = @original_TaxPayerFirstName AND [TaxPayerInitial] = @original_TaxPayerInitial AND [TaxPayerAddress] = @original_TaxPayerAddress AND [TaxPayerCity] = @original_TaxPayerCity AND [TaxPayerState] = @original_TaxPayerState AND [TaxPayerZip] = @original_TaxPayerZip">
                <DeleteParameters>
                    <asp:Parameter Name="original_TaxPayerID" Type="Int64" />
                    <asp:Parameter Name="original_TaxPayerLastName" Type="String" />
                    <asp:Parameter Name="original_TaxPayerFirstName" Type="String" />
                    <asp:Parameter Name="original_TaxPayerInitial" Type="String" />
                    <asp:Parameter Name="original_TaxPayerAddress" Type="String" />
                    <asp:Parameter Name="original_TaxPayerCity" Type="String" />
                    <asp:Parameter Name="original_TaxPayerState" Type="String" />
                    <asp:Parameter Name="original_TaxPayerZip" Type="String" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="TaxPayerID" Type="Int64" />
                    <asp:Parameter Name="TaxPayerLastName" Type="String" />
                    <asp:Parameter Name="TaxPayerFirstName" Type="String" />
                    <asp:Parameter Name="TaxPayerInitial" Type="String" />
                    <asp:Parameter Name="TaxPayerAddress" Type="String" />
                    <asp:Parameter Name="TaxPayerCity" Type="String" />
                    <asp:Parameter Name="TaxPayerState" Type="String" />
                    <asp:Parameter Name="TaxPayerZip" Type="String" />
                </InsertParameters>
                <SelectParameters>
                    <asp:ControlParameter ControlID="lstID" Name="TaxPayerID2" PropertyName="SelectedValue" Type="Int64" DefaultValue="0" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="TaxPayerLastName" Type="String" />
                    <asp:Parameter Name="TaxPayerFirstName" Type="String" />
                    <asp:Parameter Name="TaxPayerInitial" Type="String" />
                    <asp:Parameter Name="TaxPayerAddress" Type="String" />
                    <asp:Parameter Name="TaxPayerCity" Type="String" />
                    <asp:Parameter Name="TaxPayerState" Type="String" />
                    <asp:Parameter Name="TaxPayerZip" Type="String" />
                    <asp:Parameter Name="original_TaxPayerID" Type="Int64" />
                    <asp:Parameter Name="original_TaxPayerLastName" Type="String" />
                    <asp:Parameter Name="original_TaxPayerFirstName" Type="String" />
                    <asp:Parameter Name="original_TaxPayerInitial" Type="String" />
                    <asp:Parameter Name="original_TaxPayerAddress" Type="String" />
                    <asp:Parameter Name="original_TaxPayerCity" Type="String" />
                    <asp:Parameter Name="original_TaxPayerState" Type="String" />
                    <asp:Parameter Name="original_TaxPayerZip" Type="String" />
                </UpdateParameters>
            </asp:SqlDataSource>
        </td>
        <td class="auto-style5">
            <asp:TextBox ID="txtTaxYear" runat="server" Width="183px">2014</asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:Button ID="btnViewReturn" runat="server" Text="View Tax Return" />
        </td>
        <td class="auto-style2">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
    .auto-style1
    {
        width: 210px;
    }
    .auto-style2
    {
        width: 355px;
    }
        .auto-style3
        {
            width: 231px;
            font-size: medium;
            height: 230px;
        }
        .auto-style4
        {
            width: 355px;
            height: 230px;
        }
        .auto-style5
        {
            height: 230px;
        }
        .auto-style6 {
            width: 231px;
            font-size: medium;
        }
    </style>
</asp:Content>

