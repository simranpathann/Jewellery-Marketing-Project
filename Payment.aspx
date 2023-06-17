<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:90%; margin:auto;">
        <tr>
            <td>
                <asp:Label ID="LblPaymentInformation" runat="server" Text="PaymentInformation"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblCardType" runat="server" Text="CardType:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="DdlCardType" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfvCardType" runat="server" ControlToValidate="DdlCardType" ErrorMessage="Please Select Card Type" ForeColor="Red" ValidationGroup="VGrpSubmit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="LblCardNumber" runat="server" Text="CardNumber:"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="TxtCardNumber" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td >
                <asp:RequiredFieldValidator ID="RfvCardNumber" runat="server" ControlToValidate="TxtCardNumber" ErrorMessage="Please Enter Card Number" ForeColor="Red" ValidationGroup="VGrpSubmit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="LblNameOnCard" runat="server" Text="NameOnCard:"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="TxtNameOnCard" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td >
                <asp:RequiredFieldValidator ID="RfvNameOnCard" runat="server" ControlToValidate="TxtNameOnCard" ErrorMessage="Please Enter Name On Card" ForeColor="Red" ValidationGroup="VGrpSubmit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="LblExpireDate" runat="server" Text="ExpireDate:"></asp:Label>
            </td>
            <td >
                <asp:DropDownList ID="DdlMonth" runat="server" Width="100px">
                </asp:DropDownList>
                <asp:DropDownList ID="DdlYear" runat="server" Width="100px">
                </asp:DropDownList>
            </td>
            <td >
                <asp:RequiredFieldValidator ID="RfvExpireDate" runat="server" ErrorMessage="Please Enter ExpireDate" ForeColor="Red" ValidationGroup="VGrpSubmit" ControlToValidate="DdlYear"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="LblCVVNumber" runat="server" Text="CVVNumber:"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="TxtCVVNumber" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td >
                <asp:RequiredFieldValidator ID="RfvCVVNumber" runat="server" ControlToValidate="TxtCVVNumber" ErrorMessage="Please Enter CVV Number" ForeColor="Red" ValidationGroup="VGrpSubmit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="LblCardIssuingBank" runat="server" Text="CardIssuingBank:"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="TxtCardIssuingBank" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td >&nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="LLblAmount" runat="server" Text="Amount:"></asp:Label>
            </td>
            <td >
                <asp:Label ID="LblAmount" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Red"></asp:Label>
            </td>
            <td >&nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td >&nbsp;</td>
            <td >&nbsp;</td>
        </tr>
        <tr>
            <td >&nbsp;</td>
            <td >
                <asp:Button ID="BtnPayNow" runat="server" Text="PayNow" OnClick="BtnPayNow_Click" />
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" />
            </td>
            <td >&nbsp;</td>
        </tr>
    </table>
</asp:Content>

