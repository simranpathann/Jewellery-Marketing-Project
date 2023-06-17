<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="ViewUserProfile.aspx.cs" Inherits="ViewUserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>

        <table style="width: 60%; margin: 0 auto;">
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Image ID="ImgPhoto" runat="server" Width="200px" BorderColor="Gray" BorderStyle="Solid" BorderWidth="2px" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LblPhotoPath" runat="server" ForeColor="Green"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
           
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:FileUpload ID="FUImages" runat="server" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label ID="LblMessage1" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnUploadPhoto" runat="server" Text="Upload Photo" Width="100px" OnClick="BtnUploadPhoto_Click" />
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblUserFullName" runat="server" Text="User FullName:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtUserFullName" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvUseFullName" runat="server" ControlToValidate="TxtUserFullName" ErrorMessage="Please Enter Your FullName" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAddress" runat="server" Text="Address:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtAddress" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvAddress" runat="server" ControlToValidate="TxtAddress" ErrorMessage="Please Enter Address" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblCity" runat="server" Text="City:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DdlCity" runat="server" Width="200px" OnSelectedIndexChanged="DdlCity_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvCity" runat="server" ControlToValidate="DdlCity" ErrorMessage="Please Select City" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPincode" runat="server" Text="Pincode:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtPincode" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvPincode" runat="server" ErrorMessage="Please Enter Pincode" ForeColor="Red" ControlToValidate="TxtPincode"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblMobile" runat="server" Text="Mobile:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtMobile" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvMobile" runat="server" ControlToValidate="TxtMobile" ErrorMessage="Please Enter Mobile Number" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Please Enter Email" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RevEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:LinkButton ID="LnkBtnChangePassword" runat="server">Change Password</asp:LinkButton>
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
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
                    <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" />
                </td>
                <td>
                    <asp:LinkButton ID="LnkBtnDeleteProfile" runat="server" OnClick="LnkBtnDeleteProfile_Click">Delete Profile</asp:LinkButton>
                </td>
            </tr>
        </table>

    </div>
</asp:Content>

