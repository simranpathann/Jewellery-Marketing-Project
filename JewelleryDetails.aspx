<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="JewelleryDetails.aspx.cs" Inherits="JewelleryDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    

    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <script src="js/bootstrap.bundle.min.js"></script>
       
    <style> /*css*/
        .zoom {
         padding:10px;
         transition:transform .2s;
         width:150px;
         height:300px;
         margin:0 auto;
        
        }
        .zoom:hover {
         transform:scale(1.5);
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%; margin: 0 auto;">
        <tr>

            <td>
                <table style="width: 100%; text-align:center" >
                    <tr>
                        <td class="zoom">
                            <asp:ImageButton ID="ImgPhoto" runat="server" Height="200px" CssClass="rounded" />
                        </td>
                    </tr>
                    <tr style="height: 200px;">
                        <td>
                            <asp:Panel ID="pnlModels" runat="server" Width="300px">
                                <asp:DataList ID="DtLstModel" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"  HorizontalAlign="Center" Width="80%" >
                                    <ItemTemplate>
                                        <table ">

                                            <tr>

                                                <td class="zoom">
                                                      <asp:ImageButton ID="ImageBtnModel1" CommandArgument="Category" runat="server" CssClass="rounded" ImageUrl='<%# Eval("Jewellery_Model1") %>' Width="150px" />

                                                </td>

                                                 <td class="zoom">
                                                      <asp:ImageButton ID="ImageBtnModel2" CommandArgument="Category" runat="server" CssClass="rounded" ImageUrl='<%# Eval("Jewellery_Model2") %>' Width="150px" />

                                                </td>

                                                 <td class="zoom">
                                                      <asp:ImageButton ID="ImageBtnModel3" CommandArgument="Category" runat="server" CssClass="rounded" ImageUrl='<%# Eval("Jewellery_Model3") %>' Width="150px" />

                                                </td>
                                            </tr>
                                        </table>
                                        <table class="border-warning rounded-top table" style="width: auto; margin: 0 auto; text-align: center; border: solid thin; border-radius: 10px 10px;">
                                            <tr>
                                                <td>


                                                </td>
                                            </tr>
                                        </table>

                                    </ItemTemplate>
                                </asp:DataList>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <asp:Label ID="LblJewelleryName" runat="server" Text="Jewellery Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtJewelleryName" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="LblJewelleryType" runat="server" Text="Jewellery Type:"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="TxtJewelleryType" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="LblJewelleryPrice" runat="server" Text="Jewellery Price:"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:TextBox ID="TxtJewelleryPrice" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblJewellerySellsPrice" runat="server" Text="Jewellery Sells Price:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtJewellerySellsPrice" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblJewelleryMRP" runat="server" Text="Jewellery MRP:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtJewelleryMrp" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblJewelleryBrand" runat="server" Text="Jewellery Brand:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtJewelleryBrand" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblJewelleryDetails" runat="server" Text="Jewellery Details:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtJewelleryDetails" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblJewelleryRaging" runat="server" Text="Jewellery Rating:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtJewelleryRating" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblJewelleryCategory" runat="server" Text="Jewellery Category:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtJewelleryCategory" runat="server" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblYouSave" runat="server" Text="You Save:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblYouSave1" runat="server" Text="00"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style2">
                            <asp:Label ID="LblQuantity" runat="server" Text="Jewellery Quantity:"></asp:Label>
                        </td>
                        <td class="auto-style2">
                            <asp:DropDownList ID="DdlJewelleryQuantity" runat="server" Width="200px" OnSelectedIndexChanged="DdlJewelleryQuantity_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:TextBox ID="TxtStock" runat="server" Width="50px"></asp:TextBox>
                        </td>
                        <td class="auto-style2"></td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:HiddenField ID="HfQuantity" runat="server" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblTotalAmount" runat="server" Text="Sub Total Amount:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="LblSubTotalAmountValue" runat="server" ForeColor="Red" Style="font-weight: 700; font-size: medium"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:ImageButton ID="ImgbtnAddToCart" runat="server" ImageUrl="~/images/AddToCart.png" OnClick="ImgbtnAddToCart_Click" />
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:Label ID="LblMessage2" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                </table>

            </td>
        </tr>

    </table>




    <asp:Panel ID="PnlPayment" runat="server" Visible="False">
    </asp:Panel>
</asp:Content>

