<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminTasks.aspx.cs" Inherits="AdminTasks" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style8
        {
        }
        .style9
        {
            height: 43px;
        }
    .style11
    {
    }
    .style12
    {
        width: 376px;
    }
    .style13
    {
        width: 376px;
        height: 46px;
    }
    .style14
    {
        height: 46px;
    }
    .style15
    {
        width: 376px;
        height: 43px;
    }
    .style16
    {
        width: 376px;
        height: 52px;
    }
    .style17
    {
        height: 52px;
    }
    .style20
    {
        height: 55px;
    }
    .style21
    {
        width: 376px;
        height: 53px;
    }
    .style22
    {
        height: 53px;
    }
    .style23
    {
        width: 376px;
        height: 45px;
    }
    .style24
    {
        height: 45px;
    }
    .style25
    {
        width: 376px;
        height: 37px;
    }
    .style26
    {
        height: 37px;
    }
    .style27
    {
        width: 376px;
        height: 42px;
    }
    .style28
    {
        height: 42px;
    }
        .style29
        {
            font-size: x-large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <br />
                <asp:Label ID="lblwelcome" runat="server" 
        style="font-style: italic; font-size: x-large; color: #FFFF00"></asp:Label>
    <table style="border: thin solid #000000; height: 403px; width: 776px" 
        align="center">
        <tr>
            <td class="style20" align="center" colspan="2">
                <asp:Label ID="Label4" runat="server" Font-Size="XX-Large" Text="Admin Tasks"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style12">
                <asp:Label ID="Label5" runat="server" Font-Size="X-Large" 
                    Text="Insertion forms" Font-Italic="True"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label6" runat="server" Font-Size="X-Large" Text="Updation forms" 
                    Font-Italic="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <asp:LinkButton ID="lnkAdmissionmngmt" runat="server" 
                    onclick="LinkButton5_Click" Font-Size="Large" ForeColor="Blue">Admission 
                Management</asp:LinkButton>
                <br />
            </td>
            <td class="style14" rowspan="2">
                <asp:LinkButton ID="lnkAdmissionManagement" runat="server" 
                    onclick="lnkAdmissionManagement_Click">Admission Updation</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style13">
                For Giving Admission to Next Academic Year:<asp:Button ID="Button1" 
                    runat="server" onclick="Button1_Click" Text="Reset Students" />
            </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:LinkButton ID="lnkStaffmngmt" runat="server" onclick="LinkButton1_Click" 
                    Font-Size="Large" ForeColor="Blue">Staff 
                Management</asp:LinkButton>
            </td>
            <td class="style9">
                <asp:LinkButton ID="lnkStaffManagement" runat="server" 
                    onclick="lnkStaffManagement_Click">Staff Management</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style16">
                <asp:LinkButton ID="lnksemistermngmt" runat="server" 
                    onclick="LinkButton2_Click" Font-Size="Large" ForeColor="Blue">Semister 
                Management</asp:LinkButton>
            </td>
            <td class="style17">
                <asp:LinkButton ID="lnkSemManagement" runat="server" 
                    onclick="lnkSemManagement_Click">Semister Management</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style21">
                <asp:LinkButton ID="lnbsubjectmngmt" runat="server" 
                    onclick="lnbsubjectmngmt_Click" Font-Size="Large" ForeColor="Blue"> Subject Management</asp:LinkButton>
            </td>
            <td class="style22">
                <asp:LinkButton ID="lnkSubjectManagement" runat="server" 
                    onclick="lnkSubjectManagement_Click">Subject Management</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:LinkButton ID="lnkCoursemngmt" runat="server" 
                    onclick="lnkCoursemngmt_Click" Font-Size="Large" ForeColor="Blue">Course Management</asp:LinkButton>
            </td>
            <td class="style9">
                <asp:LinkButton ID="lnkCourseManagement" runat="server" 
                    onclick="lnkCourseManagement_Click">Course Management</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style23">
                <asp:LinkButton ID="lnkStudentMaster" runat="server" 
                    onclick="lnkstudentMaster_Click" Font-Size="Large" ForeColor="Blue">Student 
                Master</asp:LinkButton>
            </td>
            <td class="style24">
                <asp:LinkButton ID="lnkStudentMaster0" runat="server" 
                    onclick="lnkStudentMaster0_Click">Student Master</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style15">
                <asp:LinkButton ID="lnkStaffDept" runat="server" onclick="lnkStaffDept_Click">Staff Department</asp:LinkButton>
            </td>
            <td class="style9">
                <asp:LinkButton ID="lnkStaffDept0" runat="server" onclick="lnkStaffDept0_Click">Staff Department</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="style25">
                <asp:LinkButton ID="lnkStudMsbteMast" runat="server" 
                    onclick="lnkStudMsbteMast_Click">Student MSBTE Master</asp:LinkButton>
            </td>
            <td class="style26">
                </td>
        </tr>
        <tr>
            <td class="style27">
                <asp:LinkButton ID="lnkEvents" runat="server" onclick="lnkEvents_Click">Events</asp:LinkButton>
            </td>
            <td class="style28">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style25">
                <asp:LinkButton ID="lnkPhotoGallery" runat="server" 
                    onclick="lnkPhotoGallery_Click">Photo Gallery</asp:LinkButton>
            </td>
            <td class="style26">
                </td>
        </tr>
        <tr>
            <td class="style24" align="justify">
                <asp:LinkButton ID="LinkButton5" runat="server" onclick="LinkButton5_Click1">staffIDPassAllocation</asp:LinkButton>
            </td>
            <td class="style24" align="right">
            </td>
        </tr>
        <tr>
            <td class="style11" align="right">
                <br />
                <span class="style29">Change Id or Password</span> :<asp:LinkButton 
                    ID="LinkButton6" runat="server" onclick="LinkButton6_Click">Click Here &gt;&gt;</asp:LinkButton>
            </td>
            <td class="style11" align="right">
                <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click" 
                    Font-Size="X-Large" ForeColor="Blue">Logout</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

