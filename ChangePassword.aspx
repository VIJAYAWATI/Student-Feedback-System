<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            height: 36px;
        }
        .style7
        {
            height: 60px;
        }
        .style9
        {
            height: 40px;
        }
        .style10
        {
            height: 32px;
        }
        .style11
        {
            height: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p style="margin-left: 400px">
        &nbsp;<table align="center" style="border: medium solid #ff6699; width: 481px;">
            <tr>
                <td align="center" class="style7" colspan="2">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Size="X-Large" 
                        Text="Change Password "></asp:Label>
                </td>
            </tr>
                            <tr>
                <td class="style6">
                    <asp:Label ID="Label4" runat="server" Text="Old Password:" Font-Size="Large"></asp:Label>
                </td>
                <td class="style6">
                    <asp:TextBox ID="txtOldPassword" runat="server" Width="219px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtOldPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style10">
                    <asp:Label ID="Label5" runat="server" Font-Size="Large" Text="New Password:"></asp:Label>
                </td>
                <td class="style10">
                    <asp:TextBox ID="txtNewPassword" runat="server" Width="217px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtNewPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:Label ID="Label6" runat="server" Text="Confirm New Password:" 
                        Font-Size="Large"></asp:Label>
                </td>
                <td class="style9">
                    <asp:TextBox ID="txtConfirmNewPassword" runat="server" Width="215px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtConfirmNewPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td align="center" class="style11" colspan="2">
                    <asp:Button ID="Button1" runat="server" Text="Change" Width="117px" 
                        onclick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="Cancel" Width="113px" />
                    <asp:Label ID="lblmsg" runat="server" Font-Size="Large" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
        </table>
        <td align="center" class="style7" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

    </p>
    <p style="margin-left: 400px">
        &nbsp;</p>
    <p style="margin-left: 400px">
        &nbsp;</p>
    <p style="margin-left: 400px">
        &nbsp;</p>
    <p style="margin-left: 400px">
        &nbsp;</p>
    <p style="margin-left: 400px">
        &nbsp;</p>
    <p style="margin-left: 400px">
        &nbsp;</p>
    <p style="margin-left: 400px">
                </td>
            </tr>
            <tr>
                <td align="center" class="style7" colspan="2">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label9" runat="server" 
                        Text="New passwords are required to be a minimum of  characters in length.   "></asp:Label>
                </td>
            </tr>

    </p>
</asp:Content>

