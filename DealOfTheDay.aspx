<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="DealOfTheDay.aspx.cs" Inherits="DealOfTheDay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="Jewellerys">

        <table class="dlTable" style="text-align: center; margin: 0 auto;">
            <tr>
                <td>
                    <asp:DataList ID="DtLstJewellery" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" OnItemCommand="DtLstJewellerys_ItemCommand">
                        <ItemTemplate>
                            <table class="dlTable" style="text-align: center; margin: 0 auto; border: 1px solid #ff6a00;">
                                <tr>
                                    <td style="background-color: black; height:30px">
                                        <asp:Label ID="lblJewelleryName" runat="server" Font-Bold="True" ForeColor="White" Text='<%# Eval("Jewellery_Name") %>'></asp:Label>
                                    </td>
                                    <td style="width: 50%; background-color: black;">
                                        <asp:Label ID="lblDealoftheDay" runat="server" Font-Bold="True" ForeColor="White" Text="Deal of The Day"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImgBtnJewelleryImage" runat="server" ImageUrl='<%# Eval("Jewellery_Image") %>' AlternateText='<%# Eval("Jewellery_Id") %>' CommandArgument="ViewJewelleryDetails" BorderWidth="1px" Height="200px" />
                                    </td>
                                    <td>
                                        <table style="width: 100%; text-align: left;">
                                            <tr>
                                                <td>Discount :</td>
                                                <td>
                                                    <asp:Label ID="lblDiscount" runat="server" Font-Bold="True" ForeColor="#003300" Text="30%"></asp:Label>
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
                                                <td>
                                                    <asp:ImageButton ID="ImgBtnBuyNow" runat="server" CommandArgument="BuyNow" Height="30px" ImageUrl="~/Images/BuyNowYellow.png" Width="100px" /></td>
                                                <td>
                                                    <asp:ImageButton ID="ImgBtnAddToCart" runat="server" CommandArgument="AddToCart" Height="30px" ImageUrl="~/Images/AddToCart.png" Width="100px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

