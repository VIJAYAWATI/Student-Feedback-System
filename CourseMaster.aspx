<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CourseMaster.aspx.cs" Inherits="CourseMaster" Title="Course Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            font-size: 11px;
            color: #000000;
            font-family: Tahoma;
            text-decoration: none;
            line-height: 15px;
           
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
        width: 250px;
    }
    .style10
    {
        height: 68px;
    }
    .style11
    {
        
        font-size: 11px;
        color: #000000;
        font-family: Tahoma;
        text-decoration: none;
        line-height: 15px;
        height: 30px;
        width: 174px;
    }
    .style12
    {
       
        font-size: 11px;
        color: #000000;
        font-family: Tahoma;
        text-decoration: none;
        line-height: 15px;
        height: 43px;
            width: 174px;
        }
    .style13
    {
        width: 250px;
        height: 43px;
    }
        .style14
        {
            font-size: 11px;
            color: #000000;
            font-family: Tahoma;
            text-decoration: none;
            line-height: 15px;
            
            height: 40px;
            width: 174px;
        }
        .style16
        {
            font-size: 11px;
            color: #000000;
            font-family: Tahoma;
            text-decoration: none;
            line-height: 15px;
            
            height: 23px;
        }
        .style17
        {
            width: 250px;
            height: 40px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">


    <h2 align="center">
        &nbsp;</h2>
    <p>
        <table 
            align="center">
            <tr align="center">
                <td class="style10" colspan="2" align="justify">
        <asp:Label ID="Label7" runat="server" Text="COURSE MASTER&nbsp;&nbsp;&nbsp; " 
                        Font-Bold="True" Font-Size="X-Large"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style12">
                    <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="Large" 
                        Text="Course Code"></asp:Label>
                </td>
                <td class="style13">
                    <asp:TextBox ID="txtCourseCode" runat="server" MaxLength="6"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtCourseCode" ErrorMessage="* "></asp:RequiredFieldValidator>
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp; [eg:CM,EJ]</td>
            </tr>
            <tr align="left">
                <td class="style14">
                    <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="Large" 
                        Text="Course Name"></asp:Label>
                </td>
                <td class="style17">
                    <asp:TextBox ID="txtCourseName" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="txtCourseName" ErrorMessage="* "></asp:RequiredFieldValidator>
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
                        ontextchanged="TextBox3_TextChanged" MaxLength="4" MinLength="4"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="txtEstablishedYear" ErrorMessage="* "></asp:RequiredFieldValidator>
                    <br />
                    &nbsp;&nbsp;&nbsp; [eg:2003,1998]</td>
            </tr>
            <tr>
                <td class="style16" colspan="2">
                    </td>
            </tr>
            <tr align="center" valign="middle">
                <td class="style1" colspan="2" align="justify">
                    <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" 
                        Width="81px" Font-Size="Medium" />
                    <asp:Button ID="Button2" runat="server" Text="Reset" Font-Size="Medium" 
                        onclick="Button2_Click" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label>
                </td>
            </tr>
            </table>
    </p>
</asp:Content>

