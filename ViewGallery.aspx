<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="ViewGallery.aspx.cs" Inherits="ViewGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Panel ID="SorryPanel" runat="server" Visible="false" HorizontalAlign="Center">
        <asp:Image ID="ImgSorry" runat="server" ImageUrl="~/images/no_product_found.png" ImageAlign="Middle" />
    </asp:Panel>
     <asp:DataList ID="DtlstGallery"  runat="server" RepeatColumns="4">
        <ItemTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>
                        <asp:Label ID="LblGalleryName" runat="server" Text ='<%# Eval("Gallery_Name") %>'></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="ImgGalleryImage" runat="server" BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" Height="250px" Width="230px" ImageUrl='<%# Eval("Gallery_Image") %>'/>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="LblGalleryDetails" runat="server" Text= '<%# Eval("Gallery_Details") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:Label ID="LblMessage" runat="server" Text="Label"></asp:Label>
</asp:Content>

