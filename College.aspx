<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="College.aspx.cs" Inherits="College" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" style="height: 229px; width: 322px">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                    Text="COLLEGE"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Institute Code:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtInstituteCode" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtInstituteCode" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Institute Name :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtInstituteName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtInstituteName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Establish Year :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEstablishYear" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtEstablishYear" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btnSubmit" runat="server" onclick="Button1_Click" 
                    Text="Submit" />
                <asp:Button ID="btnReset" runat="server" Text="Reset" />
            </td>
        </tr>
    </table>
</asp:Content>

