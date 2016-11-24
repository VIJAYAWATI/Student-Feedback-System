<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceInfo.aspx.cs" Inherits="AttendanceInfo" Title="Attendance Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style6
        {
            width: 517px;
           
        }
        .style7
        {
            height: 29px;
        }
        .style8
        {
            height: 77px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" class="style6">
        <tr>
            <td colspan="2" align="center" class="style8">
                <asp:Label runat="server" Font-Bold="True" Font-Size="X-Large" 
                    Text="ATTENDANCE INFORMATION"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Size="Large" 
                    Text="AcademicYear:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlAcademicYear" runat="server" Height="27px" 
                    Width="223px" 
                    onselectedindexchanged="ddlAcademicYear_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="Large" 
                    Text="SemisterCode:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSemCode" runat="server" Height="27px" Width="223px" 
                    onselectedindexchanged="ddlSemCode_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Font-Bold="False" Font-Size="Large" 
                    Text="SubjectCode:"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlSubCode" runat="server" Height="27px" Width="223px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style7">
                <asp:Label ID="Label6" runat="server" Font-Bold="False" Font-Size="Large" 
                    Text="SubjectType:"></asp:Label>
            </td>
            <td class="style7">
                <asp:DropDownList ID="ddlSubType" runat="server" Height="27px" Width="223px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="center">
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Font-Bold="False" Font-Size="Large" 
                    Text="Attendance&gt;&gt;&gt;" onclick="Button1_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

