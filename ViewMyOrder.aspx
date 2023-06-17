<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="ViewMyOrder.aspx.cs" Inherits="ViewMyOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="text-align:center; width:100%; margin:0 auto">
        <tr>
            <td>
                <hr />
                <asp:Label ID="LblOrderDetails" runat="server" Font-Bold="True" Font-Size="Larger" ForeColor="Red" Text="Your Last Order"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <hr />
                <asp:Button ID="BtnBackToHome" runat="server" BackColor="#003366" Font-Bold="True" ForeColor="White" Text="Back To Home" Height="30px" PostBackUrl="~/Home.aspx" Width="150px" />
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="LblMessage" runat="server"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

