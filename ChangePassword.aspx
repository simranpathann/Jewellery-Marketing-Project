<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td><asp:Label ID="LblChangePassword" runat="server" Text="Change Password" Font-Bold="true"></asp:Label></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblOldPassword" Text="Old Password:" runat="server"></asp:Label></td>
            <td><asp:TextBox ID="TxtOldPassword" runat="server" Width="200px"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblNewPassword" runat="server" Text="New Password: "></asp:Label></td>
            <td><asp:TextBox ID="TxtNewPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox></td>
            <td></td>
        </tr>

        <tr>
            <td><asp:Label ID="LblConfirmPassword" runat="server" Text="Confirm Password: "></asp:Label></td>
            <td><asp:TextBox ID="TxtConfirmPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox></td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="BtnChange" runat="server" Text="Change Password" OnClick="BtnChange_Click" /></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label ID="LblMessage" runat="server" Text="" ForeColor="red"></asp:Label></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>

