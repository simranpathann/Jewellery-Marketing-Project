<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Faq.aspx.cs" Inherits="Faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:Label ID="LblFAQ" runat="server" Text="Frequently Asked Questions"></asp:Label><br />
    <asp:DataList ID="DtLstFaq" runat="server">
        <ItemTemplate>
            <table style="width:100%; margin:0 auto;">
                <tr>
                    <td>
                        <asp:Label ID="lblQuestion" runat="server" Text="Question:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuestion" runat="server" Text='<%# Eval("Faq_Question") %>'>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAnswer" runat="server" Text="Answer:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtanswer" runat="server" Height="36px" Text='<%# Eval("Faq_Answer") %>'>' TextMode="MultiLine" Width="400px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:Label ID="lblmessage" Text="LblMessage" runat="server" ForeColor="Red"></asp:Label>
    </asp:Content>

