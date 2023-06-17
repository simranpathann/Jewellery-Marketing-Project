<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script src="js/bootstrap.bundle.min.js"></script>
    <script src="js/bootstrap.min.js"></script>

     <div id="dvMessage" runat="server" visible="false" class="alert alert-danger">
        <strong>Error!</strong>
        <asp:Label ID="LblMessage" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
    </div>
    <div class="form-signin">
        <table style="width: 50%; margin: 0 auto;">
            <tr>
                <td>
                    <asp:Label ID="LblUserLogin" runat="server" Text="User Login" Font-Size="Large" Font-Bold="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Image ID="ImgUserPhoto" runat="server" Width="80px" ImageUrl="~/images/generaluser.png" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblUserEmail" runat="server" Text="User Email:" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TxtUserEmail" runat="server" Width="200px" CssClass="form-control" placeholder="Enter email" required=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVUserName" runat="server" ControlToValidate="TxtUserEmail" ErrorMessage="Pls Enter User Email" ForeColor="Red" ValidationGroup="VgrpSubmit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPassword" runat="server" Text="Password:" Font-Size="Medium"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="TxtPassword" runat="server" Width="200px" Font-Size="Medium" TextMode="Password" CssClass="form-control" placeholder="Enter Password" required=""></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVPassword" runat="server" ControlToValidate="TxtPassword" ErrorMessage="Pls Enter Password" ForeColor="Red" ValidationGroup="VgrpSubmit"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CheckBox ID="ChkRememberMe" runat="server" Text="Remember Me" class="checkbox mb-3" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="LnkBtnForgotPassword" runat="server" PostBackUrl="~/ForgotPassword.aspx">Forgot Password</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnSignIn" runat="server" Text="Sign In"  ValidationGroup="VgrpSubmit" class="w-100 btn btn-lg btn-primary" OnClick="BtnSignIn_Click" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>

