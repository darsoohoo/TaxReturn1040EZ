<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Results.aspx.vb" Inherits="WebApplication1.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
        }
        .auto-style3 {
            width: 197px;
            text-align: right;
        }
        .auto-style5 {
            width: 557px;
            height: 23px;
        }
        .auto-style7 {
            width: 197px;
            height: 23px;
            text-align: right;
        }
        .auto-style8 {
            width: 162px;
            text-align: right;
        }
        .auto-style9 {
            width: 162px;
            height: 23px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td>Tax Payer ID:&nbsp;
                <asp:Label ID="lblTaxPayerID" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Tax Payer Last Name:
                <br />
                <asp:TextBox ID="txtLastName" runat="server" Height="16px"></asp:TextBox>
            </td>
            <td>Tax Payer First Name:
                <br />
                <asp:TextBox ID="txtFirstName" runat="server" Height="16px"></asp:TextBox>
            </td>
            <td>Tax Payer MI:<br />
                <asp:TextBox ID="txtMI" runat="server" Height="16px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Tax Payer City:
                <br />
                <asp:TextBox ID="txtCity" runat="server" Height="16px"></asp:TextBox>
            </td>
            <td>Tax Payer State:
                <br />
                <asp:TextBox ID="txtState" runat="server" Height="16px"></asp:TextBox>
            </td>
            <td>Tax Payer Zip Code:<br />
                <asp:TextBox ID="txtZip" runat="server" Height="16px"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 67%;">
        <tr>
            <td class="auto-style2">Individual of joint tax return?</td>
            <td class="auto-style8">
                <asp:Label ID="lblIndivOrJoint" runat="server"></asp:Label>
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">1. Wages, salaries, and tips.</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtWages" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">2. Taxable interest.</td>
            <td class="auto-style9">
                <asp:TextBox ID="txtTaxableInterest" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style5">3. Unemployment compensation.</td>
            <td class="auto-style9">
                <asp:TextBox ID="txtUnemploymentCompensation" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style2">4. Added lines 1, 2, and 3. This is your adjusted gross income.</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">
                <asp:Label ID="lblGrossIncome" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">5. Number of dependent tax payers.</td>
            <td class="auto-style9">
                <asp:Label ID="lblDependents" runat="server" style="text-align: right"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:Label ID="lblDeductions" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">6. Subtracted line 5 from line 4. This is your taxable income.</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">
                <asp:Label ID="lblTaxableIncome" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">7. Federal income tax withheld from box 2 of your Form(s) W-2.</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtIncomeTaxWithheld" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">8a. Earned income credit (EIC)</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtEIC" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">8b. Nontaxable combat pay election.</td>
            <td class="auto-style8">
                <asp:TextBox ID="txtCombatPay" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">9. Added lines 7, 8a, and 8b. These are your total payments.</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">
                <asp:Label ID="lblTotalPayments" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">10. Calculated your tax.</td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">
                <asp:Label ID="lblTax" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblTaxReturnText" runat="server"></asp:Label>
            </td>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style3">
                <asp:Label ID="lblReturnAmount" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style8">
                <asp:Button ID="btnGoBack" runat="server" Text="Go Back" />
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="3">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
