<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <table style="width: 100%;">
        <tr>
            <td>
                <asp:Label ID="LblContactUs" runat="server" Text="ContactUs"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblUserFullName" runat="server" Text="UserFullName:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtUserFullName" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfvUserFullName" runat="server" ControlToValidate="TxtUserFullName" ErrorMessage="Please Enter Your FullName" ForeColor="Red" ValidationGroup="VGrpSubmit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblUserEmail" runat="server" Text="UserEmail:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtUserEmail" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfvUserEmail" runat="server" ControlToValidate="TxtUserEmail" ErrorMessage="Please Enter Email" ForeColor="Red" ValidationGroup="VGrpSubmit"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RevEmail" runat="server" ControlToValidate="TxtUserEmail" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="VGrpSubmit"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>

                <asp:Label ID="LblMessage" runat="server" Text="Message:"></asp:Label>

            </td>
            <td>
                <asp:TextBox ID="TxtMessage" runat="server" Width="200px" Height="100px" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="LblMessage1" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" ValidationGroup="VGrpSubmit" OnClick="BtnSubmit_Click" />
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

