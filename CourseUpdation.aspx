<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CourseUpdation.aspx.cs" Inherits="CourseUpdation" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
        .style1
        {
            font-size: 11px;
            color: #000000;
            font-family: Tahoma;
            text-decoration: none;
            line-height: 15px;
            body;
            }
        .style2
        {
            
        }
        .style5
    {
        
        font-size: 11px;
        color: #000000;
        font-family: Tahoma;
        text-decoration: none;
        line-height: 15px;
        height: 29px;
        width: 180px;
    }
    .style8
    {
        height: 30px;
        width: 238px;
    }
    .style10
    {}
    .style11
    {
        
        font-size: 11px;
        color: #000000;
        font-family: Tahoma;
        text-decoration: none;
        line-height: 15px;
        height: 30px;
        width: 228px;
    }
    .style12
    {
       
        font-size: 11px;
        color: #000000;
        font-family: Tahoma;
        text-decoration: none;
        line-height: 15px;
        height: 43px;
            width: 228px;
        }
    .style13
    {
        width: 238px;
        height: 43px;
    }
        .style14
        {
            font-size: 11px;
            color: #000000;
            font-family: Tahoma;
            text-decoration: none;
            line-height: 15px;
            body;
            height: 40px;
            width: 228px;
        }
        .style16
        {
            font-size: 11px;
            color: #000000;
            font-family: Tahoma;
            text-decoration: none;
            line-height: 15px;
            body;
            height: 23px;
        }
        .style17
        {
            width: 238px;
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
    <br />
 <table 
            align="center" style="border: thin solid #000000">
            <tr align="center">
                <td class="style10" colspan="2" align="left">
        <asp:Label ID="Label7" runat="server" Text="COURSE UPDATE&nbsp;&nbsp;&nbsp; " 
                        Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="Large" 
                        Text="Course Code"></asp:Label>
                </td>
                <td class="style13">
                    <asp:DropDownList ID="ddlCourseCode" runat="server" AutoPostBack="True" 
                        Height="31px" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                        Width="164px">
                    </asp:DropDownList>
                    &nbsp;
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp; [eg:CM,EJ]</td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:Label ID="Label9" runat="server" Font-Bold="False" Font-Size="Large" 
                        Text="Course Code"></asp:Label>
                </td>
                <td class="style13">
                    <asp:TextBox ID="txtCourseCode" runat="server" Height="19px" Width="161px"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtCourseCode" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp; [eg:CM,EJ]</td>
            </tr>
            <tr align="left">
                <td class="style14">
                    <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="Large" 
                        Text="Course Name"></asp:Label>
                </td>
                <td class="style17">
                    <asp:TextBox ID="txtCourseName" runat="server" Height="22px" Width="164px"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtCourseName" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <br />
                    [eg:Computer Technology]</td>
            </tr>
            <tr>
                <td class="style11">
                    <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Large" 
                        Text="Established Year"></asp:Label>
                </td>
                <td class="style8">
                    <asp:TextBox ID="txtEstablishedYear" runat="server" 
                         Height="28px" 
                        style="margin-left: 2px" Width="165px"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtEstablishedYear" ErrorMessage="*"></asp:RequiredFieldValidator>
                    <br />
                    &nbsp;&nbsp;&nbsp; [eg:2003,1998]</td>
            </tr>
            <tr align="center" valign="middle">
                <td class="style1" colspan="2" align="justify">
                    <asp:Button ID="Button1" runat="server" Text="Update" onclick="Button1_Click" 
                        Width="94px" Font-Size="Medium" Height="38px" />
                    <asp:Button ID="Button2" runat="server" Text="Delete" Font-Size="Medium" 
                        Height="39px" onclick="Button2_Click" Width="100px" />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblmsg" runat="server" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            </table>
</asp:Content>

