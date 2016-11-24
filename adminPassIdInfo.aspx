<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="adminPassIdInfo.aspx.cs" Inherits="adminPassIdInfo" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
        {
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="border: thin solid #000000; height: 236px; width: 585px;">
        <tr>
            <td colspan="2">
                &nbsp;
                <asp:Label ID="Label4" runat="server" Font-Size="X-Large" 
                    Text="Admin ID Password Allocation"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:Label ID="Label5" runat="server" Text="Admin Name:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdminName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtAdminName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:Label ID="Label6" runat="server" Text="Admin Id:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdminId" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtAdminId" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style9">
                <asp:Label ID="Label7" runat="server" Text="Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAdminPass" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtAdminPass" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style9" colspan="2">
                <asp:Button ID="btnallocate" runat="server"  
                    Text="Update" onclick="btnallocate_Click1" />
                <asp:Button ID="btndelete" runat="server" Text="Cancel" 
                    onclick="btndelete_Click" />
                <br />
                <br />
                <asp:Label ID="lblmsg" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

