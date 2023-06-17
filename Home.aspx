<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="slider/js-image-slider.css" rel="stylesheet" />
    <script src="slider/js-image-slider.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="font-weight: 700">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>
        <div class="clear" style="height: 10px;"></div>
        <div class="addrotator">
            <div id="sliderFrame">
                <div id="slider">
                    <img src="slide_images/slide (1).webp" />
                    <img src="slide_images/slide (2).webp" alt="#" />
                    <img src="slide_images/slide (3).jpg" />
                    <img src="slide_images/slide (4).webp" />
                    <img src="slide_images/slide (5).webp" />
                    <img src="slide_images/slide (6).webp" alt="#" />
                    <img src="slide_images/slide (7).webp" />
                    <img src="slide_images/slide (8).jpg" />
                    <img src="slide_images/slide (9).webp" />
                    <img src="slide_images/slide (10).webp" />
                    <img src="slide_images/slide (11).webp" />
                    <img src="slide_images/slide (12).jpg" />
                    <img src="slide_images/slide (13).jpg" />
                    <img src="slide_images/slide (14).jpg" />
                    <img src="slide_images/slide (15).jpg" />
                    <img src="slide_images/slide (16).jpg" />

                </div>
                <div id="htmlcaption" style="display: none">
                    <em>HTML</em> caption. Link To <a href="#">1] Samarth</a>
                </div>
            </div>
        </div>
    </div>
    <div class="clear" style="height: 30px;"></div>
    <div class="Jewellerys">

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
                                    <td style="width: 50%;">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:ImageButton ID="ImgBtnJewelleryImage" runat="server" ImageUrl='<%# Eval("Jewellery_Image") %>' AlternateText='<%# Eval("Jewellery_Id") %>' CommandArgument="ViewJewelleryDetails" BorderWidth="1px" Height="200px" />
                                    </td>
                                    <td>
                                        <table style="width: 100%; text-align:left;">
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
                                                <td>Ratings : </td>
                                                <td>
                                                    <asp:Image ID="ImgRatings" runat="server" ImageUrl='<%# Eval("Jewellery_RatingsImage") %>' Height="20px" />
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
                            </table>
                        </ItemTemplate>

                    </asp:DataList>
                </td>
            </tr>
        </table>

    </div>
     <div class="clear" style="height: 20px;"></div>    
    <p style="font-size:x-large; text-align:center; color:orange;">Shop by Category</p>
    <div class="category">
         <asp:DataList ID="DtLstCategory" runat="server" RepeatColumns="6" RepeatDirection="Horizontal" OnItemCommand="DtLstCategory_ItemCommand" HorizontalAlign="Center" Width="80%">
            <ItemTemplate>
                <table class="border-warning rounded-top table"  style="width: auto; margin: 0 auto; text-align: center; border:solid thin; border-radius:10px 10px;">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImgBtnCatImage" CommandArgument="Category" runat="server" CssClass="rounded" ImageUrl='<%# Eval("Category_Image") %>' Width="150px"   />
                       
                            <asp:Label ID="LblCategoryName" runat="server" Text='<%# Eval("Category_Name") %>' Font-Size="Smaller" > </asp:Label>

                        </td>
                    </tr>
                </table>

            </ItemTemplate>
        </asp:DataList>
    </div>
     <div class="clear" style="height: 20px; margin:0 auto; text-align:center;"></div>    
    <div>
         <p style="font-size:x-large; text-align:center; color:orange;">Shop by Gender</p>
        <table class="table" style="width:60%; margin:0 auto; text-align:center; border:solid 1px orange; ">
            <tr>
                <td>
                    <asp:ImageButton runat="server" ID="ImgBtnWomen" Height="200px" PostBackUrl="~/ViewJewellery.aspx?category=Female" ImageUrl="~/Assets/banu2.webp" CssClass="rounded" Width="300px" />
                    <br />
                    <asp:Label ID="lblWomen" runat="server" Text="Women" Font-Size="Smaller"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton runat="server" ID="ImgBtnMen" ImageUrl="~/Assets/malhari.webp" CssClass="rounded" Width="300px" PostBackUrl="~/ViewJewellery.aspx?category=Male" />
                            <br />
                      <asp:Label ID="lblMen" runat="server" Text="Men" Font-Size="Smaller"></asp:Label>
                </td>
                <td>
                    <asp:ImageButton runat="server" ID="ImgBtnKids" ImageUrl="~/Assets/cute-indian-baby-girl-photos-131.jpg" CssClass="rounded" Width="300px" Height="200px" PostBackUrl="~/ViewJewellery.aspx?category=Kids"/>
                            <br />
                      <asp:Label ID="lblKids" runat="server" Text="Kids" Font-Size="Smaller"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
     <div class="clear" style="height: 20px;"></div>    
    <p style="font-size:x-large; text-align:center; color:orange;">Shop by Brand</p>
    <div class="category">
         <asp:DataList ID="DtLstBrand" runat="server" RepeatColumns="6" RepeatDirection="Horizontal"  HorizontalAlign="Center" Width="80%" OnItemCommand="DtLstBrand_ItemCommand" >
            <ItemTemplate>
                <table class="border-warning rounded-top table"  style="width: auto; margin: 0 auto; text-align: center; border:solid thin; border-radius:10px 10px;">
                    <tr>
                        <td>
                            <asp:ImageButton ID="ImgBtnBrandImage" CommandArgument="Brand" runat="server" CssClass="rounded" ImageUrl='<%# Eval("Brand_Image") %>' Height="200px" Width="190px"   />
                        <br />
                            <asp:Label ID="LblBrandName" runat="server" Text='<%# Eval("Brand_Name") %>' Font-Size="Smaller" > </asp:Label></td>
                    </tr>
                </table>

            </ItemTemplate>
        </asp:DataList>
    </div>
      <div class="clear" style="height: 20px;"></div>    
</asp:Content>

