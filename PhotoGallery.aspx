<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PhotoGallery.aspx.cs" Inherits="PhotoGallery" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style9
    {
    }
        .style11
        {
            width: 163px;
        height: 51px;
    }
        .style12
    {
            height: 51px;
        }
    .style13
    {
        width: 190px;
    }
    .style14
    {
        height: 51px;
        width: 190px;
    }
    .style15
    {
        height: 33px;
    }
        .style16
        {
            width: 163px;
            height: 6px;
        }
        .style17
        {
            width: 190px;
            height: 6px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" 
        style="border: thin solid #000000; height: 288px; width: 592px">
    <tr>
        <td align="center" class="style15" colspan="2">
            <asp:Label ID="Label4" runat="server" Font-Size="XX-Large" Text="PHOTO GALLERY"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style16">
            <asp:Label ID="Label5" runat="server" Text="Title"></asp:Label>
        </td>
        <td class="style17">
            <asp:TextBox ID="txtTitle" runat="server" Height="22px" Width="212px"></asp:TextBox>
        </td>
    </tr>
    <tr>
            <td class="style11">
                <asp:Label ID="Label13" runat="server" Text="Upload Photo" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td class="style14">
                <asp:FileUpload ID="fileStdImage" runat="server"/>
            </td>
            <td class="style12">
                    <asp:Button ID="btnUpload" runat="server" CausesValidation="False" 
                        OnClick="Upload" Text="Upload" />
            </td>
            <td class="style12">
                    <asp:Image ID="Image1" runat="server" Height="92px" Width="93px"/>
            </td>
        </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="Label7" runat="server" Text="Description"></asp:Label>
        </td>
        <td class="style13">
            <asp:TextBox ID="txtDescription" runat="server" Height="29px" 
                TextMode="MultiLine" Width="208px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style9" colspan="2">
            <asp:Button ID="Button2" runat="server" Height="40px" onclick="Button2_Click" 
                Text="Save" Width="112px" />
            <asp:Button ID="Button1" runat="server" Height="39px" Text="Cancel" 
                Width="118px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Label ID="lblmsg" runat="server"></asp:Label>
        </td>
    </tr>
</table>
</asp:Content>

