<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AcademicYearMaster.aspx.cs" Inherits="AcademicYearMaster" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">


    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
<script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
<script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
<link href="calendar-blue.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    $(document).ready(function () {
        $("#<%=txtTermStarts.ClientID %>").dynDateTime({
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
    $(document).ready(function () {
        $("#<%=txtTermEnds.ClientID %>").dynDateTime({
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
        .style8
        {}
        .style9
        {
            width: 405px;
        }
        .style10
        {
            height: 56px;
        }
        .style11
        {
            width: 142px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" style="width: 33%" frame="box">
        <tr>
            <td class="style10" colspan="2" align="justify">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    Font-Underline="True" Text="Academic Year"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label5" runat="server" Text="AcademicYear"></asp:Label>
            </td>
            <td class="style9">
                <asp:DropDownList ID="ddlAcademicStartYear" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlAcademicStartYear_SelectedIndexChanged1">
                </asp:DropDownList>
                <asp:TextBox ID="txtACYR" runat="server" Enabled="False" Width="102px"></asp:TextBox>
                &nbsp;[ eg:2012-13]&nbsp;&nbsp;&nbsp;<br />
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtACYR" ErrorMessage="*Please enter Academic year"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label10" runat="server" Text="For Year"></asp:Label>
            </td>
            <td class="style9">
                 <asp:DropDownList ID="ddlForYear" runat="server" Height="16px" Width="128px">
                     <asp:ListItem>-SELECT-</asp:ListItem>
                     <asp:ListItem>1</asp:ListItem>
                     <asp:ListItem>2</asp:ListItem>
                     <asp:ListItem>3</asp:ListItem>
                 </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label9" runat="server" Text="Sem Type"></asp:Label>
            </td>
            <td class="style9">
                 <asp:DropDownList ID="ddlSemType" runat="server" Width="132px" Height="21px">
                        <asp:ListItem>-Select-</asp:ListItem>
                        <asp:ListItem>Winter</asp:ListItem>
                        <asp:ListItem>Summer</asp:ListItem>
                    </asp:DropDownList>&nbsp;<br />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                     ControlToValidate="ddlSemType" 
                     ErrorMessage="*Please enter Semester number"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label7" runat="server" Text="Term Starts"></asp:Label>
            </td>
            <td class="style9">
                <asp:TextBox ID="txtTermStarts" runat="server" Width="139px" Height="21px"></asp:TextBox>
                    &nbsp;<img alt="" src="calender.png" style="height: 16px; width: 16px;" />

                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtTermStarts" ErrorMessage="*Please enter Date"></asp:RequiredFieldValidator>

                </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="Label8" runat="server" Text="Term Ends"></asp:Label>
            </td>
            <td class="style9">
                <asp:TextBox ID="txtTermEnds" runat="server" Width="135px" Height="21px"></asp:TextBox>
                    &nbsp;<img alt="" src="calender.png" style="height: 16px; width: 16px;" />

                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtTermEnds" ErrorMessage="*Please enter Date"></asp:RequiredFieldValidator>

                </td>
        </tr>
        <tr align="center">
            <td class="style8" colspan="2" align="justify">
                <asp:Button ID="Button1" runat="server" Height="36px" onclick="Button1_Click" 
                    Text="Submit" Width="80px" />
                &nbsp;
                <asp:Button ID="Button2" runat="server" Height="35px" Text="Reset" 
                    Width="72px" onclick="Button2_Click" />
                <br />
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red" Font-Size="Larger"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

