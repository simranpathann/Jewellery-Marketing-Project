<%@ Page Title="" Language="C#" MasterPageFile="~/UserMasterPage.master" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 70%; margin: 0 auto;">
        <tr>
            <td>
                <asp:Label ID="LblUserRegistration" runat="server" Font-Bold="True" Text="User Registration"></asp:Label>
            </td>
            <td>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            </td>
            <td>&nbsp;</td>
        </tr>

        <tr>
            <td >
                <asp:Label ID="LblUserName" runat="server" Text="User Name :"></asp:Label>
            </td>
            <td >
                <asp:TextBox ID="TxtUserName" runat="server" Width="200px" Font-Size="Medium"></asp:TextBox>
            </td>
            <td >
                <asp:RequiredFieldValidator ID="RfvUserName" runat="server" ControlToValidate="TxtUserName" ErrorMessage="Please Enter User Name" ForeColor="Red" ValidationGroup="VgSubmit"></asp:RequiredFieldValidator>
            </td>
        </tr>

        <tr>
            <td>
                <asp:Label ID="LblAdress" runat="server" Text="User Address :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtAddress" runat="server" Width="200px" Font-Size="Medium" TextMode="MultiLine"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfvUserAddress" runat="server" ControlToValidate="TxtAddress" ErrorMessage="Please Enter Address" ForeColor="Red" ValidationGroup="VgSubmit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblUserCity" runat="server" Text="User City :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="DdlCity" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DdlCity_SelectedIndexChanged" Width="200px">
                        </asp:DropDownList>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DdlCity" />
                    </Triggers>
                </asp:UpdatePanel>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfvUserCity" runat="server" ControlToValidate="DdlCity" ErrorMessage="Please Select  City Name" ForeColor="Red" InitialValue="--SELECT--" ValidationGroup="VgSubmit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblPinCoad" runat="server" Text="Pin Code :"></asp:Label>
            </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                    <ContentTemplate>

                        <asp:TextBox ID="TxtPin" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
                        </td>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="DdlCity" />
                    </Triggers>
                </asp:UpdatePanel>
                <td>
                    <asp:RequiredFieldValidator ID="RfvUserPin" runat="server" ControlToValidate="TxtPin" ErrorMessage="Please Enter Pin:" ForeColor="Red" ValidationGroup="VgSubmit"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RevPin" runat="server" ControlToValidate="TxtPin" ErrorMessage="Invalid Pincode" ForeColor="Red" ValidationExpression="\d{6}" ValidationGroup="VgSubmit"></asp:RegularExpressionValidator>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblUserMobile" runat="server" Text="User Mobile :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtUserMobile" runat="server" Font-Size="Medium" Width="200px" MaxLength="10"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfvUserMobile" runat="server" ControlToValidate="TxtUserMobile" ErrorMessage="Please Enter User Mobile:" ForeColor="Red" ValidationGroup="VgSubmit"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RevMobile" runat="server" ControlToValidate="TxtUserMobile" ErrorMessage="Invalid Mobile:" ForeColor="Red" ValidationExpression="\d{10}" ValidationGroup="VgSubmit"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblUserEmail" runat="server" Text="User Email :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtUserEmail" runat="server" Font-Size="Medium" Width="200px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ControlToValidate="TxtUserEmail" ErrorMessage="Enter Email Address" ForeColor="Red"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RevEmail" runat="server" ControlToValidate="TxtUserEmail" ErrorMessage="Invalid Email" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="VgSubmit"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblUserPassword" runat="server" Text="User Password :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtPassword" runat="server" Width="200px" Font-Size="Medium" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfvUserPassword" runat="server" ControlToValidate="TxtPassword" ErrorMessage="Please Enter User Password:" ForeColor="Red" ValidationGroup="VgSubmit"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblUserPassword0" runat="server" Text="Confirm Password :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtConfirmPassword" runat="server" Width="200px" Font-Size="Medium" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RfvConfirmPassword" runat="server" ControlToValidate="TxtConfirmPassword" ErrorMessage="Please Enter Passwrod" ForeColor="Red" ValidationGroup="VgSubmit"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToCompare="TxtPassword" ControlToValidate="TxtConfirmPassword" ErrorMessage="Password Missmatch" ForeColor="Red" ValidationGroup="VgSubmit"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" ValidationGroup="VgSubmit" Width="100px" />
                <asp:Button ID="BtnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" Width="100px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

