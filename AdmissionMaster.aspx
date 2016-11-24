<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdmissionMaster.aspx.cs" Inherits="Admission" Title="Admission Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="calendar-blue.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtAdmissionDate.ClientID %>").dynDateTime({
            showsTime: true,
            ifFormat: "%d/%m/%Y ",
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
        .style7
        {
            height: 23px;
        }
        .style8
        {
            height: 23px;
            width: 225px;
        }
    .style9
    {
        height: 84px;
    }
        .style11
        {
            width: 301px;
        }
        .style12
        {
            height: 23px;
            width: 301px;
        }
        .style13
        {
            width: 414px;
        }
    .style14
    {
        height: 50px;
    }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="0" cellspacing="5" align="center" frame="box" 
        style="border: thin solid #000000; width: 834px;" >
<tr>
            <td colspan="7" align="center" class="style9">
                <asp:Label ID="Label3" runat="server" Font-Italic="False" 
                    Font-Size="X-Large" Text="Admission Form" Font-Bold="True" 
                    Font-Underline="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                    <asp:Label ID="Label14" runat="server" Font-Size="Large" Text="Study In College" 
                        Font-Bold="False"></asp:Label>
            </td>
            <td colspan="6">
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
            <td class="style11">
                <asp:Label ID="txtStudId" runat="server" Text="Student Id" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlstudentId" runat="server" Height="19px" Width="170px" 
                    onselectedindexchanged="ddlstudentId_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="ddlstudentId" ErrorMessage="*"></asp:RequiredFieldValidator>
                &nbsp;
                </td>
            <td colspan="2" class="style13">
                <asp:Label ID="RollNo" runat="server" Text="Roll Number" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
                </td>
            <td>
                <asp:TextBox ID="txtRollNumber" runat="server" Width="168px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtRollNumber" ErrorMessage="*"></asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label8" runat="server" Text="AcademicYear" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlAcademicYear" runat="server" AutoPostBack="True" 
                    Height="26px" Width="172px" 
                    onselectedindexchanged="ddlAcademicYear_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="*" ControlToValidate="ddlAcademicYear"></asp:RequiredFieldValidator>
            </td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label9" runat="server" Text="Admission Date" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtAdmissionDate" runat="server" Width="171px" Height="21px"></asp:TextBox>
                    <img alt="" src="calender.png" style="height: 16px; width: 16px;" /><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="*" ControlToValidate="ddlCourseCode"></asp:RequiredFieldValidator>

            </td>
            <td colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label10" runat="server" Text="Course Code" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="ddlCourseCode" runat="server" 
                    onselectedindexchanged="ddlCourseCode_SelectedIndexChanged" Height="21px" 
                    Width="173px" AutoPostBack="True">
                    <asp:ListItem>-Select-</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="*" ControlToValidate="ddlStudyInYear"></asp:RequiredFieldValidator>
            </td>
            <td colspan="2">
                <asp:Label ID="Label15" runat="server" Font-Size="Large" 
                    Text="Current Semister"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlCurrentSem" runat="server" Height="24px" Width="173px" 
                    AutoPostBack="True" onselectedindexchanged="ddlCurrentSem_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label12" runat="server" Text="Study In Year" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="6">
                <asp:DropDownList ID="ddlStudyInYear" runat="server" Height="18px" 
                    onselectedindexchanged="ddlStudyInYear_SelectedIndexChanged" Width="173px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="*" ControlToValidate="ddlStudyInYear"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr align="left">
            <td class="style12" valign="top">
                <asp:Label ID="Label11" runat="server" Text="Admission Type" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td class="style8" align="justify">
                <asp:RadioButtonList ID="rblAdmisnType" runat="server" 
                    RepeatDirection="Horizontal" Height="29px" Width="198px">
                    <asp:ListItem>Direct II</asp:ListItem>
                    <asp:ListItem>Normal</asp:ListItem>
                </asp:RadioButtonList>
                &nbsp;</td>
            <td class="style8" align="justify" colspan="4">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ErrorMessage="*" ControlToValidate="rblAdmisnType"></asp:RequiredFieldValidator>
            </td>
            <td class="style7" align="justify">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label13" runat="server" Text="Upload Photo" Font-Bold="False" 
                    Font-Size="Large"></asp:Label>
            </td>
            <td colspan="2">
                <asp:FileUpload ID="fileStdImage" runat="server"/>
            </td>
            <td colspan="2">
                    <asp:Button ID="btnUpload" runat="server" CausesValidation="False" 
                        OnClick="Upload" Text="Upload" />
            </td>
            <td colspan="2">
                    <asp:Image ID="Image1" runat="server" Height="100px" Width="100px"/>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="7" class="style14">
                &nbsp;
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" 
                    Font-Size="Large" />
                &nbsp;<asp:Button ID="Button2" runat="server" Text="Reset" Font-Size="Large" 
                    onclick="Button2_Click" />
                <br />
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>

