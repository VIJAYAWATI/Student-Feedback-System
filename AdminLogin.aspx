<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="AdminLogin" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
       /* background-image: url('images/url.jpeg');*/
    }
    .style7
    {
        height: 40px;
    }
    .style8
    {
        height: 43px;
    }
    .style10
    {
        height: 49px;
    }
        .style11
        {
            height: 42px;
            width: 1237px;
        }
        .style12
        {
            height: 61px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style6" 
        style="border: thin solid #000000; width: 491px; height: 295px;">
    <tr>
        <td class="style12">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/images6.jpeg" 
                Height="104px" Width="117px" />
        </td>
        <td class="style12">
            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="X-Large" 
                Text="Administrator Login"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style11">
            <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="Large" 
                Text="Admin ID"></asp:Label>
        </td>
        <td class="style11">
            <asp:TextBox ID="txtAdminID" runat="server" Width="217px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtAdminID" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style8">
            <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Large" 
                Text="Password"></asp:Label>
        </td>
        <td class="style8">
            <asp:TextBox ID="txtPassword" runat="server" Width="214px" TextMode="Password" 
                MaxLength="10" Height="27px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr align="center">
        <td class="style10" colspan="2">
            <asp:Button ID="Button1" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Submit" Width="100px" onclick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Font-Bold="True" Font-Size="Medium" 
                Text="Cancel" onclick="Button2_Click" />
            <br />
            <asp:Label ID="lblmsg" runat="server" style="font-size: x-large"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

