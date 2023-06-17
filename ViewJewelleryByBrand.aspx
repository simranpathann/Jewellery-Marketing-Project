<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="ViewJewelleryByBrand.aspx.cs" Inherits="ViewJewelleryByBrand" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="dlTable" style="text-align: center; margin: 0 auto;">
            <tr>
                <td>
                    <asp:DataList ID="DtLstJewellery" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemCommand="DtLstJewellerys_ItemCommand">
                        <ItemTemplate>
                            <table class="dlTable" style="text-align: center; margin: 0 auto; border: 1px solid #ff6a00;">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblJewelleryName" runat="server" Font-Bold="true" ForeColor="Blue" Text='<%# Eval("Jewellery_Name") %>'></asp:Label>
                                    </td>
                                    <td class="auto-style1">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImgBtnJewelleryImage" runat="server" ImageUrl='<%# Eval("Jewellery_Image") %>' AlternateText='<%# Eval("Jewellery_Id") %>' CommandArgument="ViewJewelleryDetails" BorderWidth="1px" Height="200px" />
                                    </td>
                                    <td class="auto-style1">
                                        <table style="width: 100%; text-align:left;">
                                            <tr>
                                                <td>Brand Name:</td>
                                                <td>
                                                     <asp:Label ID="LblBrandName" runat="server" Font-Bold="true" Font-Size="Medium"  ForeColor="Red" Text='<%# Eval("Jewellery_Brand") %>'></asp:Label>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td>MRP : Rs.</td>
                                                <td>
                                                    <asp:Label ID="LblJewelleryMRP" runat="server" Font-Bold="true" Font-Size="Medium" Font-Strikeout="true" ForeColor="Red" Text='<%# Eval("Jewellery_MRP") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>New Price : Rs.</td>
                                                <td>
                                                    <asp:Label ID="lblJewelleryPrice" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Red" Text='<%# Eval("Jewellery_OldPrice") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Available Only:</td>
                                                <td>
                                                    <asp:Label ID="lblAvailableOnly" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Blue" Text='<%# Eval("Jewellery_Stock") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><asp:ImageButton ID="ImgBtnBuyNow" runat="server" AlternateText='<%# Eval("Jewellery_Id") %>' CommandArgument="BuyNow" Height="30px" ImageUrl="~/Images/BuyNowYellow.png" Width="100px" /></td>
                                                <td>
                                                    <asp:ImageButton ID="ImgBtnAddToCart" runat="server" AlternateText='<%# Eval("Jewellery_Id") %>' CommandArgument="AddToCart" Height="30px" ImageUrl="~/Images/AddToCart.png" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width:100%;">
                                            <tr>
                                                <td> <asp:Image ID="ImgModel1" runat="server" AlternateText='<%# Eval("Jewellery_Id") %>' CommandArgument="AddToCart" Height="100px" Width="100px" /></td>
                                                <td> <asp:Image ID="ImgModel2" runat="server" AlternateText='<%# Eval("Jewellery_Id") %>' CommandArgument="AddToCart" Height="100px" Width="100px" /></td>
                                                <td> <asp:Image ID="ImgModel3" runat="server" AlternateText='<%# Eval("Jewellery_Id") %>' CommandArgument="AddToCart" Height="100px" Width="100px" /></td>
                                            </tr>
                                      
                                        </table>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </ItemTemplate>

                    </asp:DataList>
                </td>
            </tr>
        </table>
</asp:Content>

