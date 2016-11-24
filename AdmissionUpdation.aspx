<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdmissionUpdation.aspx.cs" Inherits="AdmissionUpdation" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="calendar-blue.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtAdmissionDate.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%d/%m/%Y",
            daFormat: "%l;%M %p, %e %m,  %Y",
            align: "BR",
            electric: false,
            singleClick: false,
            displayArea: ".siblings('.dtcDisplayArea')",
            button: ".next()"
        });
    });
    
</script>
    <style type="text/css">
        .style9
        {
            height: 74px;
        }
        .style10
        {
            width: 54px;
        }
        .style11
        {
            width: 381px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table cellpadding="0" cellspacing="5" align="center" frame="box" 
        style="border: thin solid #000000; width: 834px;" >
<tr>
            <td colspan="6" align="Center" class="style9">
                <asp:Label ID="Label3" runat="server" Font-Italic="False" 
                    Font-Size="X-Large" Text="Admission Updation Form" Font-Bold="True" 
                    Font-Underline="True" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;<asp:Label ID="txtStudId" runat="server" 
                    Text="Select student Id and Semester" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="4">
                <asp:DropDownList ID="ddlstudentId" runat="server" Height="19px" Width="170px" 
                    AutoPostBack="True" onselectedindexchanged="ddlstudentId_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlCurrentSem" runat="server" Height="24px" Width="173px" 
                    onselectedindexchanged="ddlCurrentSem_SelectedIndexChanged" 
                    AutoPostBack="True">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td colspan="2">
                    <asp:Label ID="Label14" runat="server" Font-Size="Large" Text="StudyInCollege" 
                        Font-Bold="False"></asp:Label>
            </td>
            <td colspan="4">
                <asp:DropDownList ID="ddlStudentCollege" runat="server" Height="19px" 
                    Width="170px" 
                    onselectedindexchanged="ddlStudentCollege_SelectedIndexChanged">
                    <asp:ListItem>--choose college--</asp:ListItem>
                    <asp:ListItem>1075</asp:ListItem>
                    <asp:ListItem>0095</asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="RollNo" runat="server" Text="RollNumber" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtRollNumber" runat="server" Width="168px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label8" runat="server" Text="AcademicYear" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="4">
                <asp:DropDownList ID="ddlAcademicYear" runat="server" AutoPostBack="True" 
                    Height="26px" Width="172px" 
                    onselectedindexchanged="ddlAcademicYear_SelectedIndexChanged">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>2011-12</asp:ListItem>
                    <asp:ListItem>2012-13</asp:ListItem>
                    <asp:ListItem>2013-14</asp:ListItem>
                    <asp:ListItem>2014-15</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label9" runat="server" Text="AdmissionDate" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="4">
                <asp:TextBox ID="txtAdmissionDate" runat="server" Width="171px" Height="21px"></asp:TextBox>
                    &nbsp;<img alt="" src="calender.png" style="height: 16px; width: 16px;" />

                </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label10" runat="server" Text="CourseCode" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="4">
                <asp:DropDownList ID="ddlCourseCode" runat="server" 
                    onselectedindexchanged="ddlCourseCode_SelectedIndexChanged" Height="21px" 
                    Width="173px">
                    <asp:ListItem>-Select-</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label15" runat="server" Font-Size="Large" 
                    Text="Current Semister"></asp:Label>
            </td>
            <td colspan="4">
                <asp:DropDownList ID="ddlCurrentSem1" runat="server" Height="24px" Width="173px" 
                    onselectedindexchanged="ddlCurrentSem_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label12" runat="server" Text="StudyInYear" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="4">
                <asp:DropDownList ID="ddlStudyInYear" runat="server" Height="25px" 
                    Width="173px" onselectedindexchanged="ddlStudyInYear_SelectedIndexChanged">
                    <asp:ListItem>-Select-</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr align="left">
            <td class="style7" valign="top" colspan="2">
                <asp:Label ID="Label11" runat="server" Text="AdmissionType" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td class="style8" align="justify" colspan="3">
                <asp:RadioButtonList ID="rblAdmisnType" runat="server" 
                    RepeatDirection="Horizontal" Height="29px" Width="198px">
                    <asp:ListItem>Direct II</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                </asp:RadioButtonList>
                &nbsp;</td>
            <td class="style7" align="justify">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label13" runat="server" Text="Upload Photo" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td colspan="2">
                    <asp:Button ID="btnUpload" runat="server" CausesValidation="False" 
                        OnClick="Upload" Text="Upload" />
            </td>
            <td colspan="2">
                    <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
            </td>
        </tr>
        <tr>
            <td align="left" colspan="3" class="style10">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td align="left" colspan="3">
                    &nbsp;
                    </td>
        </tr> 
        <tr>
            <td align="center" colspan="6">
                &nbsp;
                <asp:Button ID="btnUpdate" runat="server" onclick="Button1_Click" Text="Update" 
                    Font-Size="Large" />
                &nbsp;<asp:Button ID="btnDelete" runat="server" Text="Delete" Font-Size="Large" 
                    onclick="btnDelete_Click" />
                <br />
                <asp:Label ID="lblmsg" runat="server" style="font-size: x-large"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>

